using MyNotes.Domain.Base.Enitities;

namespace MyNotes.Domain.Base
{
    /// <summary>Сущность записи</summary>
    public interface INote
    {
        /// <summary>Заголовок</summary>
        string Title { get; set; }

        /// <summary>Тело</summary>
        string Body { get; set; }

        /// <summary>Автор</summary>
        IUser Author { get; set; }

        /// <summary>Время создания</summary>
        DateTime CreationTime { get; }
    }
}
