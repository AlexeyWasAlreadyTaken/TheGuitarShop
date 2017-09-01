namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser{ get; set; }
        public Guid? ContactTypeId { get; set; }

        [StringLength(50)]
        public string Value { get; set; }

        public virtual ContactType ContactType { get; set; }
    }
}
