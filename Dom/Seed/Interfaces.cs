namespace  MicroServiceName.Dom.Seed;

public interface IEntityRepository<T> : IRepository where T : Entity
{
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetById(Guid id);
}

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task SaveEntitiesAsync(CancellationToken cancellationToken = default);
}

public interface IAggregateRoot;