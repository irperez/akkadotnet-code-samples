using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreLib.DataLayer.Contexts.MongoDB
{
    public class PageDB
    {
        public PageDB()
        {
            _client = new MongoClient();
            _database = _client.GetServer().GetDatabase(ConfigurationManager.AppSettings["pageData"]);
        }

        protected static MongoClient _client;
        protected static MongoDatabase _database;

        public MongoCollection<PageMetadata> PageMetadata {
            get
            {
                return _database.GetCollection<PageMetadata>("PageMetadata");
            }
        }

        public MongoCollection<IndexedContent> IndexedContent {
            get
            {
                return _database.GetCollection<IndexedContent>("IndexedContent");
            }
        }

        public IndexedContent GetIfExists(string Uri)
        {
            var content = (from ic in this.IndexedContent.AsQueryable()
                             where ic.Uri == Uri
                             select ic).FirstOrDefault();

            if (content != null)
            {
                return content;
            }
            else
            {
                return null;
            }
        }
    }
}
