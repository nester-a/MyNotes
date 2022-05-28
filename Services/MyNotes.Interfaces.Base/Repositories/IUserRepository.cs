using MyNotes.Domain.Base;

namespace MyNotes.Interfaces.Base.Repositories
{
    /// <summary>Репозиторий сущностей пользователя</summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IUserRepository<T> where T : IUser { }
}
