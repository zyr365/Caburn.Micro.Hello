using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class UserInformation
    {
        public UserInformation()
        {
            UserName = "zls20210502";
            Password = "12345678";
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }


    }
}
