using MyNotes.Domain.Base;
using MyNotes.Domain.Entities;
using MyNotes.Interfaces.Base.Repositories;
using MyNotes.Interfaces.Base.Services;

namespace MyNotes.Interfaces.Services
{
    public class NoteService<T, TKey> : Service<T, TKey>, INoteService<T> where T : Entity<TKey>, INote where TKey : IEquatable<TKey>
    {
        private readonly INoteRepository<T, TKey> _noteRepository;

        public NoteService(INoteRepository<T, TKey> noteRepository) : base(noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public ICollection<T> DeleteAllByAuthor(IUser author)
        {
            var result = _noteRepository.ExistAuthor(author).Result;
            if (result)
            {
                return _noteRepository.DeleteByAuthor(author).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {author}");
        }

        public ICollection<T> DeleteAllByBody(string body)
        {
            var result = _noteRepository.ExistBody(body).Result;
            if (result)
            {
                return _noteRepository.DeleteByBody(body).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {body}");
        }

        public ICollection<T> DeleteAllByTitle(string title)
        {
            var result = _noteRepository.ExistTitle(title).Result;
            if (result)
            {
                return _noteRepository.DeleteByTitle(title).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {title}");
        }

        public ICollection<T> GetAllByAuthor(IUser author)
        {
            var result = _noteRepository.ExistAuthor(author).Result;
            if (result)
            {
                return _noteRepository.GetByAuthor(author).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {author}");
        }

        public ICollection<T> GetAllByBody(string body)
        {
            var result = _noteRepository.ExistBody(body).Result;
            if (result)
            {
                return _noteRepository.GetByBody(body).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {body}");
        }

        public ICollection<T> GetAllByTitle(string title)
        {
            var result = _noteRepository.ExistTitle(title).Result;
            if (result)
            {
                return _noteRepository.GetByTitle(title).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {title}");
        }

        public ICollection<T> UpdateAllByAuthor(IUser author, T entityForUpdate)
        {
            var result = _noteRepository.ExistAuthor(author).Result;
            if (result)
            {
                var tmp = _noteRepository.GetByAuthor(author).Result;
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
            var result = _noteRepository.ExistBody(body).Result;
            if (result)
            {
                var tmp = _noteRepository.GetByBody(body).Result;
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
            var result = _noteRepository.ExistTitle(title).Result;
            if (result)
            {
                var tmp = _noteRepository.GetByTitle(title).Result;
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
