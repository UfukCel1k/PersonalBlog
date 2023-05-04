using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();

        public ActionResult MyContent(string p)
        {
            Context c = new Context();

            //p parametresinden gelen WriterMail değeri ile 
            p = (string)Session["WriterMail"];

            // Bizim dışardan gönderdiğimiz parametreye eşit olan mail adresi içerisinde id sini seç.
            var writeridinfo = c.Writers.Where(X => X.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);

        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            //p parametresinden gelen WriterMail değeri ile 
            string mail = (string)Session["WriterMail"];

            // Bizim dışardan gönderdiğimiz parametreye eşit olan mail adresi içerisinde id sini seç.
            var writeridinfo = c.Writers.Where(X => X.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();

            // Başlığa giriş yapıldığında anlık tarih bilgisinide verir.
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}