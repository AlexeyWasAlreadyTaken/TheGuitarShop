namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            Comments = new HashSet<Comment>();
            ItemCharacteristics = new HashSet<ItemCharacteristic>();
            ItemImages = new HashSet<ItemImage>();
            OrderItems = new HashSet<OrderItem>();
            Purposes = new HashSet<Purpose>();
        }
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public Guid? CategoryID { get; set; }

        public Guid? BrandID { get; set; }
        //---------------------------------
        public Guid? ManufCountryID { get; set; }

        public Guid? BrandCountryID { get; set; }

        //[ForeignKey("ManufCountryID")]
        public virtual Country ManufCountry { get; set; }
        //[ForeignKey("BrandCountryID")]
        public virtual Country BrandCountry { get; set; }
        //--------------------------------------------
        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemCharacteristic> ItemCharacteristics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemImage> ItemImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purpose> Purposes { get; set; }
    }
}
