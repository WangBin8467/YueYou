﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YueYou.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class YueYouEntities : DbContext
    {
        public YueYouEntities()
            : base("name=YueYouEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Collection> Collection { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Guide> Guide { get; set; }
        public virtual DbSet<GuideDetails> GuideDetails { get; set; }
        public virtual DbSet<Lunbo> Lunbo { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Routing_arrangement> Routing_arrangement { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<view_area> view_area { get; set; }
        public virtual DbSet<view_collection> view_collection { get; set; }
        public virtual DbSet<view_comment> view_comment { get; set; }
        public virtual DbSet<view_guide> view_guide { get; set; }
        public virtual DbSet<view_order> view_order { get; set; }
    }
}
