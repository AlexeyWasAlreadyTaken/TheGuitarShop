using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Store.DAL.Entities
{

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            Comments = new HashSet<Comment>();
            Contacts = new HashSet<Contact>();
            Orders = new HashSet<Order>();
        }

        public Guid? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        public virtual ICollection<Comment> Comments {get; set;}
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


    }

}
