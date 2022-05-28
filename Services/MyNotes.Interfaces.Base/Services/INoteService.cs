using MyNotes.Domain.Base;

namespace MyNotes.Interfaces.Base.Services
{
    /// <summary>Сервис заметок</summary>
    /// <typeparam name="T">Тип сущности заметки, с которой работает сервис</typeparam>
    public interface INoteService<T> where T : INote
    {
        /// <summary>Получение всех сущностей заметок с указанным заголовком</summary>
        /// <param name="title">Заголовок получаемых сущностей</param>
        /// <returns>Коллекция сущностей заметок</returns>
        ICollection<T> GetAllByTitle(string title);

        /// <summary>Изменяет все сущности заметок с данным заголовком</summary>
        /// <param name="title">Заголовок изменяемых сущностей</param>
        /// <param name="entityForUpdate">Изменённая сущность</param>
        /// <returns>Коллекция изменённых сущностей заметок</returns>
        ICollection<T> UpdateAllByTitle(string title, T entityForUpdate);

        /// <summary>Удаление всех сущностей заметок с данным заголовком</summary>
        /// <param name="title">Заголовок удаляемых сущностей</param>
        /// <returns>Коллекция удалённых сущностей заметок</returns>
        ICollection<T> DeleteAllByTitle(string title);

        /// <summary>Получение всех сущностей заметок с указанным телом</summary>
        /// <param name="body">Тело получаемых сущностей</param>
        /// <returns>Коллекция сущностей заметок</returns>
        ICollection<T> GetAllByBody(string body);

        /// <summary>Изменяет все сущности заметок с данным телом</summary>
        /// <param name="body">Тело изменяемых сущностей</param>
        /// <param name="entityForUpdate">Изменённая сущность</param>
        /// <returns>Коллекция изменённых сущностей заметок</returns>
        ICollection<T> UpdateAllByBody(string body, T entityForUpdate);

        /// <summary>Удаление всех сущностей заметок с данным телом</summary>
        /// <param name="body">Тело удаляемых сущностей</param>
        /// <returns>Коллекция удалённых сущностей заметок</returns>
        ICollection<T> DeleteAllByBody(string body);

        /// <summary>Получение всех сущностей заметок с указанным автором</summary>
        /// <param name="author">Автор получаемых сущностей</param>
        /// <returns>Коллекция сущностей заметок</returns>
        ICollection<T> GetAllByAuthor(IUser author);

        /// <summary>Изменяет все сущности заметок с данным автором</summary>
        /// <param name="author">Автор изменяемых сущностей</param>
        /// <param name="entityForUpdate">Изменённая сущность</param>
        /// <returns>Коллекция изменённых сущностей заметок</returns>
        ICollection<T> UpdateAllByAuthor(IUser author, T entityForUpdate);

        /// <summary>Удаление всех сущностей заметок с данным автором</summary>
        /// <param name="author">Автор удаляемых сущностей</param>
        /// <returns>Коллекция удалённых сущностей заметок</returns>
        ICollection<T> DeleteAllByAuthor(IUser author);
    }
}
