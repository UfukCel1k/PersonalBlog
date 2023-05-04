using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Controllers
{

    //Vitrin bölümü tüm başlıklar bu sayfada gözükür.
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            //Database deki verileri hm ye eşitliyor ve GetList metoduyla çağırıyoruz.
            var headinglist = hm.GetList();
            return View(headinglist);
        }

        public PartialViewResult Index(int id = 0)
        {
            //Bütün değerleri çekiyoruz.
            var contentlist = cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}