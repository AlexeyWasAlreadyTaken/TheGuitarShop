namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ItemCharacteristic
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? ItemID { get; set; }

        public Guid? CharacteristicID { get; set; }

        public Guid? CharValueID { get; set; }

        public virtual Characteristic Characteristic { get; set; }

        public virtual CharValue CharValue { get; set; }

        public virtual Item Item { get; set; }
    }
}
