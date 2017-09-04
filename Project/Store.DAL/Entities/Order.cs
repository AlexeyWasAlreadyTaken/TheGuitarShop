namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid? StatusId { get; set; }

        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser  ApplicationUser { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public Guid? ContactId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        public DateTime? Date { get; set; }

        public Guid? DeliveryTypeId { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public virtual DeliveryType DeliveryType { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
