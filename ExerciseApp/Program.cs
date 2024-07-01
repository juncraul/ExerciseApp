
using ExerciseApp.ConfigurationOptions;
using ExerciseApp.Contracts;
using ExerciseApp.Services;

class Program
{
    static async Task Main(string[] args)
    {
        // Create a HostBuilder and configure services and logging
        var builder = Host.CreateApplicationBuilder(args);

        ConfigureAppConfiguration(builder.Configuration);
        ConfigureServices(builder.Services);
        ConfigureLogging(builder.Logging);

        var app = builder.Build();

        // Activate the RunService
        var runService = app.Services.GetRequiredService<IRunService>();
        await runService.Run();

        await app.RunAsync();
    }
    private static void ConfigureAppConfiguration(IConfigurationBuilder config)
    {
        // Load configuration from appsettings.json and environment variables
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register services
        services.Configure<RunServiceOptions>(services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetSection("RunService"));
        services.AddTransient<IRunService, RunService>();
    }

    private static void ConfigureLogging(ILoggingBuilder logging)
    {
        // Configure logging
        logging.ClearProviders();
        logging.AddConsole();
    }
}
