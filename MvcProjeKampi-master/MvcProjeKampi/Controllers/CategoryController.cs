using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);              
        }

        // ATTRİBUTE İŞLEMLERİ sayfa yüklediğinde addcategory actionunda hppget devreye giriyor.
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        // sayfada bir şey post edildiğinde, butona basıldığında çalışacak metodu belirliyorum.
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAddBl(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if(results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

            //yani diyorumki ekleme işlemi yapıldıktan sonra beni getcategorylist
            //metoduma  yönlendir diyorum.
        }
    }
}