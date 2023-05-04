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
    public class AdminCategoryController : Controller
    {
        //Admin sayfasındaki kategori bölümüne sql tablolarını getirme işlemi için AdminCategoryController gitmeliyiz.
        //
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        //CategoryValidator category'in kurallarını tutuyor.
        //CategoryValidator dan bir nesne türetiyoruz.
        CategoryValidator categoryValidator = new CategoryValidator();


        [Authorize(Roles = "B")] // Eğer kullanıcı sisteme giriş yapmadığı sürece bu kısmını göremicek.
        public ActionResult Index()
        {
            //Listeleme işlemi
            var Categorvalues = cm.GetList();
            return View(Categorvalues);
        }

        //Sayfa yüklendikten sonra [HttpGet] çalışacak.
        //Aynı isimli ActionResult ın üzerinde çalışacak.
        [HttpGet]
        public ActionResult AddCategory()
        {
            //Sayfayı geri göndürür.
            return View();
        }

        //Yeni kategori eklemek için kullanacağımız metod.
        //Kategori ekleme işleminde üzerinde çalıştığımız entitiden türetilmiş bir parametre göndermemiz gerekiyor.
        //Sayfada bir butona tıkladığımız zaman [HttpPost] çalışacak.
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //Validate() geçerliliği kontrol eder.
            //results isminde bir ValidationResult değişkeni oluşturduk.
            //results CategoryValidator dan değerlerle kontrolünü(Validate) yapıyoruz.
            ValidationResult results = categoryValidator.Validate(p);

            //Eğerki results değeri doğrulanmışsa ekleme işlemi gerçekleşir.
            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                //Ekleme işlemini gerçekleştikten sonra bizi tanımlamış olduğumuz GetCategoryList metoduna yönlendir.
                return RedirectToAction("Index");
            }
            else
            {
                //Hata mesajlarını tutacağımız diziyi oluşturuyoruz.
                //results dan gelen Errors lardan bir döngü oluşturucak
                foreach (var item in results.Errors)
                {
                    //Modelin durumuna hataları ekle(önce ilgili property nin ismi), (hatanın kendisi)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        //Kategori silme işlemi için yazdığımız metod
        //Dışarıdan bir id parametresi alıcak.
        public ActionResult DeleteCategory(int id)
        {
            //GetByID id'ye göre getirmemize yarıyorç
            var CategoryValue = cm.GetByID(id);
            //CategoryManager deki CategoryDelete parantez içerine CategoryValue dan gelen değer silecek.
            cm.CategoryDelete(CategoryValue);
            return RedirectToAction("Index");
        }

        //Sayfa yüklrndiği zaman çalışacak.[HttpGet]
        //Updata işlemi için iki adım var. Birincisi güncellenecek bilgilerin güncelleme sayfasına taşınması. İkincisi güncelleme işleminin yapılması.
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            //id değişkeninden parametreden değerine göre ilgili satırın kayıtlarını CategoryValue isimli değişkene atadık.
            var CategoryValue = cm.GetByID(id);
            return View(CategoryValue);
        }

        //Category sınfından p parametresi.
        //Category sınıfında p parametresi türetiyoruz.
        //Siteyle etkileşime geçince post metodu çalışır.
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            //Validate() geçerliliği kontrol eder.
            //results isminde bir ValidationResult değişkeni oluşturduk.
            //results CategoryValidator dan değerlerle kontrolünü(Validate) yapıyoruz.
            ValidationResult results = categoryValidator.Validate(p);

            if (results.IsValid)
            {
                //p den gelen değeri güncelliyoruz.
                cm.CategoryUpdate(p);
                //Ekleme işlemini gerçekleştikten sonra bizi tanımlamış olduğumuz GetCategoryList metoduna yönlendir.
                return RedirectToAction("Index");
            }
            else
            {
                //Hata mesajlarını tutacağımız diziyi oluşturuyoruz.
                //results dan gelen Errors lardan bir döngü oluşturucak
                foreach (var item in results.Errors)
                {
                    //Modelin durumuna hataları ekle(önce ilgili property nin ismi), (hatanın kendisi)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}