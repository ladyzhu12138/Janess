﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JANESS_SYSTEM_DBEntities : DbContext
    {
        public JANESS_SYSTEM_DBEntities()
            : base("name=JANESS_SYSTEM_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_ADMIN> TB_ADMIN { get; set; }
        public virtual DbSet<TB_BUYER> TB_BUYER { get; set; }
        public virtual DbSet<TB_BUYER_COLLECT> TB_BUYER_COLLECT { get; set; }
        public virtual DbSet<TB_CART> TB_CART { get; set; }
        public virtual DbSet<TB_EVALUATE_GOODS> TB_EVALUATE_GOODS { get; set; }
        public virtual DbSet<TB_EVALUATE_RIDER> TB_EVALUATE_RIDER { get; set; }
        public virtual DbSet<TB_FLOW> TB_FLOW { get; set; }
        public virtual DbSet<TB_GOODS> TB_GOODS { get; set; }
        public virtual DbSet<TB_LOG> TB_LOG { get; set; }
        public virtual DbSet<TB_RIDER> TB_RIDER { get; set; }
        public virtual DbSet<TB_SELLER> TB_SELLER { get; set; }
        public virtual DbSet<TB_SHOP> TB_SHOP { get; set; }
        public virtual DbSet<TB_ORDER> TB_ORDER { get; set; }
        public virtual DbSet<Order> TB_ORDER_DETAILS { get; set; }
    }
}
