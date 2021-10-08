using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhucAnh_done.Common
{
    public class CommonSession
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string CART_SESSION = "CART_SESSION";

        public static string CurrentCulture { set; get; }
    }
}