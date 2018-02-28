using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.Model
{
    public class IntroductionDetail
    {
        public int ID { get; set; }
        public string GOODS_NAME { get; set; }
        public double GOODS_PRICE { get; set; }
        public string GOODS_DESCRIBE { get; set; }
        public int GOODS_SHOP_ID { get; set; }
        public string GOODS_IMAGE_URL { get; set; }
        public string SHOP_NAME { get; set; }
        public int GOODS_REPERTORY { get; set; }
    }
}
