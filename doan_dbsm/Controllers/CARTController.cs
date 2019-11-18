using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_dbsm.Models.CART;
using doan_dbsm.Models.DATA;
namespace doan_dbsm.Controllers
{
    public class CARTController : Controller
    {
        // GET: CART
        SHOPONLINE_CONTEXT db = new SHOPONLINE_CONTEXT();
        
        public List<ItemCART>laygiohang ()
        {
            List<ItemCART> listgiohang = Session["giohang"] as List<ItemCART>;
            if (listgiohang==null)
            {
                listgiohang = new List<ItemCART>();
                Session["giohang"] = listgiohang;
            }
            return listgiohang;
        }
        public ActionResult themgiohang (int Masp,string strURL, FormCollection a)
        {
            PRODUCT sp = db.PRODUCTs.SingleOrDefault(n => n.product_id == Masp);
            if (sp==null)
            {
                //duong dan khong hop le 
                Response.StatusCode = 404;
                return null;
            }
            //lay gio hang 
            List<ItemCART> lstItem = laygiohang();
            //neu sp da ton tai trong gio hang 
            ItemCART spcheck = lstItem.SingleOrDefault(n => n.masp == Masp);
            if (spcheck !=null)
            {
                if (sp.count<spcheck.soluong)
                {
                    return View("Thongbao");
                }
                spcheck.soluong= int.Parse(a["num-product"].ToString());
                return Redirect(strURL);
            }
            ItemCART itemCART = new ItemCART(Masp);
            itemCART.soluong = int.Parse(a["num-product"].ToString());

            lstItem.Add(itemCART);
            return RedirectToAction("Index","Product");
                
        }
        public double tinhsoluong()
        {
            List<ItemCART> lstcart = Session["giohang"] as List<ItemCART>;
            if (lstcart==null)
            {
                return 0;
            }
            return lstcart.Sum(n => n.soluong);
        }
        //public double tinhtongtien ()
        //{

        //    List<ItemCART> lstcart = Session["giohang"] as List<ItemCART>;
        //    if (lstcart == null)
        //    {
        //        return 0;
        //    }
        //    return lstcart.Sum(n => n.dongia);
        //}
        public ActionResult CartIcon()
        {
            if(tinhsoluong()==0)
            {
                ViewBag.Tongsoluong = 0;
                return PartialView();
            }
            ViewBag.Tongsoluong = tinhsoluong();
          
            return PartialView();
        }
        public ActionResult Cart ()
        {

            List<ItemCART> lstGiohang = laygiohang();
           
            return View(lstGiohang);
        }

        [HttpPost]
        public ActionResult updateCart(FormCollection f)
        {
           
            List<ItemCART> lstitem = laygiohang();
            foreach (ItemCART a in lstitem)
            {
                string c = a.masp.ToString();
                if (f[c].ToString() != null)
                {
                    a.soluong = int.Parse(f[c].ToString());
                     
                }

            }
            return View("Cart",lstitem);
        }
        public ActionResult Deleteitemcart (int Masp)
        {
            List<ItemCART> lstitem = laygiohang();
            ItemCART removeitem = lstitem.SingleOrDefault(n => n.masp == Masp);
            lstitem.Remove(removeitem);
            return RedirectToAction("Cart");


        }
        public ActionResult OrderProduct()
        {
            if (Session["giohang"]==null)
            {
                return RedirectToAction("Index", "Home");

            }
            ORDER dondathang = new ORDER();
            dondathang.Datetime = DateTime.Now.ToString();
            dondathang.status = "No-status";
            db.ORDERs.Add(dondathang);
            List<ItemCART> lstitem = laygiohang();
            foreach ( var item in lstitem)
            {
                DETAILS_ORDER ctddh = new DETAILS_ORDER();
                ctddh.order_ID = dondathang.order_ID;
                ctddh.count_product = item.soluong.ToString();
                ctddh.price = item.dongia.ToString();
                db.DETAILS_ORDERs.Add(ctddh);
            }
            db.SaveChanges();
            Session["giohang"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}