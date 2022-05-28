using MyNotes.Domain.Entities;
using MyNotes.Interfaces.Base.Repositories;
using MyNotes.Interfaces.Base.Services;

namespace MyNotes.Interfaces.Services
{
    public abstract class Service<T, TKey> : IService<T, TKey> where T : Entity<TKey> where TKey : IEquatable<TKey>
    {
        protected IRepository<T, TKey> _Repository { get; private set; }

        protected Service(IRepository<T, TKey> repository)
        {
            _Repository = repository;
        }


        public T Create(T newEntity)
        {
            var result = _Repository.Exist(newEntity).Result;
            if (result)
            {
                throw new ArgumentException($"Repository already contains entity {nameof(newEntity)}");
            }
            return _Repository.Add(newEntity).Result;
        }

        public T Delete(TKey id)
        {
            var result = _Repository.ExistId(id).Result;
            if (result)
            {
                return _Repository.DeleteById(id).Result;
            }
            throw new ArgumentException($"Repository doesn't contain entity with this{id}");
        }

        public ICollection<T> GetAll()
        {
            return _Repository.GetAll().Result.ToList();
        }

        public T GetById(TKey id)
        {
            var result = _Repository.ExistId(id).Result;
            if (result)
            {
                return _Repository.GetById(id).Result;
            }
            throw new ArgumentException($"Repository doesn't contain entity with this{id}");
        }

        public T Update(TKey id, T entityForUpdate)
        {
            var result = _Repository.ExistId(id).Result;
            if (result)
            {
                return _Repository.Update(entityForUpdate).Result;
            }
            throw new ArgumentException($"Repository doesn't contain entity with this{id}");
        }
    }
}
