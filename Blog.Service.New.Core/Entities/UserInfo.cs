
using Blog.Service.New.Core.Entities.Base;
using Furion.DatabaseAccessor;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Blog.Service.New.Core.Entities
{
    [Table("user_info")]
    //[KeyAttributes("请勿重复创建用户", "code")]
    //[KeyAttributes("邮箱已被注册", "mailbox")]
    //[KeyAttributes("手机号码已被注册", "cellphone")]
    public partial class UserInfo : BaseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Key,DataMember]
        public string id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember,  Description("名称")]
        public string name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DataMember, Description("编码")]
        public string code { get; set; }

        [NotMapped]
        [DataMember]
        public string is_lock_name { get; set; }

        [NotMapped]
        [DataMember]
        public string password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember, Description("性别")]
        public int? gender { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember, Description("性别")]
        public string gender_name { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [DataMember, Description("真实姓名")]
        public string realname { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember, Description("邮箱")]
        public string mailbox { get; set; }

        /// <summary>
        /// 个人介绍
        /// </summary>
        [DataMember, Description("个人介绍")]
        public string introduction { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DataMember, Description("手机号码")]
        public string cellphone { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [DataMember, Description("头像")]
        public string avatar { get; set; }

        /// <summary>
        /// 生活照
        /// </summary>
        [DataMember, Description("生活照")]
        public string life_photo { get; set; }

        /// <summary>
        /// 角色权限id
        /// </summary>
        [DataMember, Description("角色权限id")]
        public string roleid { get; set; }

        /// <summary>
        /// Github ID
        /// </summary>
        [DataMember, Description("Github ID")]
        public string github_id { get; set; }

        /// <summary>
        /// Gitee ID
        /// </summary>
        [DataMember, Description("Gitee ID")]
        public string gitee_id { get; set; }

        /// <summary>
        /// 角色权限名
        /// </summary>
        [DataMember, Description("角色权限名")]
        public string roleid_name { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember, Description("启用")]
        public bool? statecode { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember, Description("启用")]
        public string statecode_name { get; set; }
    }
}
