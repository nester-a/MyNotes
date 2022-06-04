using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MyNotes.DAL.MongoDB;
using MyNotes.Domain;
using System;
using System.Threading.Tasks;
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
        public void MongoNoteRepository_AddAsync_Returns_Added_Item()
        {
            var taskRes = Task.Run(() => repo.AddAsync(note));
            Task.WaitAll(taskRes);
            var res = taskRes.Result;


            Assert.True(taskRes.IsCompleted);
            Assert.True(res is Note<string>);
            Assert.True(res.Id == note.Id);
            Assert.True(res.Title == note.Title);
            Assert.True(res.Body == note.Body);
            Assert.True(res.Author == note.Author);
        }

        [TestMethod]
        public void MongoNoteRepository_AddAsync_Returns_AggregateException()
        {
            bool catched = false;
            var taskRes = repo.AddAsync(note).Result;
           

            Assert.True(taskRes is Note<string>);
            Assert.True(taskRes.Id == note.Id);
            Assert.True(taskRes.Title == note.Title);
            Assert.True(taskRes.Body == note.Body);
            Assert.True(taskRes.Author == note.Author);

            try
            {
                taskRes = repo.AddAsync(note).Result;
            }
            catch (AggregateException ex)
            {
                catched = true;
                Assert.True(ex is AggregateException);
            }

            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_AddAsync_Returns_AggregateException_NullArgument()
        {
            bool catched = false;

            try
            {
                var taskRes = Task.Run(() => repo.AddAsync(null));
                Task.WaitAll(taskRes);
            }
            catch (AggregateException ex)
            {
                catched = true;
                Assert.True(ex is AggregateException);
            }

            Assert.True(catched);
        }
    }
}
