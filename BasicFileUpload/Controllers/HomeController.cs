using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicFileUpload.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(HttpPostedFileBase file, int productid)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            //veritabanı kayıt işelmini yap
            //Product => productid, image = filename
            //product nesnesini veritabanına kayıt et.
            //<img src ="/upload/@image"

            if (file != null && file.ContentLength > 0)
            {
                var extensition = Path.GetExtension(file.FileName);

                         if (extensition ==".jpg" || extensition == ".png")
                         {
                             var folder = Server.MapPath("~/upload");
                             var randomfilename = Path.GetRandomFileName();
                             var filename = Path.ChangeExtension(randomfilename, ".jpg");

                             var path = Path.Combine(folder, filename);

                             //  var filename = Path.GetFileName(file.FileName);
                             //  var path = Path.Combine(folder ,filename);
                                    
                             file.SaveAs(path);
                         }
            else
            {
                ViewData["message"] = "Resim dosyası seçiniz";
            }
        }
            else
            {
                ViewData["message"] = "Bir dosya seçiniz";
            }
                return View();
        }
    }
}