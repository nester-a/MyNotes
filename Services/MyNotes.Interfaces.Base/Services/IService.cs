using MyNotes.Domain.Base.Enitities;

namespace MyNotes.Interfaces.Base.Services
{
    /// <summary>Сервис сущностей</summary>
    /// <typeparam name="T">Тип сущности, с которой работает сервис</typeparam>
    /// <typeparam name="TKey">Тип первичного ключа</typeparam>
    public interface IService<T, in TKey> where T : IEntity<TKey>
    {
        /// <summary>Получение всех сущностей</summary>
        /// <returns>Коллекция всех сущностей</returns>
        ICollection<T> GetAll();

        /// <summary>Получить сущность по указанному идентификатору</summary>
        /// <param name="id">Идентификатор извлекаемой сущности</param>
        /// <returns>Сущность с указанным идентификатором</returns>
        T GetById(TKey id);

        /// <summary>Создать новую сущность</summary>
        /// <param name="newEntity">Новая сущность</param>
        /// <returns>Вновь созданная сущность</returns>
        T Create(T newEntity);

        /// <summary>Изменить имеющуюся сущность</summary>
        /// <param name="id">Идентификатор изменяемой сущности</param>
        /// <param name="entityForUpdate">Изменённая сущность</param>
        /// <returns>Изменённая сущность</returns>
        T Update(TKey id, T entityForUpdate);

        /// <summary>Удаление сущности</summary>
        /// <param name="id">Идентификатор удаляемой сущности</param>
        /// <returns>Удалённая сущность</returns>
        T Delete(TKey id);
    }
}
