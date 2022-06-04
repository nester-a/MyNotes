﻿using MyNotes.DAL.MongoDB.Extensions;
using MyNotes.Domain;
using MyNotes.Domain.Base;
using MyNotes.Interfaces.Base.Repositories;

namespace MyNotes.DAL.MongoDB
{
    public class MongoNoteRepository<T> : MongoRepository<T>, INoteRepositoryAsync<T, string> where T : Note<string>
    {
        public MongoNoteRepository(MongoDB db) : base(db, Names.Notes) { }

        /// <summary>Асинхронно добавляет элемент в репозиторий</summary>
        /// <param name="item">Добавляемый элемент</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Добавляемый элемент</returns>
        /// <exception cref="AggregateException">В случае если элемент уже есть в репозитории, или добавляемый элемент - <b>null</b>></exception>
        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            await _col.InsertOneAsync(item);
            return item;
        }

        /// <summary>Добавляет элемент в репозиторий</summary>
        /// <param name="item">Добавляемый элемент</param>
        /// <returns>Добавляемый элемент</returns>
        /// <exception cref="MongoWriteException">В случае если элемент уже есть в репозитории</exception>
        /// <exception cref="ArgumentNullException">В случае если добавляемый элемент - <b>null</b>></exception>
        public T Add(T item)
        {
            try
            {
                _col.InsertOne(item);
            }
            catch
            {
                throw;
            }
            return item;
        }


        public Task AddRangeAsync(IEnumerable<T> items, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> DeleteByAuthorAsync(IUser Author, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> DeleteByBodyAsync(string Body, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteByIdAsync(string id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> DeleteByTitleAsync(string Title, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<T> items, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAuthorAsync(IUser Author, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistBodyAsync(string Body, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistIdAsync(string Id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistTitleAsync(string Title, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAsync(int Skip, int Count, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByAuthorAsync(IUser Author, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByBodyAsync(string Body, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(string Id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByTitleAsync(string Title, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<T> items, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
