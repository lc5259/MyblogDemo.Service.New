using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Blog.Service.New.Core.Entities
{
    [Table("link")]
    public class Link : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember, Key]
        public string id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Description("名称")]
        public string name { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [DataMember, Column, Description("链接地址")]
        public string link_url { get; set; }

        /// <summary>
        /// 链接类型
        /// </summary>
        [DataMember, Column, Description("链接类型")]
        public string link_type { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        [DataMember, Column, Description("摘要")]
        public string brief { get; set; }
    }
}
