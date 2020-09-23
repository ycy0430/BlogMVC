using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class Blog
    {
        [Key]
        public int Id { set; get; }

        [StringLength(250)]
        public string Title { set; get; }
        public string Content { set; get; }
        public int catalogId { set; get; }
        [ForeignKey("catalogId")]
        public virtual Catalog catalog { set; get; }
        public DateTime AddTime { set; get; }
        public bool Status { set; get; }
    }
}