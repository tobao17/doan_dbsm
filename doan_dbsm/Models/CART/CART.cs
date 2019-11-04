using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_dbsm.Models.DATA;
namespace doan_dbsm.Models.CART
{
    public class CART
    {
        public string tensanpham { get; set; }
        public int masp { get; set; }
        public int soluong { get; set; }
        public string dongia { get; set; }
        public string anh { get; set; }
        public CART(int imasp)
        {
             using (SHOPONLINE_CONTEXT db=new SHOPONLINE_CONTEXT())
            {
                this.masp = imasp;
                PRODUCT sp = db.PRODUCTs.Single(n => n.product_id == masp);
                this.tensanpham = sp.product_Name;
               this.anh = sp.image;
                this.dongia = sp.prices;

            }
        }
    


    }
}