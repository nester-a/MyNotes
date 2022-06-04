using MyNotes.Domain.Entities;
using MyNotes.Interfaces.Base.Repositories;
using MyNotes.Interfaces.Base.Services;

namespace MyNotes.Interfaces.Services
{
    public abstract class Service<T, TKey> : IService<T, TKey> where T : Entity<TKey> where TKey : IEquatable<TKey>
    {
        private IRepositoryAsync<T, TKey> _repository;

        protected Service(IRepositoryAsync<T, TKey> repository)
        {
            _repository = repository;
        }


        public T Create(T newEntity)
        {
            var result = _repository.ExistAsync(newEntity).Result;
            if (result)
            {
                throw new ArgumentException($"Repository already contains entity {nameof(newEntity)}");
            }
            return _repository.AddAsync(newEntity).Result;
        }

        public T Delete(TKey id)
        {
            var result = _repository.ExistIdAsync(id).Result;
            if (result)
            {
                return _repository.DeleteByIdAsync(id).Result;
            }
            throw new ArgumentException($"Repository doesn't contain entity with this{id}");
        }

        public ICollection<T> GetAll()
        {
            return _repository.GetAllAsync().Result.ToList();
        }

        public T GetById(TKey id)
        {
            var result = _repository.ExistIdAsync(id).Result;
            if (result)
            {
                return _repository.GetByIdAsync(id).Result;
            }
            throw new ArgumentException($"Repository doesn't contain entity with this{id}");
        }

        public T Update(TKey id, T entityForUpdate)
        {
            var result = _repository.ExistIdAsync(id).Result;
            if (result)
            {
                return _repository.UpdateAsync(entityForUpdate).Result;
            }
            throw new ArgumentException($"Repository doesn't contain entity with this{id}");
        }
    }
    public abstract class Service<T> : Service<T, int> where T : Entity<int>
    {
        protected Service(IRepositoryAsync<T, int> repository) : base(repository) { }
    }
}
