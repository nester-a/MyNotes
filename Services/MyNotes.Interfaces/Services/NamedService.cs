using MyNotes.Domain.Entities;
using MyNotes.Interfaces.Base.Repositories;
using MyNotes.Interfaces.Base.Services;

namespace MyNotes.Interfaces.Services
{
    public abstract class NamedService<T, TKey> : Service<T, TKey>, INamedService<T, TKey> where T : NamedEntity<TKey> where TKey : IEquatable<TKey>
    {
        private readonly INamedRepository<T, TKey> _namedRepository;

        protected NamedService(INamedRepository<T, TKey> namedRepository) : base(namedRepository)
        {
            _namedRepository = namedRepository;
        }

        public ICollection<T> DeleteAllByName(string name)
        {
            var result = _namedRepository.ExistName(name).Result;
            if (result)
            {
                return _namedRepository.DeleteByName(name).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {name}");
        }

        public ICollection<T> GetAllByName(string name)
        {
            var result = _namedRepository.ExistName(name).Result;
            if (result)
            {
                return _namedRepository.GetByName(name).Result.ToList();
            }
            throw new ArgumentException($"Repository doesn't contain any entity with this {name}");
        }

        public ICollection<T> UpdateAllByName(string name, T entityForUpdate)
        {
            var result = _namedRepository.ExistName(name).Result;
            if (result)
            {
                var tmp = _namedRepository.GetByName(name).Result;
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
        protected NamedService(INamedRepository<T, int> repository) : base(repository) { }
    }
}
