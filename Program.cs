using MediatR;
using MicroServiceName.App;
using MicroServiceName.App.Cmd;
using MicroServiceName.App.Qry;
using MicroServiceName.Infra;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
var assemblyName = assembly.GetName().Name ?? throw new Exception();

builder.Services.AddInfrastructureServices(builder.Configuration, assemblyName);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.MigrateDB();

app.MapPost("/MicroServiceName",
    async (IMediator mediator, MicroServiceNameDto dto) =>
    {
        if (dto is { Name: not null})
        {
            CreateMicroServiceNameCmdHandler.Cmd cmd = new CreateMicroServiceNameCmdHandler.Cmd(dto.Name);
            await mediator.Send(cmd);
        }
    });

app.MapGet("/MicroServiceName",
    async (IMicroServiceNameQry queries) =>
    await queries.GetAsync());

app.MapPatch("/MicroServiceName/{id}",
    async (IMediator mediator, Guid id, MicroServiceNameDto dto) =>
    {
        if (dto is { Name: not null })
        {
            UpdateMicroServiceNameCmdHandler.Cmd cmd = new UpdateMicroServiceNameCmdHandler.Cmd(id, dto.Name);
            await mediator.Send(cmd);
        }
    });

app.MapDelete("/MicroServiceName/{id}",
    async (IMediator mediator, Guid id) =>
    {
        DeleteMicroServiceNameCmdHandler.Cmd cmd = new DeleteMicroServiceNameCmdHandler.Cmd(id);
        await mediator.Send(cmd);
    });

app.Run();

class MicroServiceNameDto { 
    public string? Name { get; set; }
}