using Janess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.DAL.Order
{
    public class OrderDao
    {
        public static List<Orders> GetOrderInfoByUserID(int?orderID)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {

                var p_userID = new SqlParameter("@ORDER_ID", orderID);
                //                var res = context.Database.SqlQuery<Orders>(@"SELECT DISTINCT GOODS_NAME,GOODS_PRICE,GOODS_IMAGE_URL,DETORSER_GOODS_NUM FROM  TB_ORDER_DETAILS LEFT JOIN TB_GOODS ON DETORSER_GOODS_ID=TB_GOODS.ID WHERE DETORSER_GOODS_ID IN (SELECT DETORSER_GOODS_ID FROM TB_ORDER_DETAILS WHERE ORDER_ID IN(SELECT ORDER_NO FROM TB_ORDER WHERE ORDER_USER_ID=@ORDER_USER_ID AND ORDER_STATE='未付款'
                //))
                //", p_userID).ToList();
                var res = context.Database.SqlQuery<Orders>(@"SELECT DISTINCT GOODS_NAME,GOODS_PRICE,GOODS_IMAGE_URL,DETORSER_GOODS_NUM
FROM TB_ORDER_DETAILS INNER JOIN TB_ORDER ON TB_ORDER_DETAILS.ORDER_ID=TB_ORDER.ORDER_NO INNER JOIN TB_GOODS ON DETORSER_GOODS_ID=TB_GOODS.ID
WHERE TB_ORDER_DETAILS.ORDER_ID=@ORDER_ID
", p_userID).ToList();
                return res;
            }
        }

        public static int SubmitOrder(int?id)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_ORDER category = context.TB_ORDER.FirstOrDefault(t => t.ORDER_NO == id);//先查找出要修改的对象
                if (null != category)
                {
                    category.ORDER_STATE = "付款待发货";//修改数据
                    context.SaveChanges();
                }
                return 1;
            }
        }

        public static void ClearOrder(int userID)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_CART category = context.TB_CART.FirstOrDefault(t => t.CART_USER_ID == userID);//先查找出要修改的对象
                if (null != category)
                {
                    context.TB_CART.Remove(category);
                    context.SaveChanges();
                }
            }
        }
    }
}
