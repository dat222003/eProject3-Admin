//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABCD_Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShopImage
    {
        public int id { get; set; }
        public int shopId { get; set; }
        public string imagePath { get; set; }
    
        public virtual Shop Shop { get; set; }
    }
}
