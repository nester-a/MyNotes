using MongoDB.Driver;

namespace MyNotes.DAL.MongoDB
{
    public class MongoDB : MyNotesDB
    {
        IMongoDatabase _db;
        IMongoClient _client;
        public MongoDB (string connectionString) : base(connectionString)
        {
            _client = new MongoClient (connectionString);
            _db = _client.GetDatabase(Names.MyNotes);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
