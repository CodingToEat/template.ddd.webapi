using MediatR;
using MicroServiceName.Dom.Seed;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceName.Infra;

public static class Extensions
{
    public const string ConnectionStringLabel = "ConnectionString";

    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, string assemblyName)
    {
        services.AddDbContext<MicroServiceNameCtx>(
        options =>
        {
            options.UseSqlServer(configuration[ConnectionStringLabel],
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(assemblyName);
            }
            );
        }
        );
    }

    public static void MigrateDB(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<MicroServiceNameCtx>();
            db.Database.Migrate();
        }
    }

    public static async Task DispatchDomainEventsAsync(this IMediator mediator, MicroServiceNameCtx ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}
