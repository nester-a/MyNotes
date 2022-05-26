namespace MyNotes.Domain.Base.Enitities
{
    /// <summary>Именованная сущность</summary>
    /// <typeparam name="TKey">Тип первичного ключа</typeparam>
    public interface INamedEntity<TKey> : IEntity<TKey>
    {
        /// <summary>Имя</summary>
        string Name { get; set; }
    }

    /// <summary>Именованная сущность</summary>
    public interface INamedEntity : INamedEntity<int>, IEntity { }
}
