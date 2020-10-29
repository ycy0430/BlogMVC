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
using System.Collections;
using System.IO;
using System.Globalization;

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
        [ValidateInput(false)]

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
                    return Content(@"<script>alert('添加成功!');window.location.href=document.referrer;</script>");
                }
                else
                {
                    return Content(@"<script>alert('添加失败!');window.location.href=document.referrer;</script>");
                }
            }
            else
            {
                return Content(@"<script>alert('验证失败!');window.location.href=document.referrer;</script>");
            }
        }


                [ValidateInput(false)]

        public ActionResult BlogAdd()
        {
            using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
            {
                List<SelectListItem> listCatalog = dbContext.Catalogs.ToList().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList();
                ViewBag.catalogList = listCatalog;
                return View();
            }
        }


        [HttpPost]
        [ValidateInput(false)]

        public ActionResult BlogAdd(BlogAdd model)
        {
            if (ModelState.IsValid)
            {

                var b = new Blog();
                b.AddTime = DateTime.Now;
                b.Title = model.Title;
                b.catalogId = model.catalogId;
                b.Content = model.Content;
                b.Status = true;
                int res = 0;
                using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
                {
                    dbContext.Blogs.Add(b);
                    res = dbContext.SaveChanges();//才是真正保存到数据库
                }
                if (res > 0)
                {
                    return Content(@"<script>alert('添加成功!');window.location.href=document.referrer;</script>");
                }
                else
                {
                    return Content(@"<script>alert('添加失败!');window.location.href=document.referrer;</script>");
                }
            }
            else
            {
                return Content(@"<script>alert('验证不通过!');window.location.href=document.referrer;</script>");
            }
        }

        
        public ActionResult Upload()
        {
            //文件保存目录路径
            String savePath = "/attached/";
            //文件保存目录URL
            String saveUrl = "/attached/";
            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");
            //最大文件大小
            int maxSize = 1000000;
            HttpPostedFileBase imgFile = Request.Files["imgFile"];
            if (imgFile == null)
            {
                return Content("请选择文件。");
            }
            String dirPath = Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                return Content("上传目录不存在。");
            }
            String dirName = Request.QueryString["dir"];
            if (String.IsNullOrEmpty(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                return Content("目录名不正确。");
            }
            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();
            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                return Content("上传文件大小超过限制。");
            }
            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                return Content("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
            }
            //创建文件夹
            dirPath += dirName + "/";
            saveUrl += dirName + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "/";
            saveUrl += ymd + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String filePath = dirPath + newFileName;
            imgFile.SaveAs(filePath);
            String fileUrl = saveUrl + newFileName;
            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = fileUrl;
            return Json(hash);
        }




        [HttpGet]
        public ActionResult CatalogManage()
        {
            return View();
        }

        public JsonResult LoadCatalog()
        {
            using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
            {
                var list = dbContext.Catalogs.ToList().Select(m => new { Id = m.Id, Name = m.Name, AddTime = m.AddTime }).ToList();
                return Json(list);
            }
        }

        [HttpGet]
        public ActionResult CatalogModify(int id)
        {
            using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
            {
                var model = dbContext.Catalogs.FirstOrDefault(m => m.Id == id);
                CatalogModify cm = new ViewsModels.CatalogModify();
                cm.Id = model.Id;
                cm.Name = model.Name;
                return View(cm);
            }
        }

        [HttpPost]
        public ActionResult CatalogModify(CatalogModify model)
        {
            using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
            {

                var odlModel = dbContext.Catalogs.FirstOrDefault(m => m.Id == model.Id);
                odlModel.Name = model.Name;
                DbEntityEntry entry = dbContext.Entry(odlModel);
                entry.State = EntityState.Modified;
                int res = dbContext.SaveChanges();
                if (res > 0)
                {
                    return Content(@"<script>alert('修改成功!');window.location.href='/admin/blog_blog/CatalogManage';</script>");
                }
                else
                {
                    return Content(@"<script>alert('修改失败!');window.location.href=document.referrer;</script>");
                }
            }
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
                    return Content(@"<script>alert('删除成功!');window.location.href=document.referrer;</script>");
                }
                else
                {
                    return Content(@"<script>alert('删除失败!');window.location.href=document.referrer;</script>");
                }
            }
        }






        [HttpGet]
        public ActionResult BlogManage()
        {
            return View();
        }

        public JsonResult LoadBlog()
        {
            using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
            {
                var list = dbContext.Blogs.ToList().Select(m => new { Id = m.Id, Title = m.Title, Content = m.Content, catalogId = m.catalogId }).ToList();
                return Json(list);
            }
        }

        [HttpGet]
        [ValidateInput(false)]

        public ActionResult BlogModify(int id)
        {
            using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
            {
                List<SelectListItem> listCatalog = dbContext.Catalogs.ToList().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList();
                ViewBag.catalogList = listCatalog;
                //return View();
                var model = dbContext.Blogs.FirstOrDefault(m => m.Id == id);
                BlogModify cm1 = new ViewsModels.BlogModify();
                cm1.Id = model.Id;
                cm1.Title = model.Title;
                cm1.Content = model.Content;
                cm1.catalogId = model.catalogId;
                return View(cm1);
            }
        }



        [HttpPost]
        [ValidateInput(false)]

        public ActionResult BlogModify(BlogModify model)
        {
            using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
            {
            
                   
             

                var odlModel = dbContext.Blogs.FirstOrDefault(m => m.Id == model.Id);
                odlModel.Title = model.Title;
                odlModel.Content = model.Content;
                odlModel.catalogId = model.catalogId;
                DbEntityEntry entry = dbContext.Entry(odlModel);
                entry.State = EntityState.Modified;
                int res = dbContext.SaveChanges();
                if (res > 0)
                {
                    return Content(@"<script>alert('修改成功!');window.location.href='/admin/blog_blog/BlogManage';</script>");
                }
                else
                {
                    return Content(@"<script>alert('修改失败!');window.location.href=document.referrer;</script>");
                }
            }
        }

        public ActionResult BlogDel(int id)
        {
            using (web.App_Code.BlogDbContext dbContext = new App_Code.BlogDbContext())
            {
                var odlModel = dbContext.Blogs.FirstOrDefault(m => m.Id == id);
                DbEntityEntry entry = dbContext.Entry(odlModel);
                entry.State = EntityState.Deleted;
                int res = dbContext.SaveChanges();
                if (res > 0)
                {
                    return Content(@"<script>alert('删除成功!');window.location.href=document.referrer;</script>");
                }
                else
                {
                    return Content(@"<script>alert('删除失败!');window.location.href=document.referrer;</script>");
                }
            }
        }

        public ActionResult Music()
        {
            return Content(@"<script>window.open=('http://changyan.kuaizhan.com/overview');</script>");
        }



    }
    }

