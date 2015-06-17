using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

namespace CoreLib.DataLayer.Contexts.MongoDB
{
    public class PageMongoContext : IPageContext
    {
        /// <summary>
        ///
        /// </summary>
        public PageMongoContext()
        {

        }

        private PageDB _context;

        protected PageDB Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new PageDB();
                }

                return _context;
            }
            private set
            {
                _context = value;
            }
        }

        public string Save(PageMetadata page)
        {
            var result = this.Context.PageMetadata.Save(page);

            return result.Upserted.AsString;
        }

        public PageMetadata GetPageMetadata(string url)
        {
            var obj = (from pg in this.Context.PageMetadata.AsQueryable()
                       where pg.Uri == url
                       select pg).FirstOrDefault();

            return obj;
        }

        public void Remove(PageMetadata page)
        {

            this.Context.PageMetadata.Remove(Query.EQ("Uri", page.Uri));
        }
    }
}
