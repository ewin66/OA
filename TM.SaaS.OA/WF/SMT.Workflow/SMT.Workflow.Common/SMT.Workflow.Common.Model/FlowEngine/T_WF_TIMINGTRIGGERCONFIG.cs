﻿/*---------------------------------------------------------------------  
	 * 版　权：Copyright ©   2011    
	 * 文件名：T_WF_TIMINGTRIGGERCONFIG.cs  
	 * 创建者： 亢晓方
	 * 创建日期：2011/12/12 10:33:57   
	 * CLR版本： 4.0.30319.239  
	 * 命名空间：SMT.Workflow.Common.Model.FlowEngine 
	 * 模块名称：
	 * 描　　述： 	 
* ---------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SMT.Workflow.Common.Model.FlowEngine
{
    /// <summary>
    /// [定时触发消息定义表（有配置界面操作）]
    /// </summary>
    [DataContract]
    public class T_WF_TIMINGTRIGGERCONFIG
    {
        /// <summary>
        /// 定时触发配置ID
        /// </summary>
        [DataMember]
        public string TIMINGCONFIGID { get; set; }

        /// <summary>
        /// 接收人名称
        /// </summary>
        [DataMember]
        public string RECEIVERNAME { get; set; }

        /// <summary>
        /// 接受消息
        /// </summary>
        [DataMember]
        public string MESSAGEBODY { get; set; }

        /// <summary>
        /// 消息链接
        /// </summary>
        [DataMember]
        public string MESSAGEURL { get; set; }

        /// <summary>
        /// 触发器状态
        /// </summary>
        [DataMember]
        public decimal TRIGGERSTATUS { get; set; }

        /// <summary>
        /// 触发类型
        /// </summary>
        [DataMember]
        public string TRIGGERTYPE { get; set; }

        /// <summary>
        /// 触发描述
        /// </summary>
        [DataMember]
        public string TRIGGERDESCRIPTION { get; set; }

        /// <summary>
        /// 接口类型（引擎，定时接口）
        /// </summary>
        [DataMember]
        public string CONTRACTTYPE { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string CREATEUSERNAME { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        [DataMember]
        public string CREATEUSERID { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        public DateTime CREATEDATETIME { get; set; }
     

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string REMARK { get; set; }

   

        /// <summary>
        /// 定时触发名称
        /// </summary>
        [DataMember]
        public string TRIGGERNAME { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        [DataMember]
        public string COMPANYID { get; set; }

        /// <summary>
        /// 系统代码
        /// </summary>
        [DataMember]
        public string SYSTEMCODE { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        [DataMember]
        public string SYSTEMNAME { get; set; }

        /// <summary>
        /// 模块代码
        /// </summary>
        [DataMember]
        public string MODELCODE { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        [DataMember]
        public string MODELNAME { get; set; }

        /// <summary>
        /// 触发活动类型（1、短信活动 2、服务活动）
        /// </summary>
        [DataMember]
        public decimal TRIGGERACTIVITYTYPE { get; set; }

        /// <summary>
        /// 触发时间
        /// </summary>
        [DataMember]
        public DateTime TRIGGERTIME { get; set; }

        /// <summary>
        /// 触发周期的日期
        /// </summary>
        [DataMember]
        public decimal TRIGGERDATE { get; set; }

        /// <summary>
        /// 触发周期
        /// </summary>
        [DataMember]
        public decimal TRIGGERROUND { get; set; }

        /// <summary>
        /// WCF的URL
        /// </summary>
        [DataMember]
        public string WCFURL { get; set; }

        /// <summary>
        /// 所调方法名称
        /// </summary>
        [DataMember]
        public string FUNCTIONNAME { get; set; }

        /// <summary>
        /// 方法参数
        /// </summary>
        [DataMember]
        public string FUNCTIONPARAMTER { get; set; }

        /// <summary>
        /// 参数分解符
        /// </summary>
        [DataMember]
        public string PAMETERSPLITCHAR { get; set; }

        /// <summary>
        /// WCF绑定的契约
        /// </summary>
        [DataMember]
        public string WCFBINDINGCONTRACT { get; set; }

        /// <summary>
        /// 接收人ID
        /// </summary>
        [DataMember]
        public string RECEIVERUSERID { get; set; }

        /// <summary>
        /// 接受人角色
        /// </summary>
        [DataMember]
        public string RECEIVEROLE { get; set; }

    }
}
