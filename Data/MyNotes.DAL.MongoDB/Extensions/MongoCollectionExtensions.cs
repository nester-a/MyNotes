using MongoDB.Bson;
using MongoDB.Driver;
using MyNotes.Domain.Base.Enitities;

namespace MyNotes.DAL.MongoDB.Extensions
{
    public static class MongoCollectionExtensions
    {
        public static bool Contains<T>(this IMongoCollection<T> collection, T obj) where T : class, IEntity<string>
        {
            if (string.IsNullOrWhiteSpace(obj.Id)) return false;
            var findResult = collection.Find(new BsonDocument("_id", new ObjectId(obj.Id)));
            var result = findResult.Any();
            if (!result)
                return false;
            return true;
        }
    }
}
