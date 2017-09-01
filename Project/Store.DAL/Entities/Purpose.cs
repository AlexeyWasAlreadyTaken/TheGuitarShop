namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purpose")]
    public partial class Purpose
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purpose()
        {
            OrderItems = new HashSet<OrderItem>();
            PurposePrices = new HashSet<PurposePrice>();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid? ItemId { get; set; }

        public Guid? AvailabilityTypeID { get; set; }

        public bool? IsPromo { get; set; }

        public virtual AvailabilityType AvailabilityType { get; set; }

        public virtual Item Item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurposePrice> PurposePrices { get; set; }
    }
}
