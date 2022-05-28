using MyNotes.Domain.Base.Enitities;

namespace MyNotes.Interfaces.Base.Services
{
    /// <summary>Сервис именованных сущностей</summary>
    /// <typeparam name="T">Тип именованной сущности, с которой работает сервис</typeparam>
    /// <typeparam name="TKey">Тип первичного ключа</typeparam>
    public interface INamedService<T, in TKey> : IService<T, TKey> where T : INamedEntity<TKey>
    {
        /// <summary>Получение всех именованных сущностей с указанным именем</summary>
        /// <param name="name">Имя получаемых сущностей</param>
        /// <returns>Коллекция именованных сущностей</returns>
        ICollection<T> GetAllByName(string name);

        /// <summary>Изменяет все сущности с данным именем</summary>
        /// <param name="name">Имя изменяемых сущностей</param>
        /// <param name="entityForUpdate">Изменённая сущность</param>
        /// <returns>Коллекция изменённых именованных сущностей</returns>
        ICollection<T> UpdateAllByName(string name, T entityForUpdate);

        /// <summary>Удаление всех сущностей с данным именем</summary>
        /// <param name="name">Имя удаляемых сущностей</param>
        /// <returns>Коллекция удалённых именованных сущностей</returns>
        ICollection<T> DeleteAllByName(string name);
    }

    /// <summary>Сервис именованных сущностей</summary>
    /// <typeparam name="T">Тип именованной сущности, с которой работает сервис</typeparam>
    public interface INamedService<T> : INamedService<T, int> where T : INamedEntity<int> { }
}
