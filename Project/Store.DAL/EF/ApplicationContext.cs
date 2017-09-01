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

        //public DbSet<ClientProfile> ClientProfiles { get; set; }


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



            //    modelBuilder.Entity<AvailabilityType>()
            //        .Property(e => e.Name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Brand>()
            //        .Property(e => e.Name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Category>()
            //        .Property(e => e.Name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Category>()
            //        .HasMany(e => e.Category1)
            //        .WithOptional(e => e.Category2)
            //        .HasForeignKey(e => e.ParentID);

            //    modelBuilder.Entity<Characteristic>()
            //        .Property(e => e.Name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<CharValue>()
            //        .Property(e => e.strVal)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<CharValue>()
            //        .HasMany(e => e.ItemCharacteristics)
            //        .WithOptional(e => e.CharValue)
            //        .HasForeignKey(e => e.CharVarID);

            //    modelBuilder.Entity<Comment>()
            //        .Property(e => e.UserName)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Comment>()
            //        .Property(e => e.Comment1)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<CommentType>()
            //        .Property(e => e.Name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Contact>()
            //        .Property(e => e.Value)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<ContactType>()
            //        .Property(e => e.name)
            //        .IsUnicode(false);

            //modelBuilder.Entity<Country>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Country>()
            //    .HasMany(e => e.BrandCountryItems)
            //    .WithOptional(e => e.ManufCountry)
            //    .HasForeignKey(e => e.ManufCountryID);


            //modelBuilder.Entity<Country>()
            //    .HasMany(e => e.BrandCountryItems)
            //    .WithOptional(e => e.BrandCountry)
            //    .HasForeignKey(e => e.BrandCountryID);

            //modelBuilder.Entity<Curency>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //    modelBuilder.Entity<Curency>()
            //        .HasMany(e => e.purposePrices)
            //        .WithRequired(e => e.Curency)
            //        .WillCascadeOnDelete(false);

            //    modelBuilder.Entity<DeliveryType>()
            //        .Property(e => e.Name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Gender>()
            //        .Property(e => e.name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<GeneralNew>()
            //        .Property(e => e.name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<GeneralNew>()
            //        .Property(e => e.description)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Item>()
            //        .Property(e => e.Name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Item>()
            //        .Property(e => e.Description)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Item>()
            //        .HasMany(e => e.ItemImages)
            //        .WithRequired(e => e.Item)
            //        .WillCascadeOnDelete(false);

            //    modelBuilder.Entity<Item>()
            //        .HasMany(e => e.OrderItems)
            //        .WithRequired(e => e.Item)
            //        .WillCascadeOnDelete(false);

            //    modelBuilder.Entity<ItemImage>()
            //        .Property(e => e.ImageURL)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<ItemImage>()
            //        .Property(e => e.VideoURL)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Order>()
            //        .Property(e => e.Comment)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Order>()
            //        .Property(e => e.Name)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Order>()
            //        .Property(e => e.LastName)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Order>()
            //        .Property(e => e.Phone)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Order>()
            //        .Property(e => e.Address)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Order>()
            //        .Property(e => e.Number)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Order>()
            //        .Property(e => e.email)
            //        .IsUnicode(false);

            //    modelBuilder.Entity<Order>()
            //        .HasMany(e => e.OrderItems)
            //        .WithRequired(e => e.Order)
            //        .WillCascadeOnDelete(false);

            //    modelBuilder.Entity<Purpose>()
            //        .HasMany(e => e.OrderItems)
            //        .WithRequired(e => e.Purpose)
            //        .WillCascadeOnDelete(false);

            //    modelBuilder.Entity<Purpose>()
            //        .HasMany(e => e.purposePrices)
            //        .WithRequired(e => e.Purpose)
            //        .WillCascadeOnDelete(false);

            //    modelBuilder.Entity<purposePrice>()
            //        .HasMany(e => e.OrderItems)
            //        .WithRequired(e => e.purposePrice)
            //        .WillCascadeOnDelete(false);

            //    modelBuilder.Entity<status>()
            //        .Property(e => e.name)
            //        .IsUnicode(false);
        }
    }


}
