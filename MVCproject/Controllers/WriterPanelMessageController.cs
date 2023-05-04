using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
         

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListBox(p);
            return View(messagelist);  
        }


        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messagevalues = mm.GetListSendBox(p);
            return View(messagevalues);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        //Mesaj içeriğini id'ye göre getitiyoruz.
        public ActionResult GetContactMessage(int id)
        {
            var messagevalues = mm.GetByID(id);
            return View(messagevalues);
        }

        public ActionResult GetSendBoxtDetails(int id)
        {
            var messagevalues = mm.GetByID(id);
            return View(messagevalues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];

            ValidationResult results = messagevalidator.Validate(p);

            //Eğerki results değeri doğrulanmışsa ekleme işlemi gerçekleşir.
            if (results.IsValid)
            {
                p.SenderMail =sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToLongDateString());
                mm.MessageAdd(p);
                //Ekleme işlemini gerçekleştikten sonra bizi tanımlamış olduğumuz SendBox metoduna yönlendir.
                return RedirectToAction("SendBox");
            }
            else
            {
                //Hata mesajlarını tutacağımız diziyi oluşturuyoruz.
                //results dan gelen Errors lardan bir döngü oluşturucak
                foreach (var item in results.Errors)
                {
                    //Modelin durumuna hataları ekle(property nin ismi), (hatanın kendisi)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}