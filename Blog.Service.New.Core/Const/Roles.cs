using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.New.Core.Const
{
    //密封类，防止被继承
    public sealed class Roles
    {
        /// <summary>
        /// 系统管理员
        /// </summary>
        public const string SystemManage = "00000000-0000-0000-0000-000000000000";

        /// <summary>
        /// 系统用户
        /// </summary>
        public const string System = "111111111-11111-1111-1111-111111111111";

        /// <summary>
        /// 访客
        /// </summary>

        public const string Guest = "222222222-22222-2222-2222-222222222222";

        /// <summary>
        /// 普通用户
        /// </summary>
        public const string User = "333333333-33333-3333-3333-333333333333";
    }
}
