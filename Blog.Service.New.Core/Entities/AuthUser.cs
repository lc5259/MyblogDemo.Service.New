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
    [Table("auth_user")]
    //[KeyAttributes("请勿重复创建用户", "code")]
    public partial class AuthUser : BaseEntity //EntityBase 内置了Id
    {
        [Key, DataMember]
        public string id { get; set; }

        [ DataMember, Description("名称")]
        public string name { get; set; }

        [DataMember, Description("编码")]
        public string code { get; set; }

        [ DataMember, Description("密码")]
        public string password { get; set; }

        [DataMember, Description("角色权限id")]
        public string roleid { get; set; }

        [DataMember, Description("角色权限名")]
        public string roleid_name { get; set; }

        [DataMember, Description("用户id")]
        public string user_infoid { get; set; }

        [DataMember, Description("锁定")]
        public bool? is_lock { get; set; }

        [DataMember, Description("锁定")]
        public string is_lock_name { get; set; }

        [DataMember, Description("上次登录时间")]
        public DateTime? last_login_time { get; set; }

        [DataMember, Description("尝试登录次数")]
        public int? try_times { get; set; }
    }
}