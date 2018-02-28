using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Janess.DAL.Person;
using Janess.Model;

namespace Janess.BLL.Person
{
    public class PersonMgr
    {
        //public static List<Orders> GetAllDetailOrders(int ORDER_NO)
        //{
        //    List<Orders> lstGoods = new List<Orders>();
        //    lstGoods = PersonDao.GetAllDetailOrders(ORDER_NO);
        //    return lstGoods;
        //}
        public static List<Orders> GetAllDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetAllDetailOrders(multiOrders);
            return lstGoods;
        }
        public static List<Orders> GetUnpayDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetUnpayDetailOrders(multiOrders);
            return lstGoods;
        }
        public static List<Orders> GetUnsendDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetUnsendDetailOrders(multiOrders);
            return lstGoods;
        }
        public static List<Orders> GetUnsureDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetUnsureDetailOrders(multiOrders);
            return lstGoods;
        }
        public static List<Orders> GetUnevaluateOrders(int? id)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetUnevaluateOrders(id);
            return lstGoods;
        }
        public static List<Orders> GetUnevaluateDetailOrders(string multiOrders)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetUnevaluateDetailOrders(multiOrders);
            return lstGoods;
        }
        public static List<Orders> GetAllOrders(int? id)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetAllOrders(id);
            return lstGoods;
        }
        public static List<Orders> GetUnpayOrders(int? id)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetUnpayOrders(id);
            return lstGoods;
        }
        public static List<Orders> GetUnsendOrders(int? id)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetUnsendOrders(id);
            return lstGoods;
        }
        public static List<Orders> GetUnsureOrders(int? id)
        {
            List<Orders> lstGoods = new List<Orders>();
            lstGoods = PersonDao.GetUnsureOrders(id);
            return lstGoods;
        }
        
        public static List<Collect_Goods> GetCollectGoodsInfo(int? id)
        {
            List<Collect_Goods> lstGoods = new List<Collect_Goods>();
            lstGoods = PersonDao.GetCollectGoodsInfo(id);
            return lstGoods;
        }
        public static List<Collect_Shops> GetCollectShopsInfo(int? id)
        {
            List<Collect_Shops> lstShops = new List<Collect_Shops>();
            lstShops = PersonDao.GetCollectShopsInfo(id);
            return lstShops;
        }
        public static List<TB_BUYER> GetBuyersInfo(int? id)
        {
            List<TB_BUYER> lstBuyers = new List<TB_BUYER>();
            lstBuyers = PersonDao.GetBuyersInfo(id);
            return lstBuyers;
        }
        public static bool AltBuyersInfo(TB_BUYER buyer,int id)
        {
            int res = PersonDao.AltBuyersInfo(buyer,id);
            return res > 0;
        }
        public static bool AltPwd(TB_BUYER buyer,int id)
        {
            int res = PersonDao.AltPwd(buyer,id);
            return res > 0;
        }
        public static TB_BUYER GetPersonById(int id)
        {
            return PersonDao.GetBuyerById(id);
        }
        public static bool AltOrder(TB_ORDER order,int ORDER_NO)
        {
            int res= PersonDao.AltOrder(order,ORDER_NO);
            return res > 0;
        }
        public static List<TB_GOODS> GetShopsInfo(int? id)
        {
            List<TB_GOODS> lstShops = new List<TB_GOODS>();
            lstShops = PersonDao.GetShopsInfo(id);
            return lstShops;
        }
        public static List<TB_SHOP> GetShopInfo(int? id)
        {
            List<TB_SHOP> lstShops = new List<TB_SHOP>();
            lstShops = PersonDao.GetShopInfo(id);
            return lstShops;
        }
    }
}
