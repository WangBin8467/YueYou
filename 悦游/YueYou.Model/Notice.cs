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
    
    public partial class Notice
    {
        public int Notice_id { get; set; }
        public int Admin_id { get; set; }
        public System.DateTime Notice_time { get; set; }
        public string Notice_contents { get; set; }
    
        public virtual Admin Admin { get; set; }
    }
}
