using MyNotes.Domain.Base;
using MyNotes.Domain.Entities;

namespace MyNotes.Domain
{
    /// <summary>Пользователь</summary>
    /// <typeparam name="TKey">Тип первичного ключа</typeparam>
    public class User<TKey> : NamedEntity<TKey>, IUser where TKey : IEquatable<TKey> { }

    /// <summary>Пользователь</summary>
    public class User : User<int> { }
}
