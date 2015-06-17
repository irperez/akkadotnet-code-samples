using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.DataLayer.Contexts.EF;

namespace CoreLib.DataLayer.Contexts.EF.Migrations
{
    public sealed class CategoryConfiguration : DbMigrationsConfiguration<CategoryContext>
    {
        public CategoryConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CoreLib.DataLayer.CategoryContext";
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(CategoryContext context)
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
