using Blog.Service.New.Core.Entities.Base;
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
    [Table("draft")]
    public partial class Draft : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember,Key]
        //[PrimaryColumn(primaryType: PrimaryType.GUIDNumber)]
        public string id { get; set; }

        /// <summary>
        /// 博客id
        /// </summary>
        [DataMember, Description("博客id")]
        public string postid { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [DataMember, Description("标题")]
        public string content { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember, Description("标题")]
        public string title { get; set; }
    }
}
