using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCproject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            // Context sınıfında bir c nesnesi türetmiş olduk.
            Context c = new Context();
            // sisteme bir admin üzerinden giriş yaptıracağımız için  FirstOrDefault kullanıyoruz. FirstOrDefault geriye sadece bir tane değer döndürme işlemlerinde kullanılır.
            var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);

            if (adminUserInfo != null) 
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName,false); //Form içerisine yetkili tanımlıyoruz. Çerezlerini ayarlıyoruz. Yani sisteme girecek olan kişinin bilgilerini hazırlıyoruz. SetAuthCookie ile yetkili tanımlıyoruz. Parantez içerine form yetikisi sisteme girecek olan kulllanıcının bilgisini [adminUserInfo.AdminUserName] şeklinde alıyoruz. Ve yanına kalıcı cookie oluşmasının istemedğimiz için [false] veriyoruz.
                Session["AdminUserName"] = adminUserInfo.AdminUserName; // Oturum yönetimi Session içerisine sisteme giriş yapacak olan kişinin mail adresini veriyoruz.
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            // Context sınıfında bir c nesnesi türetmiş olduk.
            Context c = new Context();
            // sisteme bir admin üzerinden giriş yaptıracağımız için  FirstOrDefault kullanıyoruz. FirstOrDefault geriye sadece bir tane değer döndürme işlemlerinde kullanılır.
            var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false); //Form içerisine yetkili tanımlıyoruz. Çerezlerini ayarlıyoruz. Yani sisteme girecek olan kişinin bilgilerini hazırlıyoruz. SetAuthCookie ile yetkili tanımlıyoruz. Parantez içerine form yetikisi sisteme girecek olan kulllanıcının bilgisini [adminUserInfo.AdminUserName] şeklinde alıyoruz. Ve yanına kalıcı cookie oluşmasının istemedğimiz için [false] veriyoruz.
                Session["WriterMail"] = writerUserInfo.WriterMail; // Oturum yönetimi Session içerisine sisteme giriş yapacak olan kişinin mail adresini veriyoruz.
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }

        }

        public ActionResult LogOut()
        {

            //Oturumu sonlandırır.
            FormsAuthentication.SignOut();
            Session.Abandon();

            //Çıkış yaptıktan sonra başlıklar bölümüne yönledirir.
            return RedirectToAction("HomePage", "Home");
        }

    }
}