using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.New.Core.Entities
{
    [Table("recommend_info")]
    public class RecommendInfo : BaseEntity
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
        /// 链接地址
        /// </summary>
        [DataMember, Column, Description("链接地址")]
        public string url { get; set; }

        /// <summary>
        /// 推荐类型
        /// </summary>
        [DataMember, Column, Description("推荐类型")]
        public string recommend_type { get; set; }

        /// <summary>
        /// 推荐类型
        /// </summary>
        [DataMember, Column, Description("推荐类型")]
        public string recommend_type_name { get; set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        [DataMember, Column, Description("阅读次数")]
        public int? reading_times { get; set; }

    }
}
