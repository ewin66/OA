﻿
/*
 * 文件名：RepayApplyDetailDAL.cs
 * 作  用：T_FB_REPAYAPPLYDETAIL 数据操作类
 * 创建人：吴鹏
 * 创建时间：2010-12-15 9:52:22
 * 修改人：
 * 修改时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Data.Objects.DataClasses;
using System.Linq.Dynamic;
using System.Linq.Expressions;

using TM_SaaS_OA_EFModel;

namespace SMT.FBAnalysis.DAL
{
    public class RepayApplyDetailDAL:CommDal< T_FB_REPAYAPPLYDETAIL >
    {
        public RepayApplyDetailDAL()
        { 
        }

        /// <summary>
        /// 根据参数，检查是否存在指定记录(方便进行数据增删改)
        /// </summary>
        /// <param name="strFilter">查询语句</param>
        /// <param name="objArgs">查询参数集合</param>
        /// <returns>True/False(是/否)</returns>
        public bool IsExistsRd(string strFilter, params object[] objArgs)
        {
            bool flag = false;

            var q = from v in GetObjects()
                    select v;            

            if (objArgs.Count() <= 0 || string.IsNullOrEmpty(strFilter))
            {
                return flag;
            }

            q = q.Where(strFilter, objArgs);

            if (q.Count() > 0)
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 获取指定条件的T_FB_REPAYAPPLYDETAIL信息
        /// </summary>        
        /// <param name="strFilter">查询语句</param>
        /// <param name="objArgs">查询参数集合</param>
        /// <returns>返回T_FB_REPAYAPPLYDETAIL信息</returns>
        public T_FB_REPAYAPPLYDETAIL GetRepayApplyDetailRdByMultSearch(string strFilter, params object[] objArgs)
        {
            var q = from v in GetObjects().Include("T_FB_REPAYAPPLYMASTER").Include("T_FB_BORROWAPPLYDETAIL").Include("T_FB_SUBJECT")
                    select v;

            if (objArgs.Count() > 0 && !string.IsNullOrEmpty(strFilter))
            {
                q = q.Where(strFilter, objArgs);
            }

            return q.First();
        }

        /// <summary>
        /// 获取指定条件的T_FB_REPAYAPPLYDETAIL信息
        /// </summary>        
        /// <param name="strOrderBy">排序字段</param>
        /// <param name="strFilter">查询语句</param>
        /// <param name="objArgs">查询参数集合</param>
        /// <returns>返回T_FB_REPAYAPPLYDETAIL信息</returns>
        public IQueryable< T_FB_REPAYAPPLYDETAIL > GetRepayApplyDetailRdListByMultSearch(string strOrderBy, string strFilter, params object[] objArgs)
        {
            var q = from v in GetObjects()
                    select v;

            if (objArgs.Count() > 0 && !string.IsNullOrEmpty(strFilter))
            {
                q = q.Where(strFilter, objArgs);
            }


            return q.OrderBy(strOrderBy);
        }
    }
}

