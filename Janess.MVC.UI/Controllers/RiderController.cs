using Janess.BLL.Rider;
using Janess.Model;
using Janess.MVC.UI.Core;
using Janess.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janess.MVC.UI.Controllers
{
    public class RiderController : BaseController
    {

        #region 返回视图
        /// <summary>
        /// 骑手主页
        /// </summary>
        /// <returns></returns>
        public ActionResult HomePageView()
        {
            if (Session["RiderID"] != null)
            {
                ViewBag.RiderID = Session["RiderID"];
                ViewBag.Name = Session["Name"];
            }
            return View();
        }
        /// <summary>
        /// 骑手-联系我们
        /// </summary>
        /// <returns></returns>
        public ActionResult ContactUsView()
        {
            if (Session["RiderID"] != null)
            {
                ViewBag.RiderID = Session["RiderID"];
                ViewBag.Name = Session["Name"];
            }
            return View();
        }
        /// <summary>
        /// 骑手-已完成订单
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderCompletedView()
        {
            if (Session["RiderID"] != null)
            {
                ViewBag.RiderID = Session["RiderID"];
                ViewBag.Name = Session["Name"];
            }
            return View();
        }
        /// <summary>
        /// 骑手-未完成订单
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderUnfinishedView()
        {
            if (Session["RiderID"] != null)
            {
                ViewBag.RiderID = Session["RiderID"];
                ViewBag.Name = Session["Name"];
            }
            return View();
        }
        /// <summary>
        /// 骑手-抢单
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderDeliveredView()
        {
            if (Session["RiderID"] != null)
            {
                ViewBag.RiderID = Session["RiderID"];
                ViewBag.Name = Session["Name"];
            }
            return View();
        }

        /// <summary>
        /// 骑手调试
        /// </summary>
        /// <returns></returns>
        public ActionResult debuggingView()
        {
            return View();
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutView()
        {
            if (Session["RiderID"] != null)
            {
                ViewBag.RiderID = Session["RiderID"];
                ViewBag.Name = Session["Name"];
            }
            return View();
        }

        #endregion

        #region 骑手（普通查询）
        /// <summary>
        /// 骑手-已完成订单(查询)
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOrderCompleted()
        {
            List<TB_ORDER> lstOrder = OrderMgr.GetOrderCompleted();
            return Json(lstOrder);
        }
        /// <summary>
        /// 骑手-未完成订单
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOrderUnfinished()
        {
            List<TB_ORDER> lstOrder = OrderMgr.GetOrderUnfinished();
            return Json(lstOrder);
        }
        /// <summary>
        /// 骑手-抢单
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOrderNotShipped()
        {
            List<TB_ORDER> lstOrder = OrderMgr.GetOrderNotShipped();
            return Json(lstOrder);
        }
        #endregion

        #region 骑手（分页查询）

        /// <summary>
        /// 骑手-已完成订单(分页查询)
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult GetOrderCompletedPager(PageParam page)
        {
            int RiderID = int.Parse(Session["RiderID"].ToString());
            var res = OrderMgr.GetOrderCompletedPager(page,RiderID);
            LayUITableModel models = new LayUITableModel(res.Total, res.Rows);
            return Json(models);
        }

        /// <summary>
        /// 骑手-未完成订单（分页查询）
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult GetOrderUnfinishedPager(PageParam page)
        {
            int RiderID = int.Parse(Session["RiderID"].ToString());
            var res = OrderMgr.GetOrderUnfinishedPager(page,RiderID);
            LayUITableModel models = new LayUITableModel(res.Total, res.Rows);
            return Json(models);
        }

        /// <summary>
        /// 骑手-抢单（分页）
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult GetOrderNotShippedPager(PageParam page)
        {
            var res = OrderMgr.GetOrderNotShippedPager(page);
            LayUITableModel models = new LayUITableModel(res.Total, res.Rows);
            return Json(models);
        }

        #endregion

        #region 操作

        /// <summary>
        /// 根据订单ID修改订单状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void ConfirmDelivery(int id)
        {
            OrderMgr.ConfirmDelivery(id);
        }

        /// <summary>
        /// 根据订单ID抢单
        /// </summary>
        /// <param name="id"></param>
        public void GrabSingle(int id)
        {
            int RiderID = int.Parse(Session["RiderID"].ToString());
            OrderMgr.GrabSingle(id,RiderID);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchOrderID(int RiderID,string keyOrderID)
        {
            List<TB_ORDER> list = OrderMgr.SearchOrderID(RiderID,keyOrderID);
            return Json(list);
        }

        #endregion
    }
}