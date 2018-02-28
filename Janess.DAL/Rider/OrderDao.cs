using Janess.DAL;
using Janess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.DAL.Rider
{
    public class OrderDao
    {

        #region 骑手（查询）

        /// <summary>
        /// 骑手-已完成的订单(查询)
        /// </summary>
        /// <returns></returns>
        public static List<TB_ORDER> GetOrderCompleted()
        {
            List<TB_ORDER> lstOrder = new List<TB_ORDER>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstOrder = context.Database.SqlQuery<TB_ORDER>("SELECT * FROM dbo.TB_ORDER WHERE ORDER_STATE ='待评价';").ToList();
            }
            return lstOrder;
        }
        /// <summary>
        /// 骑手-未完成订单(查询)
        /// </summary>
        /// <returns></returns>
        public static List<TB_ORDER> GetOrderUnfinished()
        {
            List<TB_ORDER> lstOrder = new List<TB_ORDER>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstOrder = context.Database.SqlQuery<TB_ORDER>("SELECT * FROM dbo.TB_ORDER WHERE ORDER_STATE ='发货待收货';").ToList();
            }
            return lstOrder;
        }
        /// <summary>
        /// 骑手-抢单
        /// </summary>
        /// <returns></returns>
        public static List<TB_ORDER> GetOrderNotShipped()
        {
            List<TB_ORDER> lstOrder = new List<TB_ORDER>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstOrder = context.Database.SqlQuery<TB_ORDER>("SELECT * FROM dbo.TB_ORDER WHERE ORDER_STATE ='付款待发货';").ToList();
            }
            return lstOrder;
        }

        #endregion

        #region 骑手（分页查询）

        /// <summary>
        /// 骑手-已完成的订单(分页查询)
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Pager<TB_ORDER> GetOrderCompletedPager(PageParam page, int RiderID)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                Pager<TB_ORDER> pg = new Pager<TB_ORDER>();
                var res = context.TB_ORDER.Where(t => (t.ORDER_STATE == "待评价" || t.ORDER_STATE == "完成") && t.ORDER_RIDER_ID == RiderID);
                //var res = context.Database.SqlQuery<TB_ORDER>("SELECT * FROM dbo.TB_ORDER,dbo.TB_BUYER,dbo.TB_SHOP WHERE dbo.TB_BUYER.ID = dbo.TB_ORDER.ORDER_USER_ID AND dbo.TB_SHOP.ID = dbo.TB_ORDER.ORDER_SHOP_ID AND ORDER_STATE = '待评价' AND ORDER_RIDER_ID = "+RiderID).ToList();
                pg.Total = res.Count();
                pg.Rows = res.OrderBy(t => t.ORDER_TIME).Skip(page.Skip).Take(page.PageSize).ToList();

                return pg;
            }
        }
        /// <summary>
        /// 骑手-未完成的订单（分页查询）
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Pager<TB_ORDER> GetOrderUnfinishedPager(PageParam page, int RiderID)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                Pager<TB_ORDER> pg = new Pager<TB_ORDER>();
                var res = context.TB_ORDER.Where(t => t.ORDER_STATE == "发货待收货" && t.ORDER_RIDER_ID == RiderID);
                //var res = context.Database.SqlQuery<TB_ORDER>("SELECT * FROM dbo.TB_ORDER,dbo.TB_BUYER,dbo.TB_SHOP WHERE dbo.TB_BUYER.ID = dbo.TB_ORDER.ORDER_USER_ID AND dbo.TB_SHOP.ID = dbo.TB_ORDER.ORDER_SHOP_ID AND ORDER_STATE = '发货待收货' AND ORDER_RIDER_ID = " + RiderID).ToList();
                pg.Total = res.Count();
                pg.Rows = res.OrderBy(t => t.ORDER_TIME).Skip(page.Skip).Take(page.PageSize).ToList();
                return pg;
            }
        }

        /// <summary>
        /// 骑手-抢单（分页查询）
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Pager<TB_ORDER> GetOrderNotShippedPager(PageParam page)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                Pager<TB_ORDER> pg = new Pager<TB_ORDER>();
                var res = context.TB_ORDER.Where(t => t.ORDER_STATE == "付款待发货" && t.ORDER_RIDER_ID == null);
                //var res = context.Database.SqlQuery<OrderZong>("SELECT dbo.TB_ORDER.ID,BUYER_NAME,BUYER_ADDRESS,SHOP_NAME,SHOP_ADDRESS,ORDER_RIDER_ID,ORDER_TIME,ORDER_STATE FROM dbo.TB_ORDER,dbo.TB_BUYER,dbo.TB_SHOP WHERE dbo.TB_BUYER.ID = dbo.TB_ORDER.ORDER_USER_ID AND dbo.TB_SHOP.ID = dbo.TB_ORDER.ORDER_SHOP_ID AND ORDER_STATE = '付款待发货' AND ORDER_RIDER_ID IS NULL");
                pg.Total = res.Count();
                pg.Rows = res.OrderBy(t => t.ORDER_TIME).Skip(page.Skip).Take(page.PageSize).ToList();
                return pg;
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 根据id修改订单状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void ConfirmDelivery(int id)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_ORDER confirm = context.TB_ORDER.FirstOrDefault(t => t.ID == id);
                confirm.ORDER_STATE = "待评价";
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 抢单
        /// </summary>
        /// <param name="id"></param>
        public static void GrabSingle(int id, int RiderID)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_ORDER confirm = context.TB_ORDER.FirstOrDefault(t => t.ID == id);
                //confirm.ORDER_STATE = "付款待发货";
                confirm.ORDER_RIDER_ID = RiderID;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="RiderID"></param>
        /// <param name="keyOrderID"></param>
        /// <returns></returns>
        public static List<TB_ORDER> SearchOrderID(int RiderID, string keyOrderID)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var list = context.Database.SqlQuery<TB_ORDER>("SELECT * FROM dbo.TB_ORDER WHERE ORDER_RIDER_ID=" + RiderID + "AND ID LIKE '%" + keyOrderID + "%'").ToList();
                return list;
            }
        }

        #endregion

    }
}
