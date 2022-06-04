using MyNotes.Domain.Base;
using MyNotes.Domain.Entities;
using MyNotes.Interfaces.Base.Repositories;
using MyNotes.Interfaces.Base.Services;

namespace MyNotes.Interfaces.Services
{
    public class NoteService<T, TKey> : Service<T, TKey>, INoteService<T> where T : Entity<TKey>, INote where TKey : IEquatable<TKey>
    {
        private readonly INoteRepositoryAsync<T, TKey> _noteRepository;

        public NoteService(INoteRepositoryAsync<T, TKey> noteRepository) : base(noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public ICollection<T> DeleteAllByAuthor(IUser author)
        {
            var result = _noteRepository.ExistAuthorAsync(author).Result;
            if (result)
            {
                return _noteRepository.DeleteByAuthorAsync(author).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {author}");
        }

        public ICollection<T> DeleteAllByBody(string body)
        {
            var result = _noteRepository.ExistBodyAsync(body).Result;
            if (result)
            {
                return _noteRepository.DeleteByBodyAsync(body).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {body}");
        }

        public ICollection<T> DeleteAllByTitle(string title)
        {
            var result = _noteRepository.ExistTitleAsync(title).Result;
            if (result)
            {
                return _noteRepository.DeleteByTitleAsync(title).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {title}");
        }

        public ICollection<T> GetAllByAuthor(IUser author)
        {
            var result = _noteRepository.ExistAuthorAsync(author).Result;
            if (result)
            {
                return _noteRepository.GetByAuthorAsync(author).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {author}");
        }

        public ICollection<T> GetAllByBody(string body)
        {
            var result = _noteRepository.ExistBodyAsync(body).Result;
            if (result)
            {
                return _noteRepository.GetByBodyAsync(body).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {body}");
        }

        public ICollection<T> GetAllByTitle(string title)
        {
            var result = _noteRepository.ExistTitleAsync(title).Result;
            if (result)
            {
                return _noteRepository.GetByTitleAsync(title).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {title}");
        }

        public ICollection<T> UpdateAllByAuthor(IUser author, T entityForUpdate)
        {
            var result = _noteRepository.ExistAuthorAsync(author).Result;
            if (result)
            {
                var tmp = _noteRepository.GetByAuthorAsync(author).Result;
                foreach (var item in tmp)
                {
                    item.Title = entityForUpdate.Title;
                    item.Body = entityForUpdate.Body;
                    item.Author = entityForUpdate.Author;
                }
                return tmp.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {author}");
        }

        public ICollection<T> UpdateAllByBody(string body, T entityForUpdate)
        {
            var result = _noteRepository.ExistBodyAsync(body).Result;
            if (result)
            {
                var tmp = _noteRepository.GetByBodyAsync(body).Result;
                foreach (var item in tmp)
                {
                    item.Title = entityForUpdate.Title;
                    item.Body = entityForUpdate.Body;
                    item.Author = entityForUpdate.Author;
                }
                return tmp.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {body}");
        }

        public ICollection<T> UpdateAllByTitle(string title, T entityForUpdate)
        {
            var result = _noteRepository.ExistTitleAsync(title).Result;
            if (result)
            {
                var tmp = _noteRepository.GetByTitleAsync(title).Result;
                foreach (var item in tmp)
                {
                    item.Title = entityForUpdate.Title;
                    item.Body = entityForUpdate.Body;
                    item.Author = entityForUpdate.Author;
                }
                return tmp.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {title}");
        }
    }
}
