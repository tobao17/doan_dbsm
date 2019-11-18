using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace doan_dbsm.Models.DATA
{
    public class PRODUCT
    {
        [Key]
       public int   product_id { get; set; }
       public string product_Name { get; set; }
       public string prices { get; set; }
        public int SizeS { get; set; }
        public int SizeM { get; set; }
        public int SizeL { get; set; }
        public int SizeXL { get; set; }
        public string image{ get; set; }
        public string Description { get; set; }
        public int count { get; set; }
       public int gr_groupid { get; set; }
       public virtual List< DETAILS_ORDER> DETAILS_ORDERs { get; set; }
       public virtual PRODUCT_GROUP PRODUCT_GROUP { get; set; }


    }
}