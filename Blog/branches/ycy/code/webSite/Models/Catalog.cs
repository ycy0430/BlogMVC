using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


namespace web.Models
{
    public class Catalog : rui.pagerBase
    {
        [Key]
        public int Id { set; get; }

        [StringLength(50)]
        public string Name { set; get; }
        public DateTime AddTime { set; get; }
        public bool Status { set; get; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public override void Search()
        {
           this.keyField = "Id";
           this.ResourceCode = "Blog_Catalogs";

           string querySql = " select * from Catalogs where 1=1 ";
           // querySql += rui.dbTools.searchTbx("Id", this.Id, this.cmdPara);
            querySql += rui.dbTools.searchTbx("Name", this.Name, this.cmdPara);

           this.getPageConfig();
            rui.pagerHelper ph = new rui.pagerHelper(querySql, this.getOrderSql("Id", "asc"), this);
            ph.Execute(this.PageSize, this.PageIndex, this);
            this.dataTable = ph.Result;
            //获取要展示的列配置
            this.showColumn = this.getShowColumn();
        }
    }
}