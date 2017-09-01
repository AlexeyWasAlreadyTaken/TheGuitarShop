namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryCharacteristic")]
    public partial class CategoryCharacteristic
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? CategoryID { get; set; }

        public Guid? CharacteristicID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Characteristic Characteristic { get; set; }
    }
}
