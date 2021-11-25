using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductAPI.Configuration;
using ProductAPI.Models;

namespace ProductAPI.Service
{
    public class ProductService : IProductService
    {
        private const string PRODUCT_COLLECTION = "Products";
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;
        private readonly MongoDBOptions _mongoDbOptions;
        public ProductService(IMongoClient mongoClient, IOptions<MongoDBOptions> mongoDbOptions)
        {
            _mongoClient = mongoClient;
            _mongoDbOptions = mongoDbOptions.Value;
            _mongoDatabase = _mongoClient.GetDatabase(_mongoDbOptions.Database);
        }
        public async Task<IEnumerable<Product>> GetProducts(int page = 1, int limit = 20)
        {
            Console.WriteLine("Get All Documents");
            var collection = _mongoDatabase.GetCollection<Product>(PRODUCT_COLLECTION);
            var documents = await collection.Find(new BsonDocument())
                                    .Skip(Convert.ToInt32((page - 1) * limit)).Limit(Convert.ToInt32(limit))
                                    .ToListAsync();
            return documents;
        }

        public async Task<Product> GetSingle(string sku)
        {
            Console.WriteLine("Get one Documents");
            var collection = _mongoDatabase.GetCollection<Product>(PRODUCT_COLLECTION);
            var filter = Builders<Product>.Filter.Eq(x => x.SKU, sku);
            var cursor = await collection.FindAsync(filter);
            return cursor.SingleOrDefault();
        }
    }
}