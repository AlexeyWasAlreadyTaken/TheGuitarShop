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
    
    public partial class CategoryCharacteristic
    {
        public System.Guid id { get; set; }
        public Nullable<System.Guid> CategoryID { get; set; }
        public Nullable<System.Guid> CharacteristicID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Characteristic Characteristic { get; set; }
    }
}
