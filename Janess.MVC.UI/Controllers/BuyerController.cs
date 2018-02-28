using Janess.BLL.Buyer;
using Janess.BLL.Home;
using Janess.BLL.Person;
using Janess.DAL;
using Janess.DAL.Person;
using Janess.Model;
using Janess.MVC.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Janess.MVC.UI.Controllers
{
    public class BuyerController : Controller
    {
        // GET: Buyer
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 店铺详情界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult IntroductionShopView(int? val)
        {
            ViewBag.ShopsId = val;
            if (Session["CurUserName"] != null)
            {
                ViewBag.Name = Session["CurUserName"];
                ViewBag.BuyerID = Session["BuyerID"];
            }
            return View();
        }
        /// <summary>
        /// 评价商品
        /// </summary>
        /// <returns></returns>
        public ActionResult EveluateView()
        {
            return View();
        }
        /// <summary>
        /// 获取未评价评价商品
        /// </summary>
        /// <returns></returns>
        public ActionResult EvaluateGoodsView()
        {
            if (Session["BuyerID"] != null)
            {
                ViewBag.id = Session["BuyerID"];
            }
            if (Session["CurUserName"] != null)
            {
                ViewBag.name = Session["CurUserName"];
            }
            return View();
        }
        /// <summary>
        /// 个人信息页
        /// </summary>
        public ActionResult DataView(int? val)
        {
            if (Session["BuyerID"] != null)
            {
                ViewBag.id = Session["BuyerID"];
            }
            if (Session["CurUserName"] != null)
            {
                ViewBag.name = Session["CurUserName"];
            }
            ViewBag.BuyerId = val;
            return View();
        }
        public JsonResult AltOrder(TB_ORDER order,int ORDER_NO)
        {
            bool model = PersonMgr.AltOrder(order,ORDER_NO);
            return Json(model);
        }
        public JsonResult GetShopInfo(int? id)
        {
            List<TB_SHOP> model = PersonMgr.GetShopInfo(id);
            return Json(model);
        }
        /// <summary>
        /// 根据店铺id查店铺商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetShopsInfo(int? id)
        {
            List<TB_GOODS> model = PersonMgr.GetShopsInfo(id);
            return Json(model);
        }
        /// <summary>
        /// 通过用户ID查用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetPersonByID(int id)
        {
            TB_BUYER model = PersonMgr.GetPersonById(id);

            return Json(model);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        public JsonResult AltBuyersInfo(TB_BUYER buyer,int id)
        {
            bool res = PersonMgr.AltBuyersInfo(buyer,id);
            return Json(res);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public JsonResult AltPwd(TB_BUYER buyer,int id)
        {
            bool res = PersonMgr.AltPwd(buyer,id);
            return Json(res);
        }
        /// <summary>
        /// 修改密码页
        /// </summary>
        public ActionResult AltPwdView()
        {
            if (Session["BuyerID"] != null)
            {
                ViewBag.id = Session["BuyerID"];
            }
            if (Session["CurUserName"] != null)
            {
                ViewBag.name = Session["CurUserName"];
            }
            return View();
        }
        /// <summary>
        /// 修改密码跳转页
        /// </summary>
        public ActionResult AltPwd2View()
        {
            if (Session["BuyerID"] != null)
            {
                ViewBag.id = Session["BuyerID"];
            }
            if (Session["CurUserName"] != null)
            {
                ViewBag.name = Session["CurUserName"];
            }
            return View();
        }
        /// <summary>
        /// 联系我们
        /// </summary>
        /// <returns></returns>
        public ActionResult ContactView()
        {
            return View();
        }
        /// <summary>
        /// 收藏商品
        /// </summary>
        /// <returns></returns>
        public ActionResult CollectionGoodsView(int? val)
        {
            if (Session["BuyerID"] != null)
            {
                ViewBag.id = Session["BuyerID"];
            }
            if (Session["CurUserName"] != null)
            {
                ViewBag.name = Session["CurUserName"];
            }
            return View();
        }
        /// <summary>
        /// 收藏店铺
        /// </summary>
        /// <returns></returns>
        public ActionResult CollectionShopsView()
        {
            if (Session["BuyerID"] != null)
            {
                ViewBag.id = Session["BuyerID"];
            }
            if (Session["CurUserName"] != null)
            {
                ViewBag.name = Session["CurUserName"];
            }
            return View();
        }
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderView()
        {
            if (Session["BuyerID"] != null)
            {
                ViewBag.id = Session["BuyerID"];
            }
            if (Session["CurUserName"] != null)
            {
                ViewBag.name = Session["CurUserName"];
            }
            return View();
        }
       /// <summary>
       ///购物车界面
       /// </summary>
       /// <param name="BuyerID"></param>
       /// <returns></returns>
        public ActionResult CartView()
        {
            if (Session["BuyerID"] != null)
            {
                ViewBag.id = Session["BuyerID"];
            }
            if (Session["CurUserName"] != null)
            {
                ViewBag.name = Session["CurUserName"];
            }
            return View();
        }
        /// <summary>
        /// 获取收藏店铺信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCollectShopsInfo(int? id)
        {
            List<Collect_Shops> lstShops = PersonMgr.GetCollectShopsInfo(id);
            return Json(lstShops);
        }
        /// <summary>
        /// 获取收藏商品的信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGoodsInfo(int? id)
        {
            List<Collect_Goods> lstGoods = PersonMgr.GetCollectGoodsInfo(id);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取所有详单
        /// </summary>
        /// <param name="multi"></param>
        /// <returns></returns>
        public JsonResult GetAllDetailOrders(string multi)
        {
            List<Orders> lstGoods = PersonMgr.GetAllDetailOrders(multi);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取所有订单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllOrders(int? id)
        {
            List<Orders> lstGoods = PersonMgr.GetAllOrders(id);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取未付款订单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUnpayOrders(int? id)
        {
            List<Orders> lstGoods = PersonMgr.GetUnpayOrders(id);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取未付款详单
        /// </summary>
        /// <param name="multi"></param>
        /// <returns></returns>
        public JsonResult GetUnpayDetailOrders(string multi)
        {
            List<Orders> lstGoods = PersonMgr.GetUnpayDetailOrders(multi);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取未发货订单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUnsendOrders(int? id)
        {
            List<Orders> lstGoods = PersonMgr.GetUnsendOrders(id);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取未发货详单
        /// </summary>
        /// <param name="multi"></param>
        /// <returns></returns>
        public JsonResult GetUnsendDetailOrders(string multi)
        {
            List<Orders> lstGoods = PersonMgr.GetUnsendDetailOrders(multi);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取未收货订单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUnsureOrders(int? id)
        {
            List<Orders> lstGoods = PersonMgr.GetUnsureOrders(id);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取未收货详单
        /// </summary>
        /// <param name="multi"></param>
        /// <returns></returns>
        public JsonResult GetUnsureDetailOrders(string multi)
        {
            List<Orders> lstGoods = PersonMgr.GetUnsureDetailOrders(multi);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取未评价订单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUnevaluateOrders(int? id)
        {
            List<Orders> lstGoods = PersonMgr.GetUnevaluateOrders(id);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取未评价详单
        /// </summary>
        /// <param name="multi"></param>
        /// <returns></returns>
        public JsonResult GetUnevaluateDetailOrders(string multi)
        {
            List<Orders> lstGoods = PersonMgr.GetUnevaluateDetailOrders(multi);
            return Json(lstGoods);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBuyersInfo(int? id)
        {
            List<TB_BUYER> lstBuyers = PersonMgr.GetBuyersInfo(id);
            return Json(lstBuyers);
        }
        /// <summary>
        /// 传用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult BuyerInfo(int id)
        {
            List<TB_BUYER> lstBuyers = PersonMgr.GetBuyersInfo(id);
            ViewBag.BuyerId = lstBuyers;
            return View();
        }
        /// <summary>
        /// 搜索界面
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchView(string val)
        {
            ViewBag.GoodsVal = val;
            if (Session["CurUserName"] != null)
            {
                ViewBag.Name = Session["CurUserName"];
                ViewBag.BuyerID = Session["BuyerID"];
            }
            return View();
        }
        /// <summary>
        /// 详情界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult IntroductionView(int? val)
        {
            ViewBag.GoodsId = val;
            if (Session["CurUserName"] != null)
            {
                ViewBag.Name = Session["CurUserName"];
                ViewBag.BuyerID = Session["BuyerID"];
            }
            return View();
        }
        /// <summary>
        /// 获取搜索值
        /// </summary>
        /// <param name="GoodsVal"></param>
        /// <returns></returns>
        public JsonResult SearchResult(string GoodsVal)
        {
           List<TB_GOODS> lstGoods = HomeGoodsManger.GetHomeGoodsByNameOrType(GoodsVal);

            return Json(lstGoods);
        }

        /// <summary>
        /// 获取商品详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult getGoods(int GoodsID)
        {
            List<IntroductionDetail> lstGoods = BuyerManger.GetGoodsByID(GoodsID);
            return Json(lstGoods);
        }
        /// <summary>
        /// 获取评价
        /// </summary>
        /// <param name="GoodsID"></param>
        /// <returns></returns>
        public JsonResult getEvaluate(int GoodsID)
        {
            List<Evaluate> lstEvaluate = BuyerManger.GetEvaluate(GoodsID);
            return Json(lstEvaluate);
        }
        /// <summary>
        /// 添加商品至购物车
        /// </summary>
        /// <param name="GoodsID"></param>
        /// <param name="ShopID"></param>
        /// <param name="GoodsNum"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public JsonResult AddToCart(int GoodsID,int ShopID,int GoodsNum, int UserID)
        {
            bool res = BuyerManger.AddToCart(GoodsID,ShopID,GoodsNum,UserID);
            return Json("{\"status\":true}");
        }
        /// <summary>
        /// 获取购物车商品数量
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public JsonResult GetCartGoodsNum(int UserID)
        {
            int num = BuyerManger.GetCartGoodsNum(UserID);
            return Json(num);
        }
        /// <summary>
        /// 获取购物车商品
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public JsonResult GetCartGoods(int UserID)
        {
            List<CartDetail> lstCart = BuyerManger.GetCartGoods(UserID);
            return Json(lstCart);
        }
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="CollectID"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public JsonResult AddToCollect(int UserID,int CollectID, string Type)
        {
            bool res = BuyerManger.AddToCollect(UserID,CollectID,Type);
            return Json("{\"status\":true}");
        }
        /// <summary>
        /// 删除购物车货物
        /// </summary>
        /// <param name="CartID"></param>
        /// <returns></returns>
        public JsonResult DeleteCartGoods(int CartID)
        {
            bool res = BuyerManger.DeleteCartGoods(CartID);
            return Json("{\"status\":true}");
        }

        public JsonResult AddToOrderDetail(string OrderID, int GoodsID, int GoodsNumber)
        {
            bool res = BuyerManger.AddToOrderDetail(OrderID, GoodsID, GoodsNumber);
            return Json("{\"status\":true}");
        }
        public JsonResult AddToOrder( int UserID,int ShopID,int OrderID,double Price, string OrderState)
        {
            bool res = BuyerManger.AddToOrder(UserID, ShopID, OrderID, Price, OrderState);
            return Json("{\"status\":true}");
        }
    }
}