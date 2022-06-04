using MyNotes.Domain.Entities;
using MyNotes.Interfaces.Base.Repositories;
using MyNotes.Interfaces.Base.Services;

namespace MyNotes.Interfaces.Services
{
    public abstract class NamedService<T, TKey> : Service<T, TKey>, INamedService<T, TKey> where T : NamedEntity<TKey> where TKey : IEquatable<TKey>
    {
        private readonly INamedRepositoryAsync<T, TKey> _namedRepository;

        protected NamedService(INamedRepositoryAsync<T, TKey> namedRepository) : base(namedRepository)
        {
            _namedRepository = namedRepository;
        }

        public ICollection<T> DeleteAllByName(string name)
        {
            var result = _namedRepository.ExistNameAsync(name).Result;
            if (result)
            {
                return _namedRepository.DeleteByNameAsync(name).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {name}");
        }

        public ICollection<T> GetAllByName(string name)
        {
            var result = _namedRepository.ExistNameAsync(name).Result;
            if (result)
            {
                return _namedRepository.GetByNameAsync(name).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {name}");
        }

        public ICollection<T> UpdateAllByName(string name, T entityForUpdate)
        {
            var result = _namedRepository.ExistNameAsync(name).Result;
            if (result)
            {
                var tmp = _namedRepository.GetByNameAsync(name).Result;
                foreach (var item in tmp)
                {
                    item.Name = entityForUpdate.Name;
                }
                return tmp.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {name}");
        }
    }
    public abstract class NamedService<T> : NamedService<T, int> where T : NamedEntity<int>
    {
        protected NamedService(INamedRepositoryAsync<T, int> repository) : base(repository) { }
    }
}
