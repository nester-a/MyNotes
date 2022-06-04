using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using MyNotes.DAL.MongoDB;
using MyNotes.Domain;
using System;
using System.Collections.Generic;
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

        List<Note<string>> notes = new List<Note<string>>()
        {
            new Note<string>()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Hello-1",
                Body = "Hello world-1",
                Author = new User() { Name = "Me-1" },
            },
            new Note<string>()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Hello-2",
                Body = "Hello world-2",
                Author = new User() { Name = "Me-2" },
            },
        };

        [TestMethod]
        public void MongoNoteRepository_AddAsync_Returns_Added_Item()
        {
            var taskRes = repo.AddAsync(note).Result;


            Assert.True(taskRes is Note<string>);
            Assert.True(taskRes.Id == note.Id);
            Assert.True(taskRes.Title == note.Title);
            Assert.True(taskRes.Body == note.Body);
            Assert.True(taskRes.Author == note.Author);
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
                var taskRes = repo.AddAsync(null).Result;
            }
            catch (AggregateException ex)
            {
                catched = true;
                Assert.True(ex is AggregateException);
            }

            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_Add_Returns_Added_Item()
        {
            var taskRes = repo.Add(note);


            Assert.True(taskRes is Note<string>);
            Assert.True(taskRes.Id == note.Id);
            Assert.True(taskRes.Title == note.Title);
            Assert.True(taskRes.Body == note.Body);
            Assert.True(taskRes.Author == note.Author);
        }

        [TestMethod]
        public void MongoNoteRepository_Add_Returns_MongoWriteException()
        {
            bool catched = false;
            var taskRes = repo.Add(note);


            Assert.True(taskRes is Note<string>);
            Assert.True(taskRes.Id == note.Id);
            Assert.True(taskRes.Title == note.Title);
            Assert.True(taskRes.Body == note.Body);
            Assert.True(taskRes.Author == note.Author);

            try
            {
                taskRes = repo.Add(note);
            }
            catch (MongoWriteException ex)
            {
                catched = true;
                Assert.True(ex is MongoWriteException);
            }

            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_Add_Returns_ArgumentNullException()
        {
            bool catched = false;

            try
            {
                var taskRes = repo.Add(null);
            }
            catch (ArgumentNullException ex)
            {
                catched = true;
                Assert.True(ex is ArgumentNullException);
            }

            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_AddRange_Success()
        {
            repo.AddRange(notes);
        }

        [TestMethod]
        public void MongoNoteRepository_AddRange_Returns_MongoBulkWriteException()
        {
            bool catched = false;
            repo.AddRange(notes);

            try
            {
                repo.AddRange(notes);
            }
            catch(MongoBulkWriteException ex)
            {
                catched= true;
                Assert.True(ex is MongoBulkWriteException);
            }
            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_AddRange_Returns_ArgumentNullException()
        {
            bool catched = false;

            try
            {
                repo.AddRange(null);
            }
            catch (ArgumentNullException ex)
            {
                catched = true;
                Assert.True(ex is ArgumentNullException);
            }

            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_AddRangeAsync_Success()
        {
            repo.AddRangeAsync(notes).Wait();
        }
        [TestMethod]
        public void MongoNoteRepository_AddRangeAsync_Returns_AggregateException()
        {
            bool catched = false;
            repo.AddRangeAsync(notes).Wait();

            try
            {
                repo.AddRangeAsync(notes).Wait();
            }
            catch (AggregateException ex)
            {
                catched = true;
                Assert.True(ex is AggregateException);
            }
            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_AddRangeAsync_Returns_AggregateException_ArgumentNull()
        {
            bool catched = false;

            try
            {
                repo.AddRangeAsync(null).Wait();
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
