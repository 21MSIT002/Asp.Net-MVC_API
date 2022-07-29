using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using studentApi.Models;

namespace studentApi.Controllers
{
    public class MVCController : Controller
    {
        DBstudapiEntities ds = new DBstudapiEntities();
        
        // GET: MVC
       
        public ActionResult  View()
        {
            return View(ds.STables.ToList());
        }
      
    }
}