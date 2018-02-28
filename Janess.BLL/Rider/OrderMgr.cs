using Janess.DAL.Rider;
using Janess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.BLL.Rider
{
    public class OrderMgr
    {

        #region 骑手（查询）

        /// <summary>
        /// 骑手-已完成订单（查询）
        /// </summary>
        /// <returns></returns>
        public static List<TB_ORDER> GetOrderCompleted()
        {
            List<TB_ORDER> lstOrder = new List<TB_ORDER>();
            lstOrder = OrderDao.GetOrderCompleted();
            return lstOrder;
        }
        /// <summary>
        /// 骑手-未完成订单
        /// </summary>
        /// <returns></returns>
        public static List<TB_ORDER> GetOrderUnfinished()
        {
            List<TB_ORDER> lstOrder = new List<TB_ORDER>();
            lstOrder = OrderDao.GetOrderUnfinished();
            return lstOrder;
        }
        /// <summary>
        /// 骑手-抢单
        /// </summary>
        /// <returns></returns>
        public static List<TB_ORDER> GetOrderNotShipped()
        {
            List<TB_ORDER> lstOrder = new List<TB_ORDER>();
            lstOrder = OrderDao.GetOrderNotShipped();
            return lstOrder;
        }

        #endregion

        #region 骑手（分页查询）

        /// <summary>
        ///  骑手-已完成订单(分页查询)
        /// </summary>
        /// <returns></returns>
        public static Pager<TB_ORDER> GetOrderCompletedPager(PageParam page,int RiderID)
        {
            return OrderDao.GetOrderCompletedPager(page,RiderID);
        }

        /// <summary>
        /// 骑手-未完成订单（分页查询）
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Pager<TB_ORDER> GetOrderUnfinishedPager(PageParam page,int RiderID)
        {
            return OrderDao.GetOrderUnfinishedPager(page,RiderID);
        }

        /// <summary>
        /// 骑手-抢单（分页）
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Pager<TB_ORDER> GetOrderNotShippedPager(PageParam page)
        {
            return OrderDao.GetOrderNotShippedPager(page);
        }

        #endregion

        #region 操作

        /// <summary>
        /// 根据订单ID改变订单状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void ConfirmDelivery(int id)
        {
            OrderDao.ConfirmDelivery(id);
        }

        /// <summary>
        /// 根据订单ID抢单
        /// </summary>
        /// <param name="id"></param>
        public static void GrabSingle(int id,int RiderID)
        {
            OrderDao.GrabSingle(id,RiderID);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <returns></returns>
        public static List<TB_ORDER> SearchOrderID(int RiderID,string keyOrderID)
        {
            List<TB_ORDER> list = new List<TB_ORDER>();
            list = OrderDao.SearchOrderID(RiderID,keyOrderID);
            return list;
        }

        #endregion
    }
}
