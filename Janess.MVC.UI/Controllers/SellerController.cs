using Janess.BLL.Seller;
using Janess.Model;
using Janess.MVC.UI.Core;
using Janess.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janess.MVC.UI.Controllers
{
    public class SellerController : BaseController
    {
        string IMAGES_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Image\Goods");

        //店铺主页
        public ActionResult Index()
        {
            if (Session["CurUserName"] != null)
            {
                ViewBag.Name = Session["CurUserName"];
            }
            return View();
        }

        //店铺商品管理界面
        public ActionResult GoodsView()
        {
            if (Session["ShopID"] != null)
            {
                ViewBag.ShopID = Session["ShopID"];
            }
            return View();
        }

        //商品添加界面
        public ActionResult EditGoodsView(Nullable<int> id,string url)
        {
            ViewBag.GoodsID = id;
            ViewBag.ImageUrl = url;
            return View();
        }

        //店铺信息管理界面
        public ActionResult ShopView()
        {
            if (Session["ShopID"] != null)
            {
                ViewBag.ShopID = Session["ShopID"];
            }
            return View();
        }

        /// <summary>
        /// 店铺订单管理界面 分页查询
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderViewPager()
        {
            return View();
        }

        /// <summary>
        /// 查询所有订单
        /// </summary>
        /// <returns></returns>
        public JsonResult OrderQuery()
        {
            List<TB_ORDER> list = SellerMgr.OrderQuery();

            //string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(list, Config.FULL_DATE_FORMAT);
            //return Json(jsonStr);

            //使用layui table的方式
            LayUITableModel res = new LayUITableModel(list.Count, list);
            return Json(res);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public JsonResult GetArticleByPager(PageParam page)
        {
            int shopID = int.Parse(Session["shopID"].ToString());
            var res = SellerMgr.GetArticlesByPager(page, shopID);
            LayUITableModel model = new LayUITableModel(res.Total, res.Rows);
            return Json(model);
        }

        /// <summary>
        /// 通过订单ID修改订单状态（卖家派送）
        /// </summary>
        /// <param name="id"></param>
        public void UpdateStateByID(int id)
        {
            SellerMgr.UpdateStateByID(id);
        }

        /// <summary>
        /// 通过店铺ID查询店铺信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetShopByID(int id)
        {
            TB_SHOP model = SellerMgr.GetShopByID(id);

            return Json(model);
        }

        /// <summary>
        /// 修改店铺信息
        /// </summary>
        /// <param name="shop"></param>
        /// <returns></returns>
        public JsonResult UpdateShopInfo(TB_SHOP shop)
        {
            bool res = SellerMgr.UpdateShopInfo(shop);

            return Json(res);
        }

        /// <summary>
        /// 保存商品信息
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public JsonResult SaveGoods(TB_GOODS goods)
        {
            bool res = false;
            goods.GOODS_SHOP_ID = int.Parse(Session["shopID"].ToString());

            //ID为-1，则为添加商品
            if (goods.ID == -1)
            {
                res = SellerMgr.Add(goods);
            }
            else
            {
                res = SellerMgr.Update(goods);
            }
            return Json(res);
        }

        /// <summary>
        /// 根据店铺ID返回所有商品信息
        /// </summary>
        /// <param name="shopID"></param>
        /// <returns></returns>
        public JsonResult GetGoodsInfoByShopID(int shopID)
        {
            List<TB_GOODS> list = SellerMgr.GetGoodsInfoByShopID(shopID);

            //LayUITableModel res = new LayUITableModel(list.Count, list);
            return Json(list);
        }

        /// <summary>
        /// 根据商品ID删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult RemoveGoods(int id)
        {
            bool res = SellerMgr.RemoveGoods(id);
            return Json(res);
        }

        /// <summary>
        /// 根据店铺ID、搜索关键词返回所有商品信息
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public JsonResult SearchGoods(int shopID, string keyWord)
        {
            List<TB_GOODS> list = SellerMgr.SearchGoods(shopID, keyWord);

            return Json(list);
        }

        /// <summary>
        /// 根据商品ID返回商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetGoodsInfoByID(int id)
        {
            TB_GOODS model = SellerMgr.GetGoodsInfoByID(id);
            return Json(model);
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <returns></returns>
        public JsonResult SaveImages()
        {
            LayUIVOState vo = new LayUIVOState();
            var files = HttpContext.Request.Files;
            if (files.Count == 0)
            {
                vo.code = -1;
            }
            else
            {
                HttpPostedFileBase file = files[0];
                string fileName = file.FileName;
                string fullName = Path.Combine(IMAGES_PATH, fileName);
                file.SaveAs(fullName);
                vo.data = fileName;
            }
            return Json(vo);
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="imgName"></param>
        /// <returns></returns>
        public FileResult GetImage(string imgName)
        {
            string path = Path.Combine(IMAGES_PATH, imgName);
            return new FileStreamResult(new FileStream(path, FileMode.Open), "image/jpeg");
        }
    }
}