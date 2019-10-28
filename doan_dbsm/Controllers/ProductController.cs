using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_dbsm.Models.DATA;
namespace doan_dbsm.Controllers
{
    public class ProductController : Controller
    {
        SHOPONLINE_CONTEXT db = new SHOPONLINE_CONTEXT();
        // GET: Product
        public ActionResult productpartialview()
        {
            //var lstproduct1 =  db.PRODUCTs.ToString();
            //ViewBag.lstproduct1 = lstproduct1;
            return PartialView();
        }
        public ActionResult productpartialview2()
        {
            return PartialView();
        }
    }
}