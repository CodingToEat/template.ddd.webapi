using MicroServiceName.Dom.Seed;

namespace MicroServiceName.Infra.repo;

public class EntityRepository<T>(MicroServiceNameCtx context) : Repository(context), 
    IEntityRepository<T> where T : Entity
{
    public virtual async Task Create(T entity) => await _context.AddAsync(entity);
    public virtual void Update(T entity) => _context.Update(entity);

    public virtual async Task<T> GetById(Guid id)
    {
        var result = await _context.FindAsync<T>(id)
                        ?? throw new KeyNotFoundException();
        return result;
    }

    public virtual void Delete(T entity)
    {
        entity.OnDelete();
        _context.Update(entity);
    }
}

public abstract class Repository
{
    protected readonly MicroServiceNameCtx _context;

    public IUnitOfWork UnitOfWork
    {
        get
        {
            return _context;
        }
    }

    protected Repository(MicroServiceNameCtx context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}

