using MyNotes.Domain.Base;

namespace MyNotes.Interfaces.Base.Repositories
{
    public interface INoteRepository<T, in TKey> : IRepository<T, TKey> where T : INote<TKey>
    {
        /// <summary>Проверка - существует ли в репозитории запись с указанным заголовком</summary>
        /// <param name="Title">Заголовок записи</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Истина, если запись с указанными заголовком существует в репозитории</returns>
        Task<bool> ExistTitle(string Title, CancellationToken Cancel = default);

        /// <summary>Получить запись по указанному заголовку</summary>
        /// <param name="Title">Заголовок записи, которую требуется получить из репозитория</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Запись с указанным заголовком в случае её наличия, и null, если записи с заданным заголовком в репозитории нет</returns>
        Task<T> GetByTitle(string Title, CancellationToken Cancel = default);

        /// <summary>Удаление записи с указанным заголовком из репозитория</summary>
        /// <param name="Title">Заголовок удаляемой записи</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Удалённая из репозитория запись в случае её наличия и null, если такой записи в репозитории не было</returns>
        Task<T> DeleteByTitle(string Title, CancellationToken Cancel = default);

        /// <summary>Проверка - существует ли в репозитории запись с указанным телом</summary>
        /// <param name="Body">Тело записи</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Истина, если запись с указанными телом существует в репозитории</returns>
        Task<bool> ExistBody(string Body, CancellationToken Cancel = default);

        /// <summary>Получить запись по указанному телу</summary>
        /// <param name="Body">Тело записи, которую требуется получить из репозитория</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Запись с указанным телом в случае её наличия, и null, если записи с заданным телом в репозитории нет</returns>
        Task<T> GetByBody(string Body, CancellationToken Cancel = default);

        /// <summary>Удаление записи с указанным телом из репозитория</summary>
        /// <param name="Body">Тело удаляемой записи</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Удалённая из репозитория запись в случае её наличия и null, если такой записи в репозитории не было</returns>
        Task<T> DeleteByBody(string Body, CancellationToken Cancel = default);

        /// <summary>Проверка - существует ли в репозитории запись с указанным автором</summary>
        /// <param name="Author">Автор записи</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Истина, если запись с указанными автором существует в репозитории</returns>
        Task<bool> ExistAuthor(IUser Author, CancellationToken Cancel = default);

        /// <summary>Получить запись по указанному автору</summary>
        /// <param name="Author">Автор записи, которую требуется получить из репозитория</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Запись с указанным автором в случае её наличия, и null, если записи с заданным телом в репозитории нет</returns>
        Task<T> GetByAuthor(IUser Author, CancellationToken Cancel = default);

        /// <summary>Удаление записи с указанным автором из репозитория</summary>
        /// <param name="Author">Автор удаляемой записи</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Удалённая из репозитория запись в случае её наличия и null, если такой записи в репозитории не было</returns>
        Task<T> DeleteByAuthor(IUser Author, CancellationToken Cancel = default);

    }
    public interface INoteRepository<T> : INoteRepository<T, int>, IRepository<T> where T : INote { }
}
