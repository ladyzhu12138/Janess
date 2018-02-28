using Janess.DAL.Order;
using Janess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.BLL.Order
{
    public class OrderMgr
    {
        public static List<Orders> GetOrderInfoByUserID(int? orderID)
        {
            List<Orders> list = new List<Orders>();
            list = OrderDao.GetOrderInfoByUserID(orderID);
            return list;
        }

        public static bool SubmitOrder(int?id)
        {
            int res = OrderDao.SubmitOrder(id);
            return res > 0;
        }

        public static void ClearOrder(int userID)
        {
            OrderDao.ClearOrder(userID);
        }
    }
}