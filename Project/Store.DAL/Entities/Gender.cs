namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gender")]
    public partial class Gender
    {
        public Gender()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
