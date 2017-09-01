namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemImage")]
    public partial class ItemImage
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }

        public string ImageURL { get; set; }

        public string VideoURL { get; set; }

        public virtual Item Item { get; set; }
    }
}
