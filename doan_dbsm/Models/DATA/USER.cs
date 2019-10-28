using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace doan_dbsm.Models.DATA
{
    public class USER
    {
        [Key]
        public int userid { get; set; }
        public string name { get; set; }
        public string pass { get; set; }
        
        public int custumerid { get; set; }
        public virtual CUSTUMER custumer { get; set; }
    }
}