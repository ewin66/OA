﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SMT.FB.UI.Common;
using SMT.FB.UI.Common.Controls;
using SMT.FB.UI.FBCommonWS;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;


namespace SMT.FB.UI.Form.BudgetApply
{
    public class DepartmentTransferAppForm : FBPage
    {
        const string FIELDNAME_TRANSFERFROM = "TRANSFERFROM";
        const string FIELDNAME_TRANSFERTO = "TRANSFERTO";
        const string Msg_SaveTransfer = "调出单位不能与调入单位一样!";

        string msgBiggerError = CommonFunction.GetString("DATEGREATERERROR");
        FBEntityService fbService;

        public DepartmentTransferAppForm(OrderEntity orderEntity)
            : base(orderEntity)
        {
            fbService = new FBEntityService();
            fbService.QueryFBEntitiesCompleted += new EventHandler<QueryFBEntitiesCompletedEventArgs>(fbService_QueryFBEntitiesCompleted);

            this.EditForm.Saving += new EventHandler<SavingEventArgs>(EditForm_Saving);

        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitData()
        {
            if (this.OrderEntity.FBEntityState == FBEntityState.Added)
            {

                EmployeerData create = this.OrderEntity.GetCreateInfo();

                this.OrderEntity.ReferencedData["Entity.FromObject"] = new MyOrgObjectData { Value = create.Department };

                this.OrderEntity.SetObjValue(EntityFieldName.OwnerID, create.Value);
                this.OrderEntity.SetObjValue(EntityFieldName.OwnerName, create.Text);
                this.OrderEntity.SetObjValue(EntityFieldName.OwnerPostID, create.Post.Value);
                this.OrderEntity.SetObjValue(EntityFieldName.OwnerPostName, create.Post.Text);

                OrderEntity.SetObjValue("Entity.BUDGETARYMONTH", new DateTime(DataCore.SystemDateTime.Year, DataCore.SystemDateTime.Month, 1));
                this.OrderEntity.SetObjValue(EntityFieldName.OwnerDepartmentID, this.OrderEntity.GetObjValue(FIELDNAME_TRANSFERFROM.ToEntityString()));
            }
            else if (this.EditForm.OperationType == OperationTypes.Browse)
            {
                SetPropertyChanged();
                return;
            }
            GetOrderDetail();
        }

        private void GetOrderDetail()
        {

            T_FB_DEPTTRANSFERMASTER master = this.OrderEntity.Entity as T_FB_DEPTTRANSFERMASTER;

            // 调出单位类型
            QueryExpression qeTransferType = this.OrderEntity.GetQueryExpression("TRANSFERFROMTYPE");
            qeTransferType.PropertyName = "ACCOUNTOBJECTTYPE";
            // 预算单位
            QueryExpression qeFrom = this.OrderEntity.GetQueryExpression("TRANSFERFROM");
            qeFrom.RelatedExpression = qeTransferType;
            if (master.TRANSFERFROMTYPE.Equal(3)) // 个人
            {
                qeFrom.PropertyName = FieldName.OwnerID;

                // 岗位

                QueryExpression qePost = QueryExpressionHelper.Equal(FieldName.OwnerPostID, master.TRANSFERFROMPOSTID);

                qeFrom.RelatedExpression = qePost;
            }
            else
            {
                qeFrom.PropertyName = FieldName.OwnerDepartmentID;
            }

            // 预算年份
            QueryExpression qeYear = QueryExpressionHelper.Equal("BUDGETYEAR", master.BUDGETARYMONTH.Year.ToString());
            qeYear.RelatedExpression = qeFrom;
            // 预算月份         
            QueryExpression qeMonth = QueryExpressionHelper.Equal("BUDGETMONTH", master.BUDGETARYMONTH.Month.ToString());
            qeMonth.RelatedExpression = qeYear;
            qeMonth.QueryType = typeof(T_FB_DEPTTRANSFERDETAIL).Name;
            fbService.QueryFBEntities(qeMonth);
        }

        void fbService_QueryFBEntitiesCompleted(object sender, QueryFBEntitiesCompletedEventArgs e)
        {

            if (this.EditForm.OperationType == OperationTypes.Add)
            {
                DoForAdd(e);
            }
            else
            {
                DoForEdit(e);
            }

           
            SetPropertyChanged();

        }

        /// <summary>
        /// 添加时操作
        /// </summary>
        /// <param name="e"></param>
        private void DoForAdd(QueryFBEntitiesCompletedEventArgs e)
        {
            SetPropertyChanged();
            // 清除预算明细
            this.OrderEntity.GetRelationFBEntities(typeof(T_FB_DEPTTRANSFERDETAIL).Name).Clear();
            this.OrderEntity.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name).Clear();

            // 添加预算明细
            // 添加预算明细
            e.Result.ToList().ForEach(item =>
            {
                T_FB_DEPTTRANSFERDETAIL deptDetail = item.Entity as T_FB_DEPTTRANSFERDETAIL;
                deptDetail.T_FB_DEPTTRANSFERMASTER = this.OrderEntity.Entity as T_FB_DEPTTRANSFERMASTER;
                item.FBEntityState = FBEntityState.Added;

                #region 个人明细
                item.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name).ToList().ForEach(fbpersondetail =>
                {
                    T_FB_PERSONTRANSFERDETAIL persondetail = fbpersondetail.Entity as T_FB_PERSONTRANSFERDETAIL;
                    persondetail.CREATEUSERID = this.OrderEntity.LoginUser.Value.ToString();
                    persondetail.CREATEUSERNAME = this.OrderEntity.LoginUser.Text;
                    persondetail.UPDATEUSERID = this.OrderEntity.LoginUser.Value.ToString();
                    persondetail.UPDATEUSERNAME = this.OrderEntity.LoginUser.Text;
                    persondetail.T_FB_DEPTTRANSFERDETAIL = item.Entity as T_FB_DEPTTRANSFERDETAIL;

                    fbpersondetail.FBEntityState = FBEntityState.Added;
                });
                #endregion

                deptDetail.T_FB_SUBJECT.T_FB_BUDGETACCOUNT.Clear();
                deptDetail.T_FB_SUBJECT.T_FB_BUDGETCHECK.Clear();

            });
            this.OrderEntity.FBEntity.AddFBEntities<T_FB_DEPTTRANSFERDETAIL>(e.Result);
            this.OrderEntity.FBEntity.SetObjValue("Entity.TRANSFERMONEY", 0);

        }

