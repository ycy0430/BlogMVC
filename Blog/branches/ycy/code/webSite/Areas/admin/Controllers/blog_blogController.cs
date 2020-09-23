using web.App_Code;
using web.Models;
using web.ViewsModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Areas.admin.Controllers
{

    public class blog_blogController : Controller
    {

        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Config()
        {
            var model = new Tool().DeSerialize<BlogConfig>();
            return View(model);
            //return View();
        }

        [HttpPost]
        public ActionResult Config(BlogConfig model)
        {
            new Tool().Serialize<BlogConfig>(model);
            return View();
        }

        [HttpGet]
        public ActionResult CatalogAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CatalogAdd(CatalogAdd model)
        {
            if (ModelState.IsValid)
            {
                var catalog = new Catalog();
                catalog.AddTime = DateTime.Now;
                catalog.Name = model.Name;
                catalog.Status = true;
                int res = 0;
                using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
                {
                    dbContext.Catalogs.Add(catalog);
                    res = dbContext.SaveChanges();//才是真正保存到数据库
                }
                if (res > 0)
                {
                    return Content("添加成功");
                }
                else
                {
                    return Content("添加失败");
                }
            }
            else
            {
                return Content("验证失败");
            }
        }








    }
}