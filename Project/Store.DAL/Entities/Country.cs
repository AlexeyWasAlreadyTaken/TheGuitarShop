namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            ManufCountryItems = new HashSet<Item>();
            BrandCountryItems = new HashSet<Item>();
        }
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Item> ManufCountryItems { get; set; }

        public virtual ICollection<Item> BrandCountryItems { get; set; }
    }
}
