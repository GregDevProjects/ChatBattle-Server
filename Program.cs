using chat.Hubs;
using SignalRChat.Hubs;
using System.Timers;



var builder = WebApplication.CreateBuilder(args);

SetupBuilderServices(builder);
var app = builder.Build();
SetupWebbApplication(app);


app.Run();


void SetupBuilderServices(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .WithMethods("GET", "POST")
                .AllowCredentials();
            });
    });

    builder.Services.AddSignalR();
}

void SetupWebbApplication(WebApplication app)
{
    app.UseCors();
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHub<ChatHub>("/chathub");
    });
}


//TODO
/*1. Setup logging
2. Setup Unit test
3. Remove Swagger docs and uneeded endpoints
4. Environment variables?
 */