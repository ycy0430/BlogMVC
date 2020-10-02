using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.ViewsModels
{
    public class BlogAdd
    {
        [Required]
        [StringLength(250)]
        public string Title { set; get; }
        public string Content { set; get; }
        public int catalogId { set; get; }
    }
}