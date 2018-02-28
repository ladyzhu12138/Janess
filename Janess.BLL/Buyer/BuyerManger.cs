using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Janess.Model;
using Janess.DAL.Buyer;

namespace Janess.BLL.Buyer
{
    public class BuyerManger
    {
        public static List<IntroductionDetail> GetGoodsByID(int id)
        {
            List<IntroductionDetail> lstInt = BuyerDao.GetGoodsByID(id);
            return lstInt;
        }

        public static List<Evaluate> GetEvaluate(int goodsID)
        {
            List<Evaluate> lstEvaluate = BuyerDao.GetEvaluate(goodsID);
            return lstEvaluate;
        }

        public static bool AddToCart(int goodsID, int shopID, int goodsNum, int userID)
        {
            int res = BuyerDao.AddToCart(goodsID,shopID,goodsNum,userID);
            return res > 0;
        }

        public static int GetCartGoodsNum(int userID)
        {
            int res = BuyerDao.GetCartGoodsNum(userID);
            return res;
        }

        public static List<CartDetail> GetCartGoods(int userID)
        {
            List<CartDetail> lstCart = BuyerDao.GetCartGoods(userID);
            return lstCart;
        }

        public static bool AddToCollect(int userID, int collectID, string type)
        {
            int res = BuyerDao.AddToCollect(userID, collectID, type);
            return res > 0;
        }

        public static bool DeleteCartGoods(int cartID)
        {
            int res = BuyerDao.DeleteCartGoods(cartID);
            return res > 0;
        }

        public static bool AddToOrderDetail(string orderID, int goodsID, int goodsNumber)
        {
            int res = BuyerDao.AddToOrderDetail(orderID, goodsID, goodsNumber);
            return res > 0;
        }

        public static bool AddToOrder(int userID, int shopID, int orderID, double price, string orderState)
        {
            int res = BuyerDao.AddToOrder(userID, shopID, orderID, price, orderState);
            return res > 0;
        }
    }
}
