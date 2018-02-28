using Janess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.DAL.Seller
{
    public class SellerDao
    {
        //订单查询
        public static List<TB_ORDER> OrderQuery()
        {
            //实例化EMD对象ARTICLE_DBEntities，数据库上下文
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var list = context.Database.SqlQuery<TB_ORDER>("SELECT * FROM TB_ORDER").ToList();

                return list;
            }

        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Pager<TB_ORDER> GetArticlesByPager(PageParam page, int shopID)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                Pager<TB_ORDER> pg = new Pager<TB_ORDER>();
                //var res = context.TB_ORDER.Where(t => t.ORDER_STATE == "付款待发货");
                var res = context.Database.SqlQuery<TB_ORDER>("SELECT * FROM TB_ORDER WHERE ORDER_STATE='付款待发货' AND ORDER_SHOP_ID=" + shopID + " AND LEN(ORDER_RIDER_ID)>0").ToList();
                pg.Total = res.Count();
                pg.Rows = res.OrderBy(t => t.ORDER_TIME).Skip(page.Skip).Take(page.PageSize).ToList();

                return pg;
            }
        }

        /// <summary>
        /// 通过订单ID修改订单状态（卖家派送）
        /// </summary>
        /// <param name="id"></param>
        public static void UpdateStateByID(int id)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_ORDER category = context.TB_ORDER.FirstOrDefault(t => t.ID == id);//先查找出要修改的对象
                if (null != category)
                {
                    category.ORDER_STATE = "发货待收货";//修改数据
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 通过店铺ID查询店铺信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TB_SHOP GetShopByID(int id)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                //var list = context.Database.SqlQuery<TB_SHOP>("SELECT * FROM TB_SHOP WHERE ID=" + id).ToList();
                var res = context.TB_SHOP.FirstOrDefault(t => t.ID == id);

                return res;
            }
        }

        /// <summary>
        /// 修改店铺信息
        /// </summary>
        /// <param name="shop"></param>
        /// <returns></returns>
        public static int UpdateShopInfo(TB_SHOP shop)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_SHOP category = context.TB_SHOP.FirstOrDefault(t => t.ID == shop.ID);//先查找出要修改的对象
                if (null != category)
                {
                    category.SHOP_NAME = shop.SHOP_NAME;
                    category.SHOP_ADDRESS = shop.SHOP_ADDRESS;
                }
                return context.SaveChanges();
            }
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public static int Add(TB_GOODS goods)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_GOODS obj = new TB_GOODS();
                obj.GOODS_NAME = goods.GOODS_NAME;
                obj.GOODS_PRICE = goods.GOODS_PRICE;
                obj.GOODS_TYPE = goods.GOODS_TYPE;
                obj.GOODS_DESCRIBE = goods.GOODS_DESCRIBE;
                obj.GOODS_REPERTORY = goods.GOODS_REPERTORY;
                obj.GOODS_SHOP_ID = goods.GOODS_SHOP_ID;
                obj.GOODS_IMAGE_URL = goods.GOODS_IMAGE_URL;

                context.TB_GOODS.Add(obj);

                return context.SaveChanges();
            }
        }

        public static int Update(TB_GOODS goods)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                TB_GOODS category = context.TB_GOODS.FirstOrDefault(t => t.ID == goods.ID);
                if (null != category)
                {
                    category.GOODS_NAME = goods.GOODS_NAME;
                    category.GOODS_PRICE = goods.GOODS_PRICE;
                    category.GOODS_TYPE = goods.GOODS_TYPE;
                    category.GOODS_DESCRIBE = goods.GOODS_DESCRIBE;
                    category.GOODS_REPERTORY = goods.GOODS_REPERTORY;
                    category.GOODS_IMAGE_URL = goods.GOODS_IMAGE_URL;
                }
                return context.SaveChanges();
            }
        }

        /// <summary>
        /// 根据店铺ID返回所有商品信息
        /// </summary>
        /// <param name="shopID"></param>
        /// <returns></returns>
        public static List<TB_GOODS> GetGoodsInfoByShopID(int shopID)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var list = context.Database.SqlQuery<TB_GOODS>("SELECT * FROM TB_GOODS WHERE GOODS_SHOP_ID=" + shopID).ToList();

                return list;
            }
        }

        public static int RemoveGoods(int id)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var category = context.TB_GOODS.FirstOrDefault(t => t.ID == id);
                if (null != category)
                {
                    context.TB_GOODS.Remove(category);
                }
                return context.SaveChanges();
            }
        }

        public static List<TB_GOODS> SearchGoods(int shopID, string keyWord)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var list = context.Database.SqlQuery<TB_GOODS>("SELECT * FROM TB_GOODS WHERE GOODS_SHOP_ID=" + shopID + " AND GOODS_NAME LIKE '%" + keyWord + "%'").ToList();

                return list;
            }
        }

        public static TB_GOODS GetGoodsInfoByID(int id)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var res = context.TB_GOODS.FirstOrDefault(t => t.ID == id);

                return res;
            }
        }
    }
}
