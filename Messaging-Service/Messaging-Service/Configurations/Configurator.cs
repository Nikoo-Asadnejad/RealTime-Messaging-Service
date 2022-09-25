using ErrorHandlingDll.Configurations;
using GenericRepositoryDll.Configuration;
using HttpService.Configuration;
using Messaging_Service.Business.Interfaces;
using Messaging_Service.Business.Services;
using Messaging_Service.DataAccess.DataContext;
using Messaging_Service.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Messaging_Service.Configurations
{
  public static class Configurator
  {

    public static void InjectServices(IServiceCollection services, IConfiguration configuration)
    {

      services.AddControllers();
      services.AddEndpointsApiExplorer();

      services.AddSwaggerGen(c =>
      {
        var filePath = Path.Combine(AppContext.BaseDirectory, "MessagingService.xml");
        c.IncludeXmlComments(filePath);
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
         {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          } });

      });

      services.Configure<AppSetting>(configuration);

      services.AddAuthentication();
 
      var connection = configuration.GetConnectionString("SQLServer");
      services.AddDbContext<MessengerContext>(options => options.UseSqlServer(connection));
      services.AddScoped<DbContext, MessengerContext>();

      ErrorHandlingDllConfigurator.InjectServices(services, configuration);
      HttpServiceConfigurator.InjectHttpService(services);
      GenericRepositoryConfigurator.InjectServices(services);

      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IMessageService, MessageService>();
      services.AddScoped<IChatService, ChatService>();


    }

    public static void ConfigPipeLines(WebApplication app)
    {

      //  ErrorHandlingDllConfigurator.ConfigureAppPipeline(app);
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
      app.MapControllers();

      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "Messaging-Service API's");
        });
      }


    }

  }

}
