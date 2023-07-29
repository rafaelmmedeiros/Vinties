using AuctionService.Consumers;
using AuctionService.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AuctionDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMassTransit(busConfig =>
{
    busConfig.AddEntityFrameworkOutbox<AuctionDbContext>(config =>
    {
        config.QueryDelay = TimeSpan.FromMilliseconds(10);
        config.UsePostgres();
        config.UseBusOutbox();
    });
    busConfig.AddConsumersFromNamespaceContaining<AuctionCreatedFaultConsumer>();
    busConfig.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("auction", false));
    busConfig.UsingRabbitMq((context, config) =>
    {
        config.ConfigureEndpoints(context);
    });
});
    
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

try
{
    DbInitializer.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

app.Run();