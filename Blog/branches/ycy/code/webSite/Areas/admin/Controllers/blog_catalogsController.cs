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
    public class blog_catalogsController : Controller
    {
        //
        // GET: /admin/blog_catalogs/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Select(Catalog model)
        {
            model.Search();
            //ajax请求是返回局部视图
            if (Request.IsAjaxRequest())
                return PartialView("_showData", model);
            return View(model);
        }
        public ActionResult CatalogDel(int id)
        {
            using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
            {
                var odlModel = dbContext.Catalogs.FirstOrDefault(m => m.Id == id);
                DbEntityEntry entry = dbContext.Entry(odlModel);
                entry.State = EntityState.Deleted;
                int res = dbContext.SaveChanges();
                if (res > 0)
                {
                    return Content("删除成功");
                }
                else
                {
                    return Content("删除失败");
                }
            }
        }

	}
}