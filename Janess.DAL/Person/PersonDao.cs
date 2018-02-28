using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Janess.DAL;
using Janess.Model;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace Janess.DAL.Person
{
    public class PersonDao
    {
        public static List<Orders> GetAllOrders(int? id)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>("SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_ORDER.ORDER_USER_ID,dbo.TB_ORDER.ORDER_TIME,dbo.TB_ORDER.ORDER_STATE FROM dbo.TB_ORDER_DETAILS,dbo.TB_GOODS,dbo.TB_ORDER WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID = dbo.TB_GOODS.ID AND dbo.TB_ORDER.ORDER_NO = dbo.TB_ORDER_DETAILS.ORDER_ID AND dbo.TB_ORDER.ORDER_USER_ID="+id).ToList();
            }
            return lstGoods;
        }
        public static List<Orders> GetUnpayOrders(int?id)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>("SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_ORDER.ORDER_TIME,dbo.TB_ORDER.ORDER_STATE FROM dbo.TB_ORDER_DETAILS, dbo.TB_GOODS, dbo.TB_ORDER WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID = dbo.TB_GOODS.ID AND dbo.TB_ORDER.ORDER_NO = dbo.TB_ORDER_DETAILS.ORDER_ID AND ORDER_STATE = '未付款' AND dbo.TB_ORDER.ORDER_USER_ID="+id).ToList();
            }
            return lstGoods;
        }
        public static List<Orders> GetUnsendOrders(int? id)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>("SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_ORDER.ORDER_TIME,dbo.TB_ORDER.ORDER_STATE FROM dbo.TB_ORDER_DETAILS, dbo.TB_GOODS, dbo.TB_ORDER WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID = dbo.TB_GOODS.ID AND dbo.TB_ORDER.ORDER_NO = dbo.TB_ORDER_DETAILS.ORDER_ID AND ORDER_STATE = '付款待发货' AND dbo.TB_ORDER.ORDER_USER_ID=" + id).ToList();
            }
            return lstGoods;
        }
        public static List<Orders> GetUnsureOrders(int? id)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>("SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_ORDER.ORDER_TIME,dbo.TB_ORDER.ORDER_STATE FROM dbo.TB_ORDER_DETAILS, dbo.TB_GOODS, dbo.TB_ORDER WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID = dbo.TB_GOODS.ID AND dbo.TB_ORDER.ORDER_NO = dbo.TB_ORDER_DETAILS.ORDER_ID AND ORDER_STATE = '发货待收货' AND dbo.TB_ORDER.ORDER_USER_ID=" + id).ToList();
            }
            return lstGoods;
        }
        public static List<Orders> GetUnevaluateOrders(int? id)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>("SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_ORDER.ORDER_TIME,dbo.TB_ORDER.ORDER_STATE FROM dbo.TB_ORDER_DETAILS, dbo.TB_GOODS, dbo.TB_ORDER WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID = dbo.TB_GOODS.ID AND dbo.TB_ORDER.ORDER_NO = dbo.TB_ORDER_DETAILS.ORDER_ID AND ORDER_STATE = '待评价' AND dbo.TB_ORDER.ORDER_USER_ID=" + id).ToList();
            }
            return lstGoods;
        }
        //public static List<Orders> GetAllDetailOrders(int ORDER_NO)
        //{
        //    List<Orders> lstGoods = new List<Orders>();
        //    using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
        //    {
        //        lstGoods = context.Database.SqlQuery<Orders>(@"SELECT DISTINCT dbo.TB_GOODS.GOODS_NAME,dbo.TB_GOODS.GOODS_PRICE,dbo.TB_GOODS.GOODS_IMAGE_URL,dbo.TB_ORDER_DETAILS.DETORSER_GOODS_NUM,dbo.TB_ORDER.ORDER_STATE FROM dbo.TB_ORDER_DETAILS,dbo.TB_GOODS,dbo.TB_ORDER  WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID=dbo.TB_GOODS.ID AND dbo.TB_ORDER.ORDER_NO=dbo.TB_ORDER_DETAILS.ORDER_ID AND ORDER_NO={0};", ORDER_NO).ToList();
        //    }
        //    return lstGoods;
        //}

        public static List<Orders> GetAllDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>(@"SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_GOODS.GOODS_NAME,dbo.TB_GOODS.GOODS_PRICE,dbo.TB_GOODS.GOODS_IMAGE_URL,
                    dbo.TB_ORDER_DETAILS.DETORSER_GOODS_NUM,dbo.TB_ORDER.ORDER_STATE 
                    FROM dbo.TB_ORDER_DETAILS,dbo.TB_GOODS,dbo.TB_ORDER  
                    WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID=dbo.TB_GOODS.ID 
                    AND dbo.TB_ORDER.ORDER_NO=dbo.TB_ORDER_DETAILS.ORDER_ID 
                    AND ORDER_NO IN (" + multiOrders+");").ToList();
            }
            return lstGoods;
        }
        public static List<Orders> GetUnpayDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>(@"SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_GOODS.GOODS_NAME,dbo.TB_GOODS.GOODS_PRICE,dbo.TB_GOODS.GOODS_IMAGE_URL,
                    dbo.TB_ORDER_DETAILS.DETORSER_GOODS_NUM,dbo.TB_ORDER.ORDER_STATE 
                    FROM dbo.TB_ORDER_DETAILS,dbo.TB_GOODS,dbo.TB_ORDER  
                    WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID=dbo.TB_GOODS.ID 
                    AND dbo.TB_ORDER.ORDER_NO=dbo.TB_ORDER_DETAILS.ORDER_ID 
                    AND ORDER_STATE='未付款'
                    AND ORDER_NO IN (" + multiOrders + ");").ToList();
            }
            return lstGoods;
        }
        public static List<Orders> GetUnsendDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>(@"SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_GOODS.GOODS_NAME,dbo.TB_GOODS.GOODS_PRICE,dbo.TB_GOODS.GOODS_IMAGE_URL,
                    dbo.TB_ORDER_DETAILS.DETORSER_GOODS_NUM,dbo.TB_ORDER.ORDER_STATE 
                    FROM dbo.TB_ORDER_DETAILS,dbo.TB_GOODS,dbo.TB_ORDER  
                    WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID=dbo.TB_GOODS.ID 
                    AND dbo.TB_ORDER.ORDER_NO=dbo.TB_ORDER_DETAILS.ORDER_ID 
                    AND ORDER_STATE='付款待发货'
                    AND ORDER_NO IN (" + multiOrders + ");").ToList();
            }
            return lstGoods;
        }
        public static List<Orders> GetUnsureDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>(@"SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_GOODS.GOODS_NAME,dbo.TB_GOODS.GOODS_PRICE,dbo.TB_GOODS.GOODS_IMAGE_URL,
                    dbo.TB_ORDER_DETAILS.DETORSER_GOODS_NUM,dbo.TB_ORDER.ORDER_STATE 
                    FROM dbo.TB_ORDER_DETAILS,dbo.TB_GOODS,dbo.TB_ORDER  
                    WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID=dbo.TB_GOODS.ID 
                    AND dbo.TB_ORDER.ORDER_NO=dbo.TB_ORDER_DETAILS.ORDER_ID 
                    AND ORDER_STATE='发货待收货'
                    AND ORDER_NO IN (" + multiOrders + ");").ToList();
            }
            return lstGoods;
        }
        public static List<Orders> GetUnevaluateDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Orders>(@"SELECT DISTINCT dbo.TB_ORDER.ORDER_NO,dbo.TB_GOODS.GOODS_NAME,dbo.TB_GOODS.GOODS_PRICE,dbo.TB_GOODS.GOODS_IMAGE_URL,
                    dbo.TB_ORDER_DETAILS.DETORSER_GOODS_NUM,dbo.TB_ORDER.ORDER_STATE 
                    FROM dbo.TB_ORDER_DETAILS,dbo.TB_GOODS,dbo.TB_ORDER  
                    WHERE dbo.TB_ORDER_DETAILS.DETORSER_GOODS_ID=dbo.TB_GOODS.ID 
                    AND dbo.TB_ORDER.ORDER_NO=dbo.TB_ORDER_DETAILS.ORDER_ID 
                    AND ORDER_STATE='待评价'
                    AND ORDER_NO IN (" + multiOrders + ");").ToList();
            }
            return lstGoods;
        }
        public static List<Collect_Goods> GetCollectGoodsInfo(int? id)
        {
            List<Collect_Goods> lstGoods = new List<Collect_Goods>();
            using (JANESS_SYSTEM_DBEntities context=new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<Collect_Goods>("SELECT DISTINCT dbo.TB_GOODS.GOODS_NAME,TB_GOODS.ID,dbo.TB_GOODS.GOODS_PRICE,dbo.TB_GOODS.GOODS_IMAGE_URL FROM dbo.TB_GOODS, dbo.TB_BUYER_COLLECT, dbo.TB_BUYER  WHERE dbo.TB_BUYER_COLLECT.COLLECT_ID = dbo.TB_GOODS.ID AND dbo.TB_BUYER_COLLECT.ACCOUNT = dbo.TB_BUYER.ID AND dbo.TB_BUYER.ID = " + id).ToList();
            }
            return lstGoods;
        }
        public static List<Collect_Shops> GetCollectShopsInfo(int? id)
        {
            List<Collect_Shops> lstShops = new List<Collect_Shops>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstShops = context.Database.SqlQuery<Collect_Shops>("SELECT DISTINCT dbo.TB_SHOP.SHOP_NAME,TB_SHOP.ID,dbo.TB_SHOP.SHOP_IMAGE_URL FROM dbo.TB_SHOP, dbo.TB_BUYER_COLLECT, dbo.TB_BUYER WHERE dbo.TB_BUYER_COLLECT.COLLECT_ID = dbo.TB_SHOP.ID AND dbo.TB_BUYER_COLLECT.ACCOUNT = dbo.TB_BUYER.ID AND dbo.TB_BUYER.ID = " + id).ToList();
            }
            return lstShops;
        }
        public static List<TB_BUYER> GetBuyersInfo(int? id)
        {
            List<TB_BUYER> lstBuyers = new List<TB_BUYER>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstBuyers = context.Database.SqlQuery<TB_BUYER>("SELECT * FROM TB_BUYER WHERE id="+id).ToList();
            }
            return lstBuyers;
        }
        public static TB_BUYER GetBuyerById(int id)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var res = context.TB_BUYER.FirstOrDefault(t => t.ID == id);
                return res;
            }
        }
        public static List<TB_GOODS> GetShopsInfo(int? id)
        {
            List<TB_GOODS> lstBuyers = new List<TB_GOODS>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstBuyers = context.Database.SqlQuery<TB_GOODS>("SELECT * FROM dbo.TB_GOODS WHERE GOODS_SHOP_ID=" + id).ToList();
            }
            return lstBuyers;
        }
        public static List<TB_SHOP> GetShopInfo(int? id)
        {
            List<TB_SHOP> lstBuyers = new List<TB_SHOP>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstBuyers = context.Database.SqlQuery<TB_SHOP>("SELECT * FROM dbo.TB_SHOP WHERE ID=" + id).ToList();
            }
            return lstBuyers;
        }
        
        public static int AltOrder(TB_ORDER order,int ORDER_NO)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_ORDER ord = context.TB_ORDER.FirstOrDefault(t => t.ORDER_NO == order.ORDER_NO);
                if (null != order)
                {
                    ord.ORDER_STATE = "完成";
                }
                return context.SaveChanges();
            }
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        public static int AltBuyersInfo(TB_BUYER buyer,int id)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_BUYER category = context.TB_BUYER.FirstOrDefault(t =>t.ID == buyer.ID);//先查找出要修改的对象
                if (null != category)
                {
                    category.BUYER_NAME = buyer.BUYER_NAME;
                    category.BUYER_ADDRESS = buyer.BUYER_ADDRESS;
                    category.BUYER_TEL = buyer.BUYER_TEL;
                }
                return context.SaveChanges();
            }
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public static int AltPwd(TB_BUYER buyer,int id)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_BUYER category = context.TB_BUYER.FirstOrDefault(t => t.ID == buyer.ID);//先查找出要修改的对象
                if (null != category)
                {
                    category.PWD = buyer.PWD;
                }
                return context.SaveChanges();
            }
        }
    }
}
