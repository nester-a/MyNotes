using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using MyNotes.DAL.MongoDB;
using MyNotes.Domain;
using MyNotes.Domain.Base;
using System;
using System.Collections.Generic;
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

            var filter1 = new BsonDocument("_id", $"{note.Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter1).ToList();
            Assert.True(result.Count == 1);
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

            var filter1 = new BsonDocument("_id", $"{note.Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter1).ToList();
            Assert.True(result.Count == 1);

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

            var filter1 = new BsonDocument("_id", $"{note.Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter1).ToList();
            Assert.True(result.Count == 1);
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

            var filter1 = new BsonDocument("_id", $"{note.Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter1).ToList();
            Assert.True(result.Count == 1);

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

            var filter1 = new BsonDocument("_id", $"{notes[0].Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter1).ToList();
            Assert.True(result.Count == 1);

            var filter2 = new BsonDocument("_id", $"{notes[1].Id}");
            result = dB.GetCollection<Note<string>>("Notes").Find(filter2).ToList();
            Assert.True(result.Count == 1);

        }

        [TestMethod]
        public void MongoNoteRepository_AddRange_Returns_MongoBulkWriteException()
        {
            bool catched = false;
            repo.AddRange(notes);

            var filter1 = new BsonDocument("_id", $"{notes[0].Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter1).ToList();
            Assert.True(result.Count == 1);

            var filter2 = new BsonDocument("_id", $"{notes[1].Id}");
            result = dB.GetCollection<Note<string>>("Notes").Find(filter2).ToList();
            Assert.True(result.Count == 1);

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

            var filter1 = new BsonDocument("_id", $"{notes[0].Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter1).ToList();
            Assert.True(result.Count == 1);

            var filter2 = new BsonDocument("_id", $"{notes[1].Id}");
            result = dB.GetCollection<Note<string>>("Notes").Find(filter2).ToList();
            Assert.True(result.Count == 1);
        }
        [TestMethod]
        public void MongoNoteRepository_AddRangeAsync_Returns_AggregateException()
        {
            bool catched = false;
            repo.AddRangeAsync(notes).Wait();

            var filter1 = new BsonDocument("_id", $"{notes[0].Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter1).ToList();
            Assert.True(result.Count == 1);

            var filter2 = new BsonDocument("_id", $"{notes[1].Id}");
            result = dB.GetCollection<Note<string>>("Notes").Find(filter2).ToList();
            Assert.True(result.Count == 1);

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

        [TestMethod]
        public void MongoNoteRepository_DeleteAsync_Returns_DeletedItem()
        {
            var taskRes = repo.AddAsync(note).Result;

            Assert.True(taskRes is Note<string>);
            Assert.True(taskRes.Id == note.Id);
            Assert.True(taskRes.Title == note.Title);
            Assert.True(taskRes.Body == note.Body);
            Assert.True(taskRes.Author == note.Author);

            var deleteRes = repo.DeleteAsync(note).Result;

            Assert.True(deleteRes is Note<string>);
            Assert.True(taskRes.Id == deleteRes.Id);
            Assert.True(taskRes.Title == deleteRes.Title);
            Assert.True(taskRes.Body == deleteRes.Body);
            Assert.True(taskRes.Author == deleteRes.Author);

            var filter = new BsonDocument("_id", $"{taskRes.Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter).ToList();

            Assert.True(result.Count == 0);
        }

        [TestMethod]
        public void MongoNoteRepository_DeleteAsync_Returns_AggregateException()
        {
            bool catched = false;

            var filter = new BsonDocument("_id", $"{note.Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter).ToList();
            Assert.True(result.Count == 0);
            try
            {
                var res = repo.DeleteAsync(note).Result;
            }
            catch (AggregateException ex)
            {
                catched = true;
                Assert.True(ex is AggregateException);
            }

            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_DeleteAsync_Returns_AggregateException_ArgumentNull()
        {
            bool catched = false;

            try
            {
                var res = repo.DeleteAsync(null).Result;
            }
            catch (AggregateException ex)
            {
                catched = true;
                Assert.True(ex is AggregateException);
            }

            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_Delete_Returns_DeletedItem()
        {
            var taskRes = repo.AddAsync(note).Result;

            Assert.True(taskRes is Note<string>);
            Assert.True(taskRes.Id == note.Id);
            Assert.True(taskRes.Title == note.Title);
            Assert.True(taskRes.Body == note.Body);
            Assert.True(taskRes.Author == note.Author);

            var deleteRes = repo.Delete(note);

            Assert.True(deleteRes is Note<string>);
            Assert.True(taskRes.Id == deleteRes.Id);
            Assert.True(taskRes.Title == deleteRes.Title);
            Assert.True(taskRes.Body == deleteRes.Body);
            Assert.True(taskRes.Author == deleteRes.Author);

            var filter = new BsonDocument("_id", $"{taskRes.Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter).ToList();

            Assert.True(result.Count == 0);
        }

        [TestMethod]
        public void MongoNoteRepository_Delete_Returns_ArgumentException()
        {
            bool catched = false;

            var filter = new BsonDocument("_id", $"{note.Id}");
            var result = dB.GetCollection<Note<string>>("Notes").Find(filter).ToList();
            Assert.True(result.Count == 0);
            try
            {
                var res = repo.Delete(note);
            }
            catch (ArgumentException ex)
            {
                catched = true;
                Assert.True(ex is ArgumentException);
            }
            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_Delete_Returns_AggregateException_ArgumentNull()
        {
            bool catched = false;

            try
            {
                var res = repo.Delete(null);
            }
            catch (ArgumentNullException ex)
            {
                catched = true;
                Assert.True(ex is ArgumentNullException);
            }

            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_DeleteByAuthorAsync_Returns_DeletedItems()
        {
            var taskRes = repo.AddAsync(note).Result;

            Assert.True(taskRes is Note<string>);
            Assert.True(taskRes.Id == note.Id);
            Assert.True(taskRes.Title == note.Title);
            Assert.True(taskRes.Body == note.Body);
            Assert.True(taskRes.Author == note.Author);

            var deleteRes = repo.DeleteByAuthorAsync(note.Author).Result;

            Assert.True(deleteRes is IEnumerable<Note<string>>);

            var author = note.Author as User;
            foreach (var item in deleteRes)
            {
                var tmp = item.Author as User; 
                Assert.True(item.Author is IUser);
                Assert.True(tmp.Id == author.Id);
                Assert.True(tmp.Name == author.Name);
            }
            
            var filter = new BsonDocument();
            var authorFilter = new BsonDocument();
            authorFilter.AddRange(new BsonDocument("_t", author.GetType().Name));
            authorFilter.AddRange(new BsonDocument("_id", author.Id));
            authorFilter.AddRange(new BsonDocument("Name", author.Name));
            filter.Add("Author", authorFilter);

            var result = dB.GetCollection<Note<string>>("Notes").Find(filter).ToList();

            Assert.True(result.Count == 0);
        }

        [TestMethod]
        public void MongoNoteRepository_DeleteByAuthorAsync_Returns_AggregateException_ItemsNotFound()
        {
            bool catched = false;

            var author = note.Author as User;
            var filter = new BsonDocument();
            var authorFilter = new BsonDocument();
            authorFilter.AddRange(new BsonDocument("_t", author.GetType().Name));
            authorFilter.AddRange(new BsonDocument("_id", author.Id));
            authorFilter.AddRange(new BsonDocument("Name", author.Name));
            filter.Add("Author", authorFilter);

            var result = dB.GetCollection<Note<string>>("Notes").Find(filter).ToList();

            Assert.True(result.Count == 0);
            try
            {
                var deleteRes = repo.DeleteByAuthorAsync(note.Author).Result;
            }
            catch (AggregateException ex)
            {
                catched = true;
                Assert.True(ex is AggregateException);
            }
            Assert.True(catched);
        }

        [TestMethod]
        public void MongoNoteRepository_DeleteByAuthorAsync_Returns_AggregateException_ArgumentNull()
        {
            bool catched = false;

            try
            {
                var res = repo.DeleteByAuthorAsync(null).Result;
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
