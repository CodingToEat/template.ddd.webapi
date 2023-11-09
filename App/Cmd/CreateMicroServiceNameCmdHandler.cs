using MediatR;
using MicroServiceName.Dom.Agg;
using MicroServiceName.Dom.Seed;

namespace MicroServiceName.App.Cmd
{
    public static class CreateMicroServiceNameCmdHandler
    {
        public record Cmd(string Name):IRequest;

        public class Handler(
            IEntityRepository<MicroServiceNameAgg> MicroServiceNameRepository) : IRequestHandler<Cmd>
        {
            public async Task Handle(Cmd request, CancellationToken cancellationToken)
            {
                var microService = MicroServiceNameAgg.Create(request.Name);
                await MicroServiceNameRepository.Create(microService);

                await MicroServiceNameRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
        }
    }
}
