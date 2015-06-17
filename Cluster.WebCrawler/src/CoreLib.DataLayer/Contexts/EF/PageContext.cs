using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CoreLib.DataLayer.Contexts.EF
{
    public partial class PageContext : DbContext
    {
        public PageContext()
            : base("name=PageContext")
        {
        }

        public virtual DbSet<PageContent> PageContents { get; set; }
        public virtual DbSet<PageLink> PageLinks { get; set; }
        public virtual DbSet<PageMetadata> PageMetadatas { get; set; }
        public virtual DbSet<IndexedContent> IndexedContents { get; set; }
        public virtual DbSet<Website> Websites { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageMetadata>()
                .Property(e => e.Charset)
                .IsUnicode(false);

            modelBuilder.Entity<PageMetadata>()
                .Property(e => e.Encoding)
                .IsUnicode(false);
            modelBuilder.Entity<PageMetadata>()
                .Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Website>()
                .Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
