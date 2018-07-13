using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:Mongodb操作帮助类
    /// Author:WUWEI
    /// Date:2018/07/13
    /// </summary>
    public class MongodbHelper
    {
        #region 单例模式
        private static MongodbHelper _instance = null;
        private static object locker = new object();
        private MongodbHelper() { }
        public static MongodbHelper CreateInstance()
        {
            if (null == _instance)
            {
                lock (locker)
                {
                    if (null == _instance)
                        _instance = new MongodbHelper();
                }
            }
            return _instance;
        }
        #endregion

        #region CreateMongoClient
        /// <returns></returns>
        public MongoClient CreateMongoClient(string connString)
        {
            var client = new MongoClient(connString);
            return client;
        }
        #endregion

        #region 创建MongoDatabase
        public IMongoDatabase CreateMongoDatabase(string connString, string dbname)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase(dbname);
            return database;
        }

        public IMongoDatabase CreateMongoDatabase(MongoClient client, string dbname)
        {
            var database = client.GetDatabase(dbname);
            return database;
        }
        #endregion

        #region 创建MongoCollection
        public IMongoCollection<TDocument> CreateMongoCollection<TDocument>(string connString, string dbname, string name)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            return collection;
        }

        public IMongoCollection<TDocument> CreateMongoCollection<TDocument>(MongoClient client, string dbname, string name)
        {
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            return collection;
        }

        public IMongoCollection<TDocument> CreateMongoCollection<TDocument>(IMongoDatabase database, string name)
        {
            var collection = database.GetCollection<TDocument>(name);
            return collection;
        }
        #endregion

        #region InsertOneDocumentAsync
        public void InsertOneDocumentAsync<TDocument>(string connString, string dbname, string name, TDocument document)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertOneAsync(document);
        }

        public void InsertOneDocumentAsync<TDocument>(MongoClient client, string dbname, string name, TDocument document)
        {
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertOneAsync(document);
        }

        public void InsertOneDocumentAsync<TDocument>(IMongoDatabase database, string name, TDocument document)
        {
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertOneAsync(document);
        }
        #endregion

        #region InsertOneDocument
        public void InsertOneDocument<TDocument>(string connString, string dbname, string name, TDocument document)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertOne(document);
        }

        public void InsertOneDocument<TDocument>(MongoClient client, string dbname, string name, TDocument document)
        {
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertOne(document);
        }

        public void InsertOneDocument<TDocument>(IMongoDatabase database, string name, TDocument document)
        {
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertOne(document);
        }
        #endregion

        #region InsertManyDocument
        public void InsertManyDocument<TDocument>(string connString, string dbname, string name, List<TDocument> list)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertMany(list);
        }

        public void InsertManyDocument<TDocument>(MongoClient client, string dbname, string name, List<TDocument> list)
        {
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertMany(list);
        }

        public void InsertManyDocument<TDocument>(IMongoDatabase database, string name, List<TDocument> list)
        {
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertMany(list);
        }
        #endregion

        #region InsertManyDocumentAsync
        public void InsertManyDocumentAsync<TDocument>(string connString, string dbname, string name, List<TDocument> list)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertManyAsync(list);
        }

        public void InsertManyDocumentAsync<TDocument>(MongoClient client, string dbname, string name, List<TDocument> list)
        {
            var database = client.GetDatabase(dbname);
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertManyAsync(list);
        }

        public void InsertManyDocumentAsync<TDocument>(IMongoDatabase database, string name, List<TDocument> list)
        {
            var collection = database.GetCollection<TDocument>(name);
            collection.InsertManyAsync(list);
        }
        #endregion
    }
}
