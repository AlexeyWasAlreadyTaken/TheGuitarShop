//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GSWA.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderItem
    {
        public System.Guid id { get; set; }
        public System.Guid ItemId { get; set; }
        public System.Guid purposePriceId { get; set; }
        public System.Guid OrderId { get; set; }
        public int count { get; set; }
        public System.Guid purposeId { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
        public virtual Purpose Purpose { get; set; }
        public virtual purposePrice purposePrice { get; set; }
    }
}
