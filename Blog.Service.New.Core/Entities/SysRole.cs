
using Blog.Service.New.Core.Entities.Base;
using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace Blog.Service.New.Core.Entities
{
    [Table("sys_role")]
    public partial class SysRole : BaseEntity //EntityBase 内置了Id
    {
        /// <summary>
        /// 实体id
        /// </summary>
        [Key,DataMember]
        public string id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember,  Description("名称")]
        public string name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember,  Description("描述")]
        public string description { get; set; }

        /// <summary>
        /// 是否基础角色
        /// </summary>
        [DataMember, Description("是否基础角色")]
        public bool? is_basic { get; set; }

        /// <summary>
        /// 是否基础角色
        /// </summary>
        [DataMember, Description("是否基础角色")]
        public string is_basic_name { get; set; }

        /// <summary>
        /// 继承角色
        /// </summary>
        [DataMember, Description("继承角色")]
        public string parent_roleid { get; set; }

        /// <summary>
        /// 继承角色
        /// </summary>
        [DataMember, Description("继承角色")]
        public string parent_roleid_name { get; set; }
    }
}

