namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("purposePrice")]
    public partial class PurposePrice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurposePrice()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid? PurposeId { get; set; }

        public double? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public Guid CurencyID { get; set; }

        public virtual Curency Curency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual Purpose Purpose { get; set; }
    }
}
