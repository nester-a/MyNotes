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
        static DAL.MongoDB.MongoDB dB = new DAL.MongoDB.MongoDB("Tests", "mongodb://localhost:27017");
        MongoNoteRepository<Note<string>> repo = new MongoNoteRepository<Note<string>>(dB);

        [TestMethod]
        public void MongoNoteRepository_Add_Return_Added_Item()
        {
            var taskRes = repo.Add(note);
            var res = taskRes.Result;


            Assert.True(taskRes.IsCompleted);
            Assert.True(res is Note<string>);
            Assert.True(res.Id == note.Id);
            Assert.True(res.Title == note.Title);
            Assert.True(res.Body == note.Body);
            Assert.True(res.Author == note.Author);
        }
    }
}
