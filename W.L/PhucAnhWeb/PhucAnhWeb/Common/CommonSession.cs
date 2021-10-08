using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhucAnhWeb.Common
{
    public class CommonSession
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string CART_SESSION = "CART_SESSION";

        public static string CurrentCulture { set; get; }
    }
}