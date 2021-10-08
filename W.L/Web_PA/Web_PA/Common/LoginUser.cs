using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_PA.Common
{
    [Serializable]
    public class LoginUser
    {
        public int UserID { set; get; }
        public string UserName { set; get; }
        public int? GroupID { set; get; }
    }
}