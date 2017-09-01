namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }

        public Guid PurposePriceId { get; set; }

        public Guid OrderId { get; set; }

        public int Count { get; set; }

        public Guid PurposeId { get; set; }

        public virtual Item Item { get; set; }

        public virtual Order Order { get; set; }

        public virtual Purpose Purpose { get; set; }

        public virtual PurposePrice PurposePrice { get; set; }
    }
}