        /// <summary>
        /// 编辑时操作
        /// </summary>
        /// <param name="e"></param>
        private void DoForEdit(QueryFBEntitiesCompletedEventArgs e)
        {

            // 清除预算明细
            var details = this.OrderEntity.GetRelationFBEntities(typeof(T_FB_DEPTTRANSFERDETAIL).Name);
            var personDetails = this.OrderEntity.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name);

            var detailsTemp = details.ToList();

            var resultsTemp = e.Result.ToList();
            Action<ObservableCollection<FBEntity>, ObservableCollection<FBEntity>, T_FB_DEPTTRANSFERDETAIL> handelDetailPerson = (detailPersons, resultPersons, detail) =>
            {
                detailPersons.CompareFBEntity(resultPersons,
                    (item, itemR) => item.CompareFBEntity<T_FB_PERSONTRANSFERDETAIL>(itemR, entity => entity.OWNERID, entity1 => entity1.OWNERPOSTID),
                (item, find) =>  /*找到的处理*/
                {
                    var itemEntity = item.Entity as T_FB_PERSONTRANSFERDETAIL;
                    var findEntity = find.Entity as T_FB_PERSONTRANSFERDETAIL;
                    itemEntity.USABLEMONEY = findEntity.USABLEMONEY;
                    itemEntity.LIMITBUDGETMONEY = findEntity.LIMITBUDGETMONEY;

                },
                (item) => /*需要删除的item*/
                {
                    personDetails.Add(item);
                    personDetails.Remove(item);
                    detailPersons.Remove(item);
                },

                (itemR) => /*需要新的item*/
                {
                    var findEntity = itemR.Entity as T_FB_PERSONTRANSFERDETAIL;
                    findEntity.T_FB_DEPTTRANSFERDETAIL = detail;
                    findEntity.T_FB_SUBJECT = detail.T_FB_SUBJECT;
                    findEntity.CREATEUSERID = this.OrderEntity.LoginUser.Value.ToString();
                    findEntity.CREATEUSERNAME = this.OrderEntity.LoginUser.Text;
                    findEntity.UPDATEUSERID = this.OrderEntity.LoginUser.Value.ToString();
                    findEntity.UPDATEUSERNAME = this.OrderEntity.LoginUser.Text;
                    
                    itemR.FBEntityState = FBEntityState.Added;
                    detailPersons.Add(itemR);
                }
                );
            };
            details.CompareFBEntity(e.Result,
                (item, itemR) => item.CompareFBEntity<T_FB_DEPTTRANSFERDETAIL>(itemR, entity => entity.T_FB_SUBJECT.SUBJECTID),
                (item, find) =>  /*找到的处理*/
                {
                    var itemEntity = item.Entity as T_FB_DEPTTRANSFERDETAIL;
                    var findEntity = find.Entity as T_FB_DEPTTRANSFERDETAIL;
                    itemEntity.USABLEMONEY = findEntity.USABLEMONEY;
                    
                    var d1 = item.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name);
                    var d2 = find.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name);
                    handelDetailPerson(d1, d2, itemEntity);
                },
                (item) => /*需要删除的item*/
                {
                    var d1 = item.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name);
                    var d2 = new ObservableCollection<FBEntity>();
                    handelDetailPerson(d1, d2, item.Entity as T_FB_DEPTTRANSFERDETAIL);

                    details.Remove(item);
                },

                (itemR) => /*需要新的item*/
                {
                    var deptDetail = itemR.Entity as T_FB_DEPTTRANSFERDETAIL;
                    deptDetail.T_FB_SUBJECT.T_FB_BUDGETACCOUNT.Clear();
                    deptDetail.T_FB_SUBJECT.T_FB_BUDGETCHECK.Clear();
                    deptDetail.T_FB_DEPTTRANSFERMASTER = this.OrderEntity.Entity as T_FB_DEPTTRANSFERMASTER;
                    itemR.FBEntityState = FBEntityState.Added;
                    details.Add(itemR);
                    var d1 = new ObservableCollection<FBEntity>();
                    var d2 = itemR.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name);
                    handelDetailPerson(d1, d2, deptDetail);
                }
            );

            RefreshBudgetData();
        }

        protected override void OnLoadDataComplete()
        {

            InitData();
        }

        protected override void OnLoadControlComplete()
        {
            this.OrderEntity.OrderPropertyChanged += new EventHandler<OrderPropertyChangedArgs>(OrderEntity_OrderPropertyChanged);
            if (this.EditForm.OperationType != OperationTypes.Browse)
            {
                this.ShowProcess(true);
                this.EditForm.BindingData(new OrderEntity(new T_FB_DEPTTRANSFERMASTER()));
            }
        }

        void EditForm_Saving(object sender, SavingEventArgs e)
        {

            
            List<string> msgs = new List<string>();

            if (object.Equals(this.OrderEntity.GetObjValue(EntityFieldName.OwnerID), null))
            {
                msgs.Add("找不到相应的部门负责人!");

            }
            else
            {
                // 调出金额不可大于可用金额

                ObservableCollection<FBEntity> details = this.OrderEntity.GetRelationFBEntities(typeof(T_FB_DEPTTRANSFERDETAIL).Name);
                ObservableCollection<FBEntity> personDetails = this.OrderEntity.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name);
                if (details.Count == 0)
                {
                    msgs.Add(ErrorMessage.NoDetailInfo);
                }
                var validDetails = details.FindAll(item => (item.Entity as T_FB_DEPTTRANSFERDETAIL).TRANSFERMONEY != 0);
                var validPersonDetails = personDetails.FindAll(item => (item.Entity as T_FB_PERSONTRANSFERDETAIL).BUDGETMONEY != 0);

                personDetails.ToList().ForEach(item =>
                    {
                        T_FB_PERSONTRANSFERDETAIL personDetail = item.Entity as T_FB_PERSONTRANSFERDETAIL;
                        if (personDetail.BUDGETMONEY < 0)
                        {
                            if (personDetail.LIMITBUDGETMONEY + personDetail.BUDGETMONEY < 0)
                            {
                                string errorMessage = string.Format(ErrorMessage.Err_ComCheck2, personDetail.T_FB_SUBJECT.SUBJECTNAME);
                                msgs.Add(errorMessage);
                            }
                        }
                    });
                if (validDetails.Count == 0)
                {
                    msgs.Add(ErrorMessage.NoDetailInfo);
                }

                details.ToList().ForEach(item =>
                {
                    T_FB_DEPTTRANSFERDETAIL detail = item.Entity as T_FB_DEPTTRANSFERDETAIL;

                    //if (detail.TRANSFERMONEY < 0)
                    //{
                    //    string errorMessage = string.Format(ErrorMessage.TransMoneyZero, detail.T_FB_SUBJECT.SUBJECTNAME);
                    //    msgs.Add(errorMessage);
                    //}


                    if (detail.TRANSFERMONEY < 0)
                    {
                        if (detail.USABLEMONEY + detail.TRANSFERMONEY < 0)
                        {
                            string errorMessage = string.Format(ErrorMessage.Err_ComCheck2, detail.T_FB_SUBJECT.SUBJECTNAME);
                            msgs.Add(errorMessage);
                        }
                    }

                    if (detail.USABLEMONEY.LessThan(detail.TRANSFERMONEY))
                    {
                        if (detail.TRANSFERMONEY > 0)
                        {
                            msgs.Add(string.Format(ErrorMessage.TransMoneyBigger, detail.T_FB_SUBJECT.SUBJECTNAME));
                        }
                    }

                });
            }
            if (msgs.Count > 0)
            {
                CommonFunction.ShowErrorMessage(msgs);
                e.Action = Actions.Cancel;
            }
        }

        void OrderEntity_OrderPropertyChanged(object sender, OrderPropertyChangedArgs e)
        {

            T_FB_DEPTTRANSFERMASTER entity = this.OrderEntity.Entity as T_FB_DEPTTRANSFERMASTER;
            if (e.Result.Contains("Entity.TRANSFERFROM"))
            {
                if (entity.TRANSFERFROMTYPE.Equal(3)) // 个人        
                {
                    EmployeerData ed = (entity.FromObject as EmployeerData);
                    entity.OWNERID = ed.Value.ToString();
                    entity.OWNERNAME = ed.Text;
                    entity.OWNERDEPARTMENTID = ed.Department.Value.ToString();
                    entity.OWNERPOSTID = ed.Post.Value.ToString();
                    entity.OWNERPOSTNAME = ed.Post.Text.ToString();
                }
                else if (entity.TRANSFERFROMTYPE.Equal(2)) // 部门　        
                {
                    entity.OWNERDEPARTMENTID = entity.TRANSFERFROM;
                    //entity.OWNERDEPARTMENTNAME = dd.Text;
                    //entity.OWNERCOMPANYID = dd.Company.Value.to
                    ChangeOwnerID();
                }
                else
                {
                    // 清除预算明细
                    this.OrderEntity.GetRelationFBEntities(typeof(T_FB_DEPTTRANSFERDETAIL).Name).Clear();

                    CommonFunction.ShowMessage("调出单位必须是个人或部门");
                }

                GetOrderDetail();
                ChangeCreator();
            }
            //else if (e.Result.Contains("Entity.ToObject"))
            //{
            //    if (!entity.TRANSFERTOTYPE.Equal(3) && !entity.TRANSFERTOTYPE.Equal(2)) // 个人        
            //    {
            //        CommonFunction.ShowMessage("调入单位必须是个人或部门");
            //    }
            //}

        }




        protected override void OnOwnerIsNotReady()
        {
            T_FB_DEPTTRANSFERMASTER entity = this.OrderEntity.Entity as T_FB_DEPTTRANSFERMASTER;
            entity.OWNERID = null;
        }

      
        private void CollectionClear<T>(ObservableCollection<T> collection)
        {
            if (collection != null)
            {
                collection.Clear();
            }
        }

        private void SetPropertyChanged()
        {

            CollectionClear((this.OrderEntity.Entity as T_FB_DEPTTRANSFERMASTER).T_FB_DEPTTRANSFERDETAIL);

            // 因后台保存是二层结构，所有需要把 A->B->C这种结构变成 A->B, A->C结构
            ObservableCollection<FBEntity> detailPersonList = this.OrderEntity.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name);
            ObservableCollection<FBEntity> detailList = this.OrderEntity.GetRelationFBEntities(typeof(T_FB_DEPTTRANSFERDETAIL).Name);

            detailList.ToList().ForEach(item =>
            {
                T_FB_DEPTTRANSFERDETAIL detailDept = (item.Entity as T_FB_DEPTTRANSFERDETAIL);
                CollectionClear(detailDept.T_FB_PERSONTRANSFERDETAIL);
                CollectionClear(detailDept.T_FB_SUBJECT.T_FB_DEPTTRANSFERDETAIL);

                if (item.FBEntityState == FBEntityState.Added)
                {
                    (item.Entity as T_FB_DEPTTRANSFERDETAIL).T_FB_DEPTTRANSFERMASTER = this.OrderEntity.Entity as T_FB_DEPTTRANSFERMASTER;
                }

                #region 部门变化
                // 部门预算明细变化事件
                item.Entity.PropertyChanged += (senderDept, eDept) =>
                {
                    T_FB_DEPTTRANSFERDETAIL DeptDetail = senderDept as T_FB_DEPTTRANSFERDETAIL;

                    #region
                    // 部门预算明细的总预算变化时，统计所有明细的预算
                    if (eDept.PropertyName == "TRANSFERMONEY")
                    {
                        decimal? newTotal = detailList.Sum(itemDept =>
                        {
                            return (decimal?)itemDept.GetObjValue("Entity.TRANSFERMONEY");
                        });

                        this.OrderEntity.SetObjValue("Entity.TRANSFERMONEY", newTotal);
                    }

                    #endregion
                };
                #endregion

                #region 个人预算明细变化
                // 个人预算明细变化
                ObservableCollection<FBEntity> obPersonDetail = item.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name);
                obPersonDetail.ToList().ForEach(itemPerson =>
                {
                    T_FB_PERSONTRANSFERDETAIL persondetail = itemPerson.Entity as T_FB_PERSONTRANSFERDETAIL;
                    CollectionClear(persondetail.T_FB_SUBJECT.T_FB_PERSONTRANSFERDETAIL);
                    itemPerson.Entity.PropertyChanged += (senderPerson, ePerson) =>
                    {
                        if (ePerson.PropertyName == "BUDGETMONEY")
                        {
                            var totalPerson = obPersonDetail.Sum(itemPersonDetail =>
                            {
                                // 在个人预算中将会部门预算记录，所以需要判断是否统计的对象是个人预算
                                T_FB_PERSONTRANSFERDETAIL pDetail = itemPersonDetail.Entity as T_FB_PERSONTRANSFERDETAIL;
                                if (pDetail != null)
                                {
                                    return pDetail.BUDGETMONEY;
                                }
                                else
                                {
                                    return 0;
                                }
                            });

                            var itemDept = item.Entity as T_FB_DEPTTRANSFERDETAIL;
                            itemDept.TRANSFERMONEY = totalPerson.Value;
                        }
                    };

                    detailPersonList.Add(itemPerson);


                });

                // 因为在个人预算中需要体现部门公共费用栏，则加入部门公共费用(T记录到个人预算集合中

                item.HideDetails = obPersonDetail.Count == 0;
                #endregion
            });

            this.EditForm.BindingData();
            this.CloseProcess(false);
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshBudgetData()
        {
            ObservableCollection<FBEntity> detailList = this.OrderEntity.GetRelationFBEntities(typeof(T_FB_DEPTTRANSFERDETAIL).Name);
            decimal? newTotal = 0;
            detailList.ToList().ForEach(item =>
            {
                ObservableCollection<FBEntity> obPersonDetail = item.GetRelationFBEntities(typeof(T_FB_PERSONTRANSFERDETAIL).Name);
                var totalPerson = obPersonDetail.Sum(itemPersonDetail =>
                {
                    // 在个人预算中将会部门预算记录，所以需要判断是否统计的对象是个人预算
                    T_FB_PERSONTRANSFERDETAIL pDetail = itemPersonDetail.Entity as T_FB_PERSONTRANSFERDETAIL;
                    if (pDetail != null)
                    {

                        return pDetail.BUDGETMONEY == null ? 0 : pDetail.BUDGETMONEY.Value;
                    }
                    else
                    {
                        return 0;
                    }
                });
                var itemDept = item.Entity as T_FB_DEPTTRANSFERDETAIL;
                itemDept.TRANSFERMONEY = totalPerson;
                newTotal += itemDept.TRANSFERMONEY;
            });

            this.OrderEntity.SetObjValue("Entity.TRANSFERMONEY", newTotal);
        }
    }
}
