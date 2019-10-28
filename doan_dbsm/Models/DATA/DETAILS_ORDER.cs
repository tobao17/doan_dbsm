using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan_dbsm.Models.DATA
{
    public class DETAILS_ORDER
    {
        [Key]
        public int de_orderid { get; set; }

      
        public string price { get; set; }
        public string count_product { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }

        public int order_ID { get; set; }
        public virtual ORDER ORDER { get; set; }
    
    }
}