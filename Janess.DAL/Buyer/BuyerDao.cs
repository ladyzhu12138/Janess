using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Janess.Model;

namespace Janess.DAL.Buyer
{
    public class BuyerDao
    {
        /// <summary>
        /// 获取商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<IntroductionDetail> GetGoodsByID(int id)
        {
            List<IntroductionDetail> lstInt = new List<IntroductionDetail>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstInt = context.Database.SqlQuery<IntroductionDetail>(@"SELECT TB_GOODS.ID, GOODS_NAME, GOODS_PRICE, GOODS_DESCRIBE, GOODS_SHOP_ID, GOODS_IMAGE_URL, 
                                                                                SHOP_NAME,GOODS_REPERTORY
                                                                                FROM dbo.TB_GOODS 
                                                                            INNER JOIN dbo.TB_SHOP ON TB_SHOP.ID = TB_GOODS.GOODS_SHOP_ID 
                                                                            WHERE TB_GOODS.ID = {0};",id).ToList();
            }
            return lstInt;
        }

        public static List<CartDetail> GetCartGoods(int userID)
        {
            List<CartDetail> lstCart = new List<CartDetail>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstCart = context.Database.SqlQuery<CartDetail>(@"SELECT GOODS_SHOP_ID,TB_CART.ID,GOODS_NAME,GOODS_PRICE,GOODS_IMAGE_URL,CART_GOODS_ID,CART_GOODS_NUM FROM dbo.TB_CART 
                                                                    INNER JOIN dbo.TB_GOODS ON  TB_GOODS.ID = CART_GOODS_ID
                                                                    WHERE CART_USER_ID = {0};", userID).ToList();
            }
            return lstCart;
        }

        public static int AddToOrder(int userID, int shopID, int orderID, double price, string orderState)
        {
            int res;
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                res = context.Database.ExecuteSqlCommand(@"INSERT INTO dbo.TB_ORDER
		        ( ORDER_USER_ID ,
		          ORDER_TIME ,
		          ORDER_SHOP_ID ,
		          ORDER_NO ,
		          ORDER_ALLPRICE ,
		          ORDER_STATE
		        )
		VALUES  ( {0} , -- ORDER_USER_ID - int
		          GETDATE() , -- ORDER_TIME - datetime
		          {1} , -- ORDER_SHOP_ID - int 
		          {2} , -- ORDER_NO - int
		          {3} , -- ORDER_ALLPRICE - int
		          {4}  -- ORDER_STATE - varchar(20)
		        )",userID,shopID,orderID,price,orderState);
            }

            return res;
        }

        public static int AddToOrderDetail(string orderID, int goodsID, int goodsNumber)
        {
            int res;
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                res = context.Database.ExecuteSqlCommand(@"INSERT INTO dbo.TB_ORDER_DETAILS
                                                                ( ORDER_ID ,
                                                                  DETORSER_GOODS_ID ,
                                                                  DETORSER_GOODS_NUM
                                                                )
                                                        VALUES  ( {0} , 
                                                                  {1}, 
                                                                  {2}  
                                                                )",orderID, goodsID, goodsNumber);
            }

            return res;
        }

        public static int DeleteCartGoods(int cartID)
        {
            int res;
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                res = context.Database.ExecuteSqlCommand(@"DELETE FROM dbo.TB_CART WHERE ID = {0};",cartID);
            }

            return res;
        }

        public static int AddToCollect(int userID, int collectID, string type)
        {
            int res;
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                res = context.Database.ExecuteSqlCommand(@"INSERT INTO dbo.TB_BUYER_COLLECT
                                                                ( COLLECT_TYPE, COLLECT_ID, ACCOUNT )
                                                        VALUES  ( {0}, 
                                                                 {1},
                                                                  {2}
                                                                  )",type,collectID,userID);
            }
           
            return res;
        }

        public static int GetCartGoodsNum(int userID)
        {
            List<int> lst = new List<int>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lst = context.Database.SqlQuery<int>(@"SELECT COUNT(*) FROM dbo.TB_CART WHERE CART_USER_ID = {0};",userID).ToList();
            }
            return lst[0];
        }

        public static int AddToCart(int goodsID, int shopID, int goodsNum, int userID)
        {
            int res;
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                res = context.Database.ExecuteSqlCommand(@"INSERT INTO dbo.TB_CART
                                                            ( CART_SHOP_ID ,
                                                              CART_GOODS_ID ,
                                                              CART_GOODS_NUM ,
                                                              CART_USER_ID
                                                            )
                                                             VALUES  ( {0}, 
                                                              {1}, 
                                                              {2}, 
                                                              {3}  
                                                            )", shopID, goodsID, goodsNum, userID);
            }
            return res;
        }

        public static List<Evaluate> GetEvaluate(int goodsID)
        {
            List<Evaluate> lstEvaluate = new List<Evaluate>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstEvaluate = context.Database.SqlQuery<Evaluate>(@"SELECT BUYER_NAME,BUYER_IMAGE_URL,EVALUATE_CONTENT,EVALUATE_STAR 
                                                                            FROM dbo.TB_EVALUATE_GOODS 
                                                                            INNER JOIN dbo.TB_BUYER ON TB_BUYER.ID = EVALUATE_USER_ID WHERE GOODS_ID = {0};", goodsID).ToList();
            }
            return lstEvaluate;
        }
    }
}
