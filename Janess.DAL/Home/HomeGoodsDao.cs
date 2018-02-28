using Janess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.DAL
{
    public class HomeGoodsDao
    {
        public static List<TB_GOODS> GetHomeGoods()
        {
            List<TB_GOODS> lstGoods = new List<TB_GOODS>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<TB_GOODS>("SELECT * FROM TB_GOODS").ToList();
            }
            return lstGoods;
        }

        public static List<TB_GOODS> GetHomeGoodsByNameOrType(string val)
        {
            List<TB_GOODS> lstGoods = new List<TB_GOODS>();
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                lstGoods = context.Database.SqlQuery<TB_GOODS>("SELECT * FROM TB_GOODS WHERE GOODS_NAME LIKE {0} OR GOODS_TYPE LIKE {1}","%"+val+"%","%"+val+"%").ToList();
            }
            return lstGoods;
        }

    }
}
