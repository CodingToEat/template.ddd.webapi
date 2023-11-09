using MediatR;
using MicroServiceName.Dom.Agg;
using MicroServiceName.Dom.Seed;

namespace MicroServiceName.App.Cmd
{
    public static class DeleteMicroServiceNameCmdHandler
    {
        public record Cmd(Guid Id):IRequest;

        public class Handler(
            IEntityRepository<MicroServiceNameAgg> MicroServiceNameRepository) : IRequestHandler<Cmd>
        {
            public async Task Handle(Cmd request, CancellationToken cancellationToken)
            {
                var entity = await MicroServiceNameRepository.GetById(request.Id);
                entity.Delete();

                MicroServiceNameRepository.Delete(entity);
                await MicroServiceNameRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
        }
    }
}
