using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using CoreLib.DataLayer.Contexts.EF;

namespace CoreLib.DataLayer.Contexts.EF.Migrations
{
    public sealed class PageConfiguration : DbMigrationsConfiguration<PageContext>
    {
        public PageConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CoreLib.DataLayer.PageContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
