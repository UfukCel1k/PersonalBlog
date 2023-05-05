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

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
    
        CategoryValidator categoryValidator = new CategoryValidator();


        [Authorize(Roles = "B")] 
        public ActionResult Index()
        {
            var Categorvalues = cm.GetList();
            return View(Categorvalues);
        }

        
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
      
            ValidationResult results = categoryValidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("Index");
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

        public ActionResult DeleteCategory(int id)
        {
            var CategoryValue = cm.GetByID(id);
            cm.CategoryDelete(CategoryValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var CategoryValue = cm.GetByID(id);
            return View(CategoryValue);
        }

      
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            ValidationResult results = categoryValidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryUpdate(p);
                return RedirectToAction("Index");
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