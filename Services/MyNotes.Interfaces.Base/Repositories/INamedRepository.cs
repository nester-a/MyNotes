using MyNotes.Domain.Base.Enitities;

namespace MyNotes.Interfaces.Base.Repositories
{
    /// <summary>Репозиторий именованных сущностей</summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип первичного ключа сущности</typeparam>
    public interface INamedRepositoryAsync<T, in TKey> : IRepositoryAsync<T, TKey> where T : INamedEntity<TKey>
    {
        /// <summary>Проверка - существует ли в репозитории сущность с указанным именем</summary>
        /// <param name="Name">Имя сущности</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Истина, если сущность с указанными именем существует в репозитории</returns>
        Task<bool> ExistNameAsync(string Name, CancellationToken Cancel = default);

        /// <summary>Получить сущность по указанному имени</summary>
        /// <param name="Name">Имя сущности, которую требуется получить из репозитория</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Сущность с указанным именем в случае её наличия, и null, если сущности с заданным именем в репозитории нет</returns>
        Task<IEnumerable<T>> GetByNameAsync(string Name, CancellationToken Cancel = default);

        /// <summary>Удаление сущности с указанным именем из репозитория</summary>
        /// <param name="Name">Имя удаляемой сущности</param>
        /// <param name="Cancel">Признак отмены асинхронной операции</param>
        /// <returns>Удалённая из репозитория сущность в случае её наличия и null, если такой сущности в репозитории не было</returns>
        Task<IEnumerable<T>> DeleteByNameAsync(string Name, CancellationToken Cancel = default);
    }

    /// <summary>Репозиторий именованных сущностей</summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface INamedRepositoryAsync<T> : INamedRepositoryAsync<T, int>, IRepositoryAsync<T> where T : INamedEntity { }
}
