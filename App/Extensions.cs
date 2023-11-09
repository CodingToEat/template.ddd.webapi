using MediatR;
using MicroServiceName.App.Behav;
using MicroServiceName.App.Qry;
using MicroServiceName.Dom.Agg;
using MicroServiceName.Dom.Seed;
using MicroServiceName.Infra.repo;

namespace MicroServiceName.App;

public static class Extensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IEntityRepository<MicroServiceNameAgg>, EntityRepository<MicroServiceNameAgg>>();
        services.AddTransient<IEntityRepository<MicroServiceNameHistoryAgg>, EntityRepository<MicroServiceNameHistoryAgg>>();
        services.AddTransient<IMicroServiceNameQry, MicroServiceNameQry>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehav<,>));
    }
}
