using Janess.DAL.Seller;
using Janess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.BLL.Seller
{
    public class SellerMgr
    {
        //订单查询
        public static List<TB_ORDER> OrderQuery()
        {
            return SellerDao.OrderQuery();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Pager<TB_ORDER> GetArticlesByPager(PageParam page,int shopID)
        {
            return SellerDao.GetArticlesByPager(page,shopID);
        }

        /// <summary>
        /// 通过订单ID修改订单状态（卖家派送）
        /// </summary>
        /// <param name="id"></param>
        public static void UpdateStateByID(int id)
        {
            SellerDao.UpdateStateByID(id);
        }

        /// <summary>
        /// 通过店铺ID查询店铺信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TB_SHOP GetShopByID(int id)
        {
            return SellerDao.GetShopByID(id);
        }

        /// <summary>
        /// 修改店铺信息
        /// </summary>
        /// <param name="shop"></param>
        /// <returns></returns>
        public static bool UpdateShopInfo(TB_SHOP shop)
        {
            int res = SellerDao.UpdateShopInfo(shop);
            return res > 0;
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public static bool Add(TB_GOODS goods)
        {
            int res = SellerDao.Add(goods);
            return res > 0;
        }

        public static bool Update(TB_GOODS goods)
        {
            int res = SellerDao.Update(goods);
            return res > 0;
        }

        /// <summary>
        /// 根据店铺ID返回所有商品信息
        /// </summary>
        /// <param name="shopID"></param>
        /// <returns></returns>
        public static List<TB_GOODS> GetGoodsInfoByShopID(int shopID)
        {
            List<TB_GOODS> list = new List<TB_GOODS>();
            list = SellerDao.GetGoodsInfoByShopID(shopID);

            return list;
        }

        public static bool RemoveGoods(int id)
        {
            int res = SellerDao.RemoveGoods(id);
            return res > 0;
        }

        public static List<TB_GOODS> SearchGoods(int shopID, string keyWord)
        {
            List<TB_GOODS> list = new List<TB_GOODS>();
            list = SellerDao.SearchGoods(shopID,keyWord);

            return list;
        }

        public static TB_GOODS GetGoodsInfoByID (int id)
        {
            return SellerDao.GetGoodsInfoByID(id);
        }
    }
}
