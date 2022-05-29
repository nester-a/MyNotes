using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MyNotes.DAL.MongoDB;
using MyNotes.Domain;
using Assert = Xunit.Assert;

namespace MyNotes.Tests.Data.MyNotesDALMongoDB
{
    [TestClass]
    public class MongoNoteRepositoryTests
    {
        Note<string> note = new Note<string>()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Title = "Hello",
            Body = "Hello world",
            Author = new User() { Name = "Me" },
        };
        static DAL.MongoDB.MongoDB dB = new DAL.MongoDB.MongoDB("mongodb://localhost:27017");
        MongoNoteRepository<Note<string>> repo = new MongoNoteRepository<Note<string>>(dB);

        [TestMethod]
        public void MongoNoteRepository_Should_Return_Smth()
        {
            var res = repo.Add(note);
        }
    }
}
