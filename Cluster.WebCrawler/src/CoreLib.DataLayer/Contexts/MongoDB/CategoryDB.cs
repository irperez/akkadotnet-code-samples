
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.DataLayer.Contexts.MongoDB
{
    public class CategoryDB
    {
        public CategoryDB()
        {
            _client = new MongoClient(ConfigurationManager.AppSettings["mongoServer"]);
            _database = _client.GetServer().GetDatabase(ConfigurationManager.AppSettings["pageCollection"]);
        }

        protected static MongoClient _client;
        protected static MongoDatabase _database;


    }
}
