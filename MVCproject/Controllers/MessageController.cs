using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        //Mesajları listeliyoruz.
        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListBox(p);
            return View(messagelist);
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

        //Gönderilen mesajları listeliyoruz.
        public ActionResult SendBox(string p)
        {
            var messagevalues = mm.GetListSendBox(p);
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
            ValidationResult results = messagevalidator.Validate(p);

            //Eğerki results değeri doğrulanmışsa ekleme işlemi gerçekleşir.
            if (results.IsValid)
            {
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