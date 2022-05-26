using MyNotes.Domain.Base.Enitities;

namespace MyNotes.Domain.Base
{
    /// <summary>Сущность записи</summary>
    /// <typeparam name="TKey">Тип первичного ключа</typeparam>
    public interface INote<TKey> : IEntity<TKey>
    {
        string Title { get; set; }
        string Body { get; set; }
        DateTime CreationTime { get; set; }
    }
}
