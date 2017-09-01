namespace Store.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? ItemId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser {get;set;}

        [StringLength(50)]
        public string UserName { get; set; }

        public Guid? CommentTypeId { get; set; }

        [Column("Comment")]
        public string Comment1 { get; set; }

        public DateTime? Date { get; set; }

        public virtual CommentType CommentType { get; set; }

        public virtual Item Item { get; set; }
    }
}
