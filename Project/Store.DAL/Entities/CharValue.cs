namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CharValue")]
    public partial class CharValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CharValue()
        {
            ItemCharacteristics = new HashSet<ItemCharacteristic>();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid CharacteristicId { get; set; }
        public virtual Characteristic Characteristic { get; set; }

        public int? IntVal { get; set; }

        public double? FloatVal { get; set; }

        [StringLength(200)]
        public string StrVal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemCharacteristic> ItemCharacteristics { get; set; }
    }
}
