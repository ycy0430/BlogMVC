using web.App_Code;
using web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            using (var blogDbContext = new BlogDbContext())
            {
                if (blogDbContext.Database.CreateIfNotExists())
                {
                    //数据库因为不存在然后重新创建了
                    //我们在这里就可以实现数据库的初始化
                    for (int i = 0; i < 10; i++)
                    {
                        var catalog = new Catalog();
                        catalog.AddTime = DateTime.Now;
                        catalog.Name = "分类" + i;
                        catalog.Status = true;
                        int res = 0;
                        blogDbContext.Catalogs.Add(catalog);
                        res = blogDbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
