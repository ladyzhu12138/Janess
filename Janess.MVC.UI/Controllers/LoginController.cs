using Janess.BLL;
using Janess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janess.MVC.UI.Controllers
{
    public class LoginController : Controller
    {
        UserMgrProxy usermgr = new UserMgrProxy();

        #region Views
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SignInView()
        {
            if (Session["CurUserName"] != null)
            {
                Session["ACCOUNT"] = null;
                Session["CurUserName"] = null;
                Session["ShopID"] = null;
            }
            return View();
        }
        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SignUpView()
        {
            return View();
        }
        #endregion

        #region Datas
        /// <summary>
        /// 买家注册
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public JsonResult AddBuyer(TB_BUYER buyer)
        {
            Models.ViewModelState viewmodel = new Models.ViewModelState();
            if (usermgr.CheckBuyer(buyer.ACCOUNT))
            {
                return Json(false);
            }
            else
            {
                viewmodel.Status = usermgr.AddBuyer(buyer);
            }
            return Json(viewmodel);
        }
        /// <summary>
        /// 买家登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult SignInBuyer(string account, string pwd)
        {
            TB_BUYER buyer = usermgr.LoginBuyer(account, pwd);
            Models.ViewModelState model = new Models.ViewModelState();
            if (null == buyer)
            {
                model.Status = false;
            }
            else
            {
                Session["CurUserName"] = buyer.BUYER_NAME;
                Session["BuyerID"] = buyer.ID;
                model.Status = true;
            }

            return Json(model);
        }

        /// <summary>
        /// 卖家注册
        /// </summary>
        /// <param name="seller"></param>
        /// <returns></returns>
        public JsonResult AddSeller(TB_SELLER seller)
        {
            Models.ViewModelState viewmodel = new Models.ViewModelState();
            if (usermgr.CheckSeller(seller.ACCOUNT))
            {
                return Json(false);
            }
            else
            {
                viewmodel.Status = usermgr.AddSeller(seller);
            }
            return Json(viewmodel);
        }
        /// <summary>
        /// 卖家登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult SignInSeller(string account, string pwd)
        {
            TB_SELLER seller = usermgr.LoginSeller(account, pwd);
            Models.ViewModelState model = new Models.ViewModelState();
            if (null == seller)
            {
                model.Status = false;
            }
            else
            {
                Session["CurUserName"] = seller.SELLER_NAME;
                Session["ShopID"] = seller.SHOP_ID;
                model.Status = true;
            }
            return Json(model);
        }

        /// <summary>
        /// 骑手注册
        /// </summary>
        /// <param name="rider"></param>
        /// <returns></returns>
        public JsonResult AddRider(TB_RIDER rider)
        {
            Models.ViewModelState viewmodel = new Models.ViewModelState();
            if (usermgr.CheckRider(rider.ACCOUNT))
            {
                return Json(false);
            }
            else
            {
                viewmodel.Status = usermgr.AddRider(rider);
            }
            return Json(viewmodel);
        }
        /// <summary>
        /// 骑手登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult SignInRider(string account, string pwd)
        {
            TB_RIDER rider = usermgr.LoginRider(account, pwd);
            Models.ViewModelState model = new Models.ViewModelState();
            if (null == rider)
            {
                model.Status = false;
            }
            else
            {
                Session["Name"] = rider.RIDER_NAME;
                Session["RiderID"] = rider.ID;
                model.Status = true;
            }
            return Json(model);
        }

        /// <summary>
        /// 首页根据这次检查判断该用户是否拥有店铺
        /// </summary>
        /// <param name="seller"></param>
        /// <returns></returns>
        public JsonResult CheckSellerName(TB_SELLER seller)
        {
            if (usermgr.CheckSellerName(seller.SELLER_NAME))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        #endregion

    }
}