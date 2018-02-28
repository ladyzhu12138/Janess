using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.Model
{
    public class OrderZong
    {
        public int ID { get; set; }
        public int ORDER_SHOP_ID { get; set; }
        public int ORDER_USER_ID { get; set; }
        public string BUYER_NAME { get; set; }
        public string BUYER_ADDRESS { get; set; }
        public string SHOP_NAME { get; set; }
        public string SHOP_ADDRESS { get; set; }
        public int ORDER_RIDER_ID { get; set; }
        public DateTime ORDER_TIME { get; set; }
        public string ORDER_STATE { get; set; }
        public int ORDER_ALLPRICE { get; set; }
        public int ORDER_ID { get; set; }

    }
}
