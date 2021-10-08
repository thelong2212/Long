using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhucAnhWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Loai-Danh-Muc-San-Pham",
                url: "productCategory/{ID}",
                new { controller = "DanhMucSanPham", action = "DMTheoLoai" }
             );

            routes.MapRoute(
                name: "Danh-Muc-San-Pham",
                url: "Category-product/{ID}",
                new { controller = "DanhMucSanPham", action = "DanhMucSanPham" }
             );

            routes.MapRoute(
                  name: "PhanDanhMucSanPham",
                  url: "productCategoryClass/{ID}",
                  new { controller = "DanhMucSanPham", action = "DMTheoPhanLoai" }
              );

            routes.MapRoute(
                 name: "Danh-Muc-San-Pham-Theo-Ten",
                 url: "productCategoryName/{ID}",
                 new { controller = "DanhMucSanPham", action = "DMTheoTen" }
             );
            routes.MapRoute(
                name: "ChiTietSanPham",
                url: "detailProduct/{id}",
                new { controller = "ChiTietSanPham", action = "Index" }
            );

            routes.MapRoute(
                name: "Register",
                url: "register",
                new { controller = "Account", action = "Register" }
             );

            routes.MapRoute(
               name: "LogOff",
               url: "logOff",
               new { controller = "Account", action = "LogOff" }
            );

            routes.MapRoute(
               name: "Login",
               url: "login",
               new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
              name: "RemoveProduct",
              url: "remove/{id}",
              new { controller = "GioHang", action = "RemoveProduct" }
          );
            routes.MapRoute(
               name: "RemoveAllProduct",
               url: "removeAll/{id}",
               new { controller = "GioHang", action = "RemoveAllProduct" }
           );
            routes.MapRoute(
               name: "GioHang",
               url: "giohang",
               new { controller = "GioHang", action = "gioHang" }
           );
            routes.MapRoute(
               name: "AddItem",
               url: "add/{id}",
               new { controller = "GioHang", action = "AddItem" }
            );

            routes.MapRoute(
              name: "ThanhToanHoaDon",
              url: "thanhtoan",
              new { controller = "ThanhToanHoaDon", action = "Index" }
           );

            routes.MapRoute(
              name: "XacNhanThanhToan",
              url: "xac-nhan-thanh-toan",
              new { controller = "ThanhToanHoaDon", action = "XacNhanThanhToan" }
           );
            routes.MapRoute(
              name: "SearchProduct",
              url: "tim-kiem",
              new { controller = "Home", action = "SearchProduct" }
           );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
