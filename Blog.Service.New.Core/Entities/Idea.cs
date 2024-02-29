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
    [Table("idea")]
    public partial class Idea : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember, Key]
        public string id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Description("名称")]
        public string name { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [DataMember, Description("内容")]
        public string content { get; set; }
    }
}
