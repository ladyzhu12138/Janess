using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.Model
{
    public class Orders
    {
        public int ORDER_NO { get; set; }
        public DateTime ORDER_TIME { get; set; }
        public string GOODS_NAME { get; set; }
        public double GOODS_PRICE { get; set; }
        public string GOODS_IMAGE_URL { get; set; }
        public int DETORSER_GOODS_NUM { get; set; }
        public string ORDER_STATE { get; set; }
    }
}
