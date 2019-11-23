using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_dbsm.Models.DATA;

namespace doan_dbsm.Controllers
{
    public class LoginController : Controller
    {
        SHOPONLINE_CONTEXT db = new SHOPONLINE_CONTEXT();
        
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index (CUSTUMER custumer)
        {
         
                ViewBag.thongbao = "them tai khoan thanh cong";
                db.CUSTUMERs.Add(custumer);
                db.SaveChanges();
                //co the lay bang form conection 
                return View();
       
        }
        [HttpPost]
        public ActionResult dangnhap (FormCollection f)
            
        {
            string name = f["name"].ToString();
            string pass = f["pass"].ToString();
            CUSTUMER tv = db.CUSTUMERs.SingleOrDefault(n => n.name == name && n.pass == pass);
              if (tv!=null)
            {
                Session["taikhoan"] = tv.name;
                Session["taikhoanid"] = tv.custumerid;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public ActionResult dangxuat(FormCollection f)

        {

            Session["taikhoan"] = null;
            Session["taikhoanid"] = null;


            return RedirectToAction("Index", "Home");
        }
    }
}