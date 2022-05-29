using MongoDB.Driver;

namespace MyNotes.DAL.MongoDB
{
    public abstract class MongoRepository<T>
    {
        protected IMongoCollection<T> _col;
        public MongoRepository(MongoDB db, string collectionName)
        {
            _col = db.GetCollection<T>(collectionName);
        }
    }
}
