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
    
    public partial class ItemCharacteristic
    {
        public System.Guid id { get; set; }
        public Nullable<System.Guid> ItemID { get; set; }
        public Nullable<System.Guid> CharacteristicID { get; set; }
        public Nullable<System.Guid> CharVarID { get; set; }
    
        public virtual Characteristic Characteristic { get; set; }
        public virtual CharValue CharValue { get; set; }
        public virtual Item Item { get; set; }
    }
}
