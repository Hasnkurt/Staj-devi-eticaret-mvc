using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using esitem.Entity;
using esitem.Models;
using esitem.Identity;


namespace esitem.Controllers
{
    public class Adminlogin : Controller
    {
        DataContext db = new DataContext();
        // GET: Adminlogin
        public ActionResult Index()
        {
            return View();
        }

      

      
    }
}