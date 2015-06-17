using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.DataLayer.Contexts.EF
{
    public class SearchProvider
    {
        public List<SearchResult> SearchContentsByCategory(string categories, int pageNumber = 0, int pageSize = 20, int language = 1033)
        {
            List<SearchResult> results = null;
            using (var context = new PageContext())
            {
            //    using (context.Database.Connection)
            //    {
            //        context.Database.Connection.Open();
            //        DbCommand cmd = context.Database.Connection.CreateCommand();
            //        cmd.CommandText = "SearchCategories";
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        cmd.Parameters.Add(new SqlParameter("Categories", categories));
            //        cmd.Parameters.Add(new SqlParameter("PageNumber", pageNumber));
            //        cmd.Parameters.Add(new SqlParameter("PageSize", pageSize));
            //        cmd.Parameters.Add(new SqlParameter("Language", language));

            //    }

                results = context.Database.SqlQuery<SearchResult>("SearchCategories @p0, @p1, @p2, @p3", categories, pageNumber, pageSize, language).ToList();
            }


            return results;
        }
    }
}
