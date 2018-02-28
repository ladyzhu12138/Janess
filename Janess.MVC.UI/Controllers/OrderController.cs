using Janess.BLL.Order;
using Janess.Model;
using Janess.MVC.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janess.MVC.UI.Controllers
{
    public class OrderController : BaseController
    {
        public ActionResult SubmitView(int?orderID)
        {
            if (Session["CurUserName"] != null)
            {
                ViewBag.Name = Session["CurUserName"];
                ViewBag.BuyerID = Session["BuyerID"];
                ViewBag.OrderID = orderID;
            }
            return View();
        }

        public ActionResult SuccessView()
        {
            return View();
        }

        public JsonResult GetOrderInfoByUserID(int?orderID)
        {
            List<Orders> list = OrderMgr.GetOrderInfoByUserID(orderID);
            return Json(list);
        }

        public JsonResult SubmitOrder(int? orderID)
        {
            bool res = OrderMgr.SubmitOrder(orderID);
            return Json(res);
        }

        public void ClearOrder(int userID)
        {
            OrderMgr.ClearOrder(userID);
        }
    }
}