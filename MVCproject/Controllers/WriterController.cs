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
    public class WriterController : Controller
    {
        //BusinessLayer da bulunan WriterManager sınıfımızı çağırıyoruz
        WriterManager wm = new WriterManager(new EFWriterDal());
        //WriterValidator category'in kurallarını tutuyor.
        //WriterValidator dan bir nesne türetiyoruz.
        WriterValidator writerValidator = new WriterValidator();

        public ActionResult Index()
        {
            //Yazar değer adında bir değişken oluşturduk.
            //Listeleme işlemi.
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }

        //Sayfa yüklendikten sonra [HttpGet] çalışacak.
        //Aynı isimli ActionResult ın üzerinde çalışacak.
        [HttpGet]
        public ActionResult AddWriter()
        {
            //Sayfayı geri göndürür.
            return View();
        }

        //Yeni kategori eklemek için kullanacağımız metod.
        //Kategori ekleme işleminde üzerinde çalıştığımız entitiden türetilmiş bir parametre göndermemiz gerekiyor.
        //Sayfada bir butona tıkladığımız zaman [HttpPost] çalışacak.
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {

            //Validate() geçerliliği kontrol eder.
            //results isminde bir ValidationResult değişkeni oluşturduk.
            //results WriterValidator dan değerlerle kontrolünü(Validate) yapıyoruz.
            ValidationResult results = writerValidator.Validate(p);

            //Eğerki results değeri doğrulanmışsa ekleme işlemi gerçekleşir.
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                //Ekleme işlemini gerçekleştikten sonra bizi tanımlamış olduğumuz GetCategoryList metoduna yönlendir.
                return RedirectToAction("Index");
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

        //Sayfa yüklrndiği zaman çalışacak.[HttpGet]
        //Updata işlemi için iki adım var. Birincisi güncellenecek bilgilerin güncelleme sayfasına taşınması. İkincisi güncelleme işleminin yapılması.
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            //id değişkeninden parametreden değerine göre ilgili satırın kayıtlarını CategoryValue isimli değişkene atadık.
            var WriterValue = wm.GetByID(id);
            return View(WriterValue);
        }

        //Writer sınfından p parametresi.
        //Writer sınıfında p parametresi türetiyoruz.
        //Siteyle etkileşime geçince post metodu çalışır.
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {

            //Validate() geçerliliği kontrol eder.
            //results isminde bir ValidationResult değişkeni oluşturduk.
            //results WriterValidator dan değerlerle kontrolünü(Validate) yapıyoruz.
            ValidationResult results = writerValidator.Validate(p);

            //Eğerki results değeri doğrulanmışsa ekleme işlemi gerçekleşir.
            if (results.IsValid)
            {
                //p den gelen değeri güncelliyoruz.
                wm.WriterUpdate(p);
                //Ekleme işlemini gerçekleştikten sonra bizi tanımlamış olduğumuz GetCategoryList metoduna yönlendir.
                return RedirectToAction("Index");
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