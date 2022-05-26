using MyNotes.Domain.Base.Enitities;

namespace MyNotes.Domain.Entities
{

    /// <summary>Именованная сущность</summary>
    /// <typeparam name="TKey">Тип первичного ключа</typeparam>
    public abstract class NamedEntity<TKey> : Entity<TKey>, INamedEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>Имя</summary>
        public string Name { get; set; } = null!;

        /// <summary>Инициализация новой именованной сущности</summary>
        protected NamedEntity() { }

        /// <summary>Инициализация новой именованной сущности</summary>
        /// <param name="Name">Имя</param>
        protected NamedEntity(string Name) => this.Name = Name;

        /// <summary>Инициализация новой именованной сущности</summary>
        /// <param name="Id">Идентификатор</param>
        protected NamedEntity(TKey Id) : base(Id) { }

        /// <summary>Инициализация новой именованной сущности</summary>
        /// <param name="Id">Идентификатор</param><param name="Name">Имя</param>
        protected NamedEntity(TKey Id, string Name) : base(Id) => this.Name = Name;

        public override bool Equals(object? obj)
        {
            return base.Equals(obj) && Equals((NamedEntity<TKey>)obj);
        }
        public bool Equals(NamedEntity<TKey>? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (!other.GetType().IsAssignableTo(GetType())) return false;
            if (EqualityComparer<string>.Default.Equals(Name, null))
                return ReferenceEquals(this, other);
            return EqualityComparer<string>.Default.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<string>.Default.Equals(Name, null)
                ? base.GetHashCode()
                : base.GetHashCode() + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }

    /// <summary>Именованная сущность</summary>
    public abstract class NamedEntity : NamedEntity<int>, INamedEntity
    {
        /// <summary>Инициализация новой именованной сущности</summary>
        protected NamedEntity() { }

        /// <summary>Инициализация новой именованной сущности</summary>
        /// <param name="Name">Имя</param>
        protected NamedEntity(string Name) : base(Name) { }

        /// <summary>Инициализация новой именованной сущности</summary>
        /// <param name="Id">Идентификатор</param>
        protected NamedEntity(int Id) : base(Id) { }

        /// <summary>Инициализация новой именованной сущности</summary>
        /// <param name="Id">Идентификатор</param><param name="Name">Имя</param>
        protected NamedEntity(int Id, string Name) : base(Id, Name) { }
    }
}
