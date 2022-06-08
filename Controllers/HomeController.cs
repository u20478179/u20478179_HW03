using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FileModel.Models;

namespace FileModel.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase Files)
        {
            if (Files != null && Files.ContentLength > 0)
            {
                var FileName = Path.GetFileName(Files.FileName);

                var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), FileName);

                Files.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Image()
        {
            ViewBag.Message = "Your Image page.";

            return View();
        }

        public ActionResult File()
        {
            ViewBag.Message = "Your File page.";

            return View();
        }

        public ActionResult Video()
        {
            ViewBag.Message = "Your Video page.";

            return View();
        }

        public ActionResult Download(string fileName)
        {

            string path = Server.MapPath("~/App_Data/uploads/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }
        public ActionResult Delete(string fileName)
        {
            string path = Server.MapPath("~/App_Data/uploads/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}