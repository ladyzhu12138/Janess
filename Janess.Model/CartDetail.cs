using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.Model
{
   public class CartDetail
    {
        public int GOODS_SHOP_ID { get; set; }
        public int ID { get; set; }
        public int CART_GOODS_ID { get; set; }
        public int CART_GOODS_NUM { get; set; }
        public string GOODS_NAME { get; set; }
        public double GOODS_PRICE { get; set; }
        public string GOODS_IMAGE_URL { get; set; }
    }
}
