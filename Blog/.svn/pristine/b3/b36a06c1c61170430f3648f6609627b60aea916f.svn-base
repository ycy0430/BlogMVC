using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class User
    {
        [Key]
        public int Id { set; get; }

        [StringLength(maximumLength: 16, MinimumLength = 6)]
        public string Name { set; get; }

        [StringLength(maximumLength: 50)]
        public string Pwd { set; get; }
        public DateTime AddTime { set; get; }
        public bool Status { set; get; }
    }
}