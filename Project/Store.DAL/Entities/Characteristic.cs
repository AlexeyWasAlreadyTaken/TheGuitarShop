namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Characteristic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Characteristic()
        {
            CategoryCharacteristics = new HashSet<CategoryCharacteristic>();
            ItemCharacteristics = new HashSet<ItemCharacteristic>();
        }
        [Key]
        public Guid Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryCharacteristic> CategoryCharacteristics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemCharacteristic> ItemCharacteristics { get; set; }

        public virtual ICollection<CharValue> CharValues { get; set; }
    }
}
