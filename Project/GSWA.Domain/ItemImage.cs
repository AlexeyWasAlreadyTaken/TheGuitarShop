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
    
    public partial class ItemImage
    {
        public System.Guid id { get; set; }
        public System.Guid ItemId { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
