using MyNotes.Domain.Entities;
using MyNotes.Interfaces.Base.Repositories;
using MyNotes.Interfaces.Base.Services;

namespace MyNotes.Interfaces.Services
{
    public abstract class Service<T, TKey> : IService<T, TKey> where T : Entity<TKey> where TKey : IEquatable<TKey>
    {
        private IRepository<T, TKey> _repository;

        protected Service(IRepository<T, TKey> repository)
        {
            _repository = repository;
        }


        public T Create(T newEntity)
        {
            var result = _repository.Exist(newEntity).Result;
            if (result)
            {
                throw new ArgumentException($"Repository already contains entity {nameof(newEntity)}");
            }
            return _repository.Add(newEntity).Result;
        }

        public T Delete(TKey id)
        {
            var result = _repository.ExistId(id).Result;
            if (result)
            {
                return _repository.DeleteById(id).Result;
            }
            throw new ArgumentException($"Repository doesn't contain entity with this{id}");
        }

        public ICollection<T> GetAll()
        {
            return _repository.GetAll().Result.ToList();
        }

        public T GetById(TKey id)
        {
            var result = _repository.ExistId(id).Result;
            if (result)
            {
                return _repository.GetById(id).Result;
            }
            throw new ArgumentException($"Repository doesn't contain entity with this{id}");
        }

        public T Update(TKey id, T entityForUpdate)
        {
            var result = _repository.ExistId(id).Result;
            if (result)
            {
                return _repository.Update(entityForUpdate).Result;
            }
            throw new ArgumentException($"Repository doesn't contain entity with this{id}");
        }
    }
    public abstract class Service<T> : Service<T, int> where T : Entity<int>
    {
        protected Service(IRepository<T, int> repository) : base(repository) { }
    }
}
