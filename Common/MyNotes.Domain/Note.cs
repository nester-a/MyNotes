using MyNotes.Domain.Base;
using MyNotes.Domain.Entities;

namespace MyNotes.Domain
{
    /// <summary>Сущность записи</summary>
    /// <typeparam name="TKey">Тип первичного ключа</typeparam>
    public class Note<TKey> : Entity<TKey>, INote where TKey : IEquatable<TKey>
    {
        /// <summary>Заголовок</summary>
        public string Title { get; set; }

        /// <summary>Тело</summary>
        public string Body { get; set; }

        /// <summary>Автор</summary>
        /// <typeparam name="TKey">Тип первичного ключа</typeparam>
        public IUser Author { get; set; }

        /// <summary>Время создания</summary>
        public DateTime CreationTime { get; } = DateTime.Now;

    }
    /// <summary>Сущность записи</summary>
    public class Note : Note<int> { }
}
