//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Janess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_SELLER
    {
        public int ID { get; set; }
        public string ACCOUNT { get; set; }
        public string PWD { get; set; }
        public string SELLER_NAME { get; set; }
        public Nullable<int> SHOP_ID { get; set; }
        public string BUYER_ADDRESS { get; set; }
        public string BUYER_TEL { get; set; }
        public Nullable<bool> PERMISSIONS { get; set; }
        public string SELLER_IMAGE_URL { get; set; }
    }
}
