using web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace web.App_Code
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() : base("name=dblink")
        {

        }

        public DbSet<User> Users { set; get; }
        public DbSet<Catalog> Catalogs { set; get; }
        public DbSet<Blog> Blogs { set; get; }
    }

}