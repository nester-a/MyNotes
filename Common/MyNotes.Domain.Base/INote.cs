using MyNotes.Domain.Base.Enitities;

namespace MyNotes.Domain.Base
{
    /// <summary>Сущность записи</summary>
    /// <typeparam name="TKey">Тип первичного ключа</typeparam>
    public interface INote<TKey> : IEntity<TKey>
    {
        /// <summary>Заголовок</summary>
        string Title { get; set; }

        /// <summary>Тело</summary>
        string Body { get; set; }

        /// <summary>Автор</summary>
        IUser<TKey> Author { get; set; }

        /// <summary>Время создания</summary>
        DateTime CreationTime { get; }
    }
    public interface INote : INote<int>, IEntity { }
}
