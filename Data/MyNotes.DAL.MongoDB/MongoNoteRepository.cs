using MyNotes.DAL.MongoDB.Extensions;
using MyNotes.Domain;
using MyNotes.Domain.Base;
using MyNotes.Interfaces.Base.Repositories;

namespace MyNotes.DAL.MongoDB
{
    public class MongoNoteRepository<T> : MongoRepository<T>, INoteRepository<T, string> where T : Note<string>
    {
        public MongoNoteRepository(MongoDB db) : base(db, Names.Notes) { }

        public async Task<T> Add(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            //if (_col.Contains(item)) throw new InvalidOperationException($"Database already contains this element-{typeof(T)}-{nameof(item)}");
            await _col.InsertOneAsync(item);
            return item;
        }

        public Task AddRange(IEnumerable<T> items, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> DeleteByAuthor(IUser Author, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> DeleteByBody(string Body, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteById(string id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> DeleteByTitle(string Title, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRange(IEnumerable<T> items, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAuthor(IUser Author, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistBody(string Body, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistId(string Id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistTitle(string Title, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get(int Skip, int Count, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByAuthor(IUser Author, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByBody(string Body, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(string Id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByTitle(string Title, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount(CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRange(IEnumerable<T> items, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
