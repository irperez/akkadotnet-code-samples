using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLib.DataLayer.Contexts.EF
{
    public class CategoryContext : DbContext
    {
        public CategoryContext()
            : base("name=CategoryContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<Relationship> Relationships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Category>()
                .HasMany(m => m.Relationships)
                .WithMany();
                //.Map(m =>
                //{
                //    m.ToTable("Relationships");
                //    m.MapLeftKey("Id");
                //    m.MapRightKey("SourceId");
                //});


            //modelBuilder.Entity<Relationship>()
            //    .HasRequired(m => m.Target)
            //    .WithRequiredPrincipal()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Relationship>()
            //    .HasRequired(m => m.Source)
            //    .WithRequiredPrincipal()
            //    .WillCascadeOnDelete(false);

        }
    }
}
