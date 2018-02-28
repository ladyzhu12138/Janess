using Janess.BLL.Home;
using Janess.Model;
using Janess.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janess.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<TB_GOODS> lstGoods = HomeGoodsManger.GetHomeGoods();
            ViewBag.goodsList = lstGoods;
            if (Session["CurUserName"] != null)
            {
                ViewBag.Name = Session["CurUserName"];
                ViewBag.BuyerID = Session["BuyerID"];
            }
            
            return View();
        }

        public JsonResult GetGoods()
        {
            List<TB_GOODS> lstGoods = HomeGoodsManger.GetHomeGoods();

            return Json(lstGoods);

        }
    }
}