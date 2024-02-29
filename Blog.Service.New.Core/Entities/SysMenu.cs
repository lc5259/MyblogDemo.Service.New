﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Sixpence.Web.Module.SysMenu
{
    [Table("sys_menu")]
    public partial class SysMenu : BaseEntity
    {
        /// <summary>
        /// 实体id
        /// </summary>
        [DataMember,Key]
        public string id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Description("名称")]
        public string name { get; set; }

        /// <summary>
        /// 上级菜单
        /// </summary>
        [DataMember, Column, Description("上级菜单")]
        public string parentid { get; set; }

        /// <summary>
        /// 上级菜单
        /// </summary>
        [DataMember, Column, Description("上级菜单")]
        public string parentid_name { get; set; }

        /// <summary>
        /// 路由地址
        /// </summary>
        [DataMember, Column, Description("路由地址")]
        public string router { get; set; }

        /// <summary>
        /// 菜单索引
        /// </summary>
        [DataMember, Column, Description("菜单索引")]
        public int? menu_index { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember, Column, Description("状态")]
        public bool? statecode { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember, Column, Description("状态名称")]
        public string statecode_name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [DataMember, Column, Description("图标")]
        public string icon { get; set; }
    }
}