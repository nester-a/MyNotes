using MyNotes.Domain.Base.Enitities;

namespace MyNotes.Domain.Base
{
    /// <summary>Пользователь</summary>
    /// <typeparam name="TKey">Тип первичного ключа</typeparam>
    public interface IUser<TKey> : INamedEntity<TKey>
    {

    }
    public interface IUser : IUser<int>, INamedEntity
    {

    }
}
