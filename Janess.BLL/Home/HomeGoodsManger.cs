using Janess.DAL;
using Janess.Model;
using System.Collections.Generic;
using System;

namespace Janess.BLL.Home
{
    public class HomeGoodsManger
    {
        public static List<TB_GOODS> GetHomeGoods()
        {
            List<TB_GOODS> lstGoods = new List<TB_GOODS>();
            lstGoods = HomeGoodsDao.GetHomeGoods();
            return lstGoods;
        }

        public static List<TB_GOODS> GetHomeGoodsByNameOrType(string val)
        {
            List<TB_GOODS> lstGoods = new List<TB_GOODS>();
            lstGoods = HomeGoodsDao.GetHomeGoodsByNameOrType(val);
            return lstGoods;
        }
    }
}
