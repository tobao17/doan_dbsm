﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace doan_dbsm.Models.DATA
{
    public class PRODUCT_KIND
    {
        [Key]
        public int  kind_id { get; set; }
        public string name { get; set; }
        public virtual List<PRODUCT_GROUP> PRODUCT_GROUPs { get; set; }
    }
}