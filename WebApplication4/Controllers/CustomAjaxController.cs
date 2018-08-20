using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class CustomAjaxController : Controller
    {
        // GET: CustomAjax
        public ActionResult Index()
        {
            return View(comments);
        }

        public ActionResult PrivacyPolicy()
        {
            if(Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
            
        }

        private static List<string> comments = new List<string>();

        [HttpPost]
        public ActionResult AddComment(string comment)
        {
           // throw new Exception("My Errror");

            comments.Add(comment);

            if (Request.IsAjaxRequest())
            {
                ViewBag.Comment = comments;
                return PartialView("AddComment", comment);
            }
            else
                return RedirectToAction("Index");
        }
    }
}