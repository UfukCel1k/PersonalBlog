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

        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListBox(p);
            return View(messagelist);
        }

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

            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToLongDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}