//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Guide
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guide()
        {
            this.Collection = new HashSet<Collection>();
            this.Comment = new HashSet<Comment>();
            this.News = new HashSet<News>();
            this.Orders = new HashSet<Orders>();
            this.Reply = new HashSet<Reply>();
            this.Routing_arrangement = new HashSet<Routing_arrangement>();
        }
    
        public int Guide_id { get; set; }
        public string Guide_rname { get; set; }
        public string Guide_pwd { get; set; }
        public string Guide_sex { get; set; }
        public int Guide_age { get; set; }
        public string Guide_photo { get; set; }
        public string Guide_phone { get; set; }
        public string Guide_mail { get; set; }
        public string Guide_area { get; set; }
        public Nullable<decimal> Like { get; set; }
        public int GuideDetails_id { get; set; }
        public string Country { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collection> Collection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual GuideDetails GuideDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Reply { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Routing_arrangement> Routing_arrangement { get; set; }
    }
}
