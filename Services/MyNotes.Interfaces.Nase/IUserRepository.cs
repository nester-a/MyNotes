using MyNotes.Domain.Base;
using MyNotes.Interfaces.Base.Repositories;

namespace MyNotes.Interfaces.Base
{
    public interface IUserRepository<T, in TKey> : INamedRepository<T, TKey> where T : IUser<TKey>{ }
    public interface IUserRepository<T> : INamedRepository<T> where T : IUser { }
}
