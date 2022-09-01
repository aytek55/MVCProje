using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        //Context c = new Context();  : ezilen 
        public ActionResult GetAllContent(string p)
        {
            p = "";
            // arama kutusu.           
            //var values = from x in c.Contents select x; : ezilen solid
            //x gönderdiğim değeri karşılayan şey.
            // if ile p değeri null değilse ya da boş değilse istediklerimi yap diyorum
            // p marametresi boş ya da null değilse values değişkenine atayarak getir. aksi halde values in tüm değerlerini getir.
            //if(!string.IsNullOrEmpty(p))
            //{
            //    values = values.Where(y => y.ContentValue.Contains(p)); : ezilen solid
            //}
            //var values = c.Contents.ToList();            ;                        
            var values = cm.GetList(p);                
           

            return View(values);
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}