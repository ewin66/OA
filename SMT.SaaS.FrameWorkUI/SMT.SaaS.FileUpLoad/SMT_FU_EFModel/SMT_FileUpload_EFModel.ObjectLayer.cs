//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4952
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// 原始文件名: SMT_FileUpload_EFModel.ObjectLayer.cs
// 生成日期: 2010/12/15 12:35:32
namespace SMT_FileUpload_EFModel
{
    
    /// <summary>
    /// 架构中不存在 SMT_FileUpload_EFModelContext 的注释。
    /// </summary>
    public partial class SMT_FileUpload_EFModelContext : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// 请使用应用程序配置文件的“SMT_FileUpload_EFModelContext”部分中的连接字符串初始化新 SMT_FileUpload_EFModelContext 对象。
        /// </summary>
        public SMT_FileUpload_EFModelContext() : 
                base("name=SMT_FileUpload_EFModelContext", "SMT_FileUpload_EFModelContext")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// 初始化新的 SMT_FileUpload_EFModelContext 对象。
        /// </summary>
        public SMT_FileUpload_EFModelContext(string connectionString) : 
                base(connectionString, "SMT_FileUpload_EFModelContext")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// 初始化新的 SMT_FileUpload_EFModelContext 对象。
        /// </summary>
        public SMT_FileUpload_EFModelContext(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "SMT_FileUpload_EFModelContext")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// 架构中不存在 SMT_FILELIST 的注释。
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<SMT_FILELIST> SMT_FILELIST
        {
            get
            {
                if ((this._SMT_FILELIST == null))
                {
                    this._SMT_FILELIST = base.CreateQuery<SMT_FILELIST>("[SMT_FILELIST]");
                }
                return this._SMT_FILELIST;
            }
        }
        private global::System.Data.Objects.ObjectQuery<SMT_FILELIST> _SMT_FILELIST;
        /// <summary>
        /// 架构中不存在 SMT_FILELIST 的注释。
        /// </summary>
        public void AddToSMT_FILELIST(SMT_FILELIST sMT_FILELIST)
        {
            base.AddObject("SMT_FILELIST", sMT_FILELIST);
        }
    }
    /// <summary>
    /// 架构中不存在 SMT_FileUpload_EFModel.SMT_FILELIST 的注释。
    /// </summary>
    /// <KeyProperties>
    /// SMTFILELISTID
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="SMT_FileUpload_EFModel", Name="SMT_FILELIST")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class SMT_FILELIST : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// 创建新的 SMT_FILELIST 对象。
        /// </summary>
        /// <param name="sMTFILELISTID">SMTFILELISTID 的初始值。</param>
        /// <param name="fILENAME">FILENAME 的初始值。</param>
        public static SMT_FILELIST CreateSMT_FILELIST(string sMTFILELISTID, string fILENAME)
        {
            SMT_FILELIST sMT_FILELIST = new SMT_FILELIST();
            sMT_FILELIST.SMTFILELISTID = sMTFILELISTID;
            sMT_FILELIST.FILENAME = fILENAME;
            return sMT_FILELIST;
        }
        /// <summary>
        /// 架构中不存在属性 SMTFILELISTID 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string SMTFILELISTID
        {
            get
            {
                return this._SMTFILELISTID;
            }
            set
            {
                this.OnSMTFILELISTIDChanging(value);
                this.ReportPropertyChanging("SMTFILELISTID");
                this._SMTFILELISTID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("SMTFILELISTID");
                this.OnSMTFILELISTIDChanged();
            }
        }
        private string _SMTFILELISTID;
        partial void OnSMTFILELISTIDChanging(string value);
        partial void OnSMTFILELISTIDChanged();
        /// <summary>
        /// 架构中不存在属性 FILENAME 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string FILENAME
        {
            get
            {
                return this._FILENAME;
            }
            set
            {
                this.OnFILENAMEChanging(value);
                this.ReportPropertyChanging("FILENAME");
                this._FILENAME = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("FILENAME");
                this.OnFILENAMEChanged();
            }
        }
        private string _FILENAME;
        partial void OnFILENAMEChanging(string value);
        partial void OnFILENAMEChanged();
        /// <summary>
        /// 架构中不存在属性 FILETYPE 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string FILETYPE
        {
            get
            {
                return this._FILETYPE;
            }
            set
            {
                this.OnFILETYPEChanging(value);
                this.ReportPropertyChanging("FILETYPE");
                this._FILETYPE = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("FILETYPE");
                this.OnFILETYPEChanged();
            }
        }
        private string _FILETYPE;
        partial void OnFILETYPEChanging(string value);
        partial void OnFILETYPEChanged();
        /// <summary>
        /// 架构中不存在属性 FILEURL 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string FILEURL
        {
            get
            {
                return this._FILEURL;
            }
            set
            {
                this.OnFILEURLChanging(value);
                this.ReportPropertyChanging("FILEURL");
                this._FILEURL = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("FILEURL");
                this.OnFILEURLChanged();
            }
        }
        private string _FILEURL;
        partial void OnFILEURLChanging(string value);
        partial void OnFILEURLChanged();
        /// <summary>
        /// 架构中不存在属性 COMPANYCODE 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string COMPANYCODE
        {
            get
            {
                return this._COMPANYCODE;
            }
            set
            {
                this.OnCOMPANYCODEChanging(value);
                this.ReportPropertyChanging("COMPANYCODE");
                this._COMPANYCODE = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COMPANYCODE");
                this.OnCOMPANYCODEChanged();
            }
        }
        private string _COMPANYCODE;
        partial void OnCOMPANYCODEChanging(string value);
        partial void OnCOMPANYCODEChanged();
        /// <summary>
        /// 架构中不存在属性 COMPANYNAME 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string COMPANYNAME
        {
            get
            {
                return this._COMPANYNAME;
            }
            set
            {
                this.OnCOMPANYNAMEChanging(value);
                this.ReportPropertyChanging("COMPANYNAME");
                this._COMPANYNAME = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COMPANYNAME");
                this.OnCOMPANYNAMEChanged();
            }
        }
        private string _COMPANYNAME;
        partial void OnCOMPANYNAMEChanging(string value);
        partial void OnCOMPANYNAMEChanged();
        /// <summary>
        /// 架构中不存在属性 SYSTEMCODE 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string SYSTEMCODE
        {
            get
            {
                return this._SYSTEMCODE;
            }
            set
            {
                this.OnSYSTEMCODEChanging(value);
                this.ReportPropertyChanging("SYSTEMCODE");
                this._SYSTEMCODE = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("SYSTEMCODE");
                this.OnSYSTEMCODEChanged();
            }
        }
        private string _SYSTEMCODE;
        partial void OnSYSTEMCODEChanging(string value);
        partial void OnSYSTEMCODEChanged();
        /// <summary>
        /// 架构中不存在属性 MODELCODE 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string MODELCODE
        {
            get
            {
                return this._MODELCODE;
            }
            set
            {
                this.OnMODELCODEChanging(value);
                this.ReportPropertyChanging("MODELCODE");
                this._MODELCODE = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("MODELCODE");
                this.OnMODELCODEChanged();
            }
        }
        private string _MODELCODE;
        partial void OnMODELCODEChanging(string value);
        partial void OnMODELCODEChanged();
        /// <summary>
        /// 架构中不存在属性 THUMBNAILURL 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string THUMBNAILURL
        {
            get
            {
                return this._THUMBNAILURL;
            }
            set
            {
                this.OnTHUMBNAILURLChanging(value);
                this.ReportPropertyChanging("THUMBNAILURL");
                this._THUMBNAILURL = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("THUMBNAILURL");
                this.OnTHUMBNAILURLChanged();
            }
        }
        private string _THUMBNAILURL;
        partial void OnTHUMBNAILURLChanging(string value);
        partial void OnTHUMBNAILURLChanged();
        /// <summary>
        /// 架构中不存在属性 INDEXL 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<decimal> INDEXL
        {
            get
            {
                return this._INDEXL;
            }
            set
            {
                this.OnINDEXLChanging(value);
                this.ReportPropertyChanging("INDEXL");
                this._INDEXL = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("INDEXL");
                this.OnINDEXLChanged();
            }
        }
        private global::System.Nullable<decimal> _INDEXL;
        partial void OnINDEXLChanging(global::System.Nullable<decimal> value);
        partial void OnINDEXLChanged();
        /// <summary>
        /// 架构中不存在属性 REMARK 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string REMARK
        {
            get
            {
                return this._REMARK;
            }
            set
            {
                this.OnREMARKChanging(value);
                this.ReportPropertyChanging("REMARK");
                this._REMARK = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("REMARK");
                this.OnREMARKChanged();
            }
        }
        private string _REMARK;
        partial void OnREMARKChanging(string value);
        partial void OnREMARKChanged();
        /// <summary>
        /// 架构中不存在属性 CREATETIME 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> CREATETIME
        {
            get
            {
                return this._CREATETIME;
            }
            set
            {
                this.OnCREATETIMEChanging(value);
                this.ReportPropertyChanging("CREATETIME");
                this._CREATETIME = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("CREATETIME");
                this.OnCREATETIMEChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _CREATETIME;
        partial void OnCREATETIMEChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnCREATETIMEChanged();
        /// <summary>
        /// 架构中不存在属性 CREATENAME 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string CREATENAME
        {
            get
            {
                return this._CREATENAME;
            }
            set
            {
                this.OnCREATENAMEChanging(value);
                this.ReportPropertyChanging("CREATENAME");
                this._CREATENAME = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("CREATENAME");
                this.OnCREATENAMEChanged();
            }
        }
        private string _CREATENAME;
        partial void OnCREATENAMEChanging(string value);
        partial void OnCREATENAMEChanged();
        /// <summary>
        /// 架构中不存在属性 UPDATETIME 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> UPDATETIME
        {
            get
            {
                return this._UPDATETIME;
            }
            set
            {
                this.OnUPDATETIMEChanging(value);
                this.ReportPropertyChanging("UPDATETIME");
                this._UPDATETIME = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("UPDATETIME");
                this.OnUPDATETIMEChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _UPDATETIME;
        partial void OnUPDATETIMEChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnUPDATETIMEChanged();
        /// <summary>
        /// 架构中不存在属性 UPDATENAME 的注释。
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string UPDATENAME
        {
            get
            {
                return this._UPDATENAME;
            }
            set
            {
                this.OnUPDATENAMEChanging(value);
                this.ReportPropertyChanging("UPDATENAME");
                this._UPDATENAME = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("UPDATENAME");
                this.OnUPDATENAMEChanged();
            }
        }
        private string _UPDATENAME;
        partial void OnUPDATENAMEChanging(string value);
        partial void OnUPDATENAMEChanged();
    }
}
