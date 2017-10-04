using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.DAL.Entities;

namespace Store.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString)
        {
            // Database.SetInitializer<ApplicationContext>(new DropCreateDatabaseAlways<ApplicationContext>());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<AvailabilityType> AvailabilityTypes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryCharacteristic> CategoryCharacteristics { get; set; }
        public virtual DbSet<Characteristic> Characteristics { get; set; }
        public virtual DbSet<CharValue> CharValues { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentType> CommentTypes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Curency> Curencies { get; set; }
        public virtual DbSet<DeliveryType> DeliveryTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<GeneralNews> GeneralNews { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCharacteristic> ItemCharacteristics { get; set; }
        public virtual DbSet<ItemImage> ItemImages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Purpose> Purposes { get; set; }
        public virtual DbSet<PurposePrice> purposePrices { get; set; }
        public virtual DbSet<Status> status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                        .HasRequired(m => m.ManufCountry)
                        .WithMany(t => t.ManufCountryItems)
                        .HasForeignKey(m => m.ManufCountryID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                        .HasRequired(m => m.BrandCountry)
                        .WithMany(t => t.BrandCountryItems)
                        .HasForeignKey(m => m.BrandCountryID)
                        .WillCascadeOnDelete(false);
        }
    }


}
