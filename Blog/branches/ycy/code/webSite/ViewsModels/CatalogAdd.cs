﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.ViewsModels
{
    public class CatalogAdd
    {
        [Required]
        [StringLength(50)]
        public string Name { set; get; }
    }
}