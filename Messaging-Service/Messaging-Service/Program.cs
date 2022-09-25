using Messaging_Service.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Configurator.InjectServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configurator.ConfigPipeLines(app);

app.Run();
