using MyNotes.Domain.Base;
using MyNotes.Interfaces.Base.Repositories;

namespace MyNotes.Interfaces.Base
{
    /// <summary>Репозиторий сущностей пользователя</summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип первичного ключа сущности</typeparam>
    public interface IUserRepository<T, in TKey> : INamedRepository<T, TKey> where T : IUser<TKey> { }

    /// <summary>Репозиторий сущностей пользователя</summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IUserRepository<T> : INamedRepository<T> where T : IUser { }
}
