using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sessions.Entites;
using Sessions.ExtensionMethots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessions.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            //String and int
            HttpContext.Session.SetInt32("ProductCount", 12);
            HttpContext.Session.SetString("ProductName", "PC");

            //Extension string and int, Object Sesion
            HttpContext.Session.SetObject("obj", new Product { Id = 1, ProductCount = 11, ProductName = "Keyboard" });

            return "session created";
        }
        public string Index2()
        {
            return string.Format("Product Name={0},Product Count={1},ObjectListProductName={2},ObjectListProductCount={3}", 
                HttpContext.Session.GetString("ProductName"), 
                HttpContext.Session.GetInt32("ProductCount"),
                HttpContext.Session.GetObject<Product>("obj").ProductName,
                HttpContext.Session.GetObject<Product>("obj").ProductCount
                );
        }
  
    }
}
