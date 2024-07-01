
class Program
{
    static async Task Main(string[] args)
    {
        // Create a HostBuilder and configure services and logging
        var builder = Host.CreateApplicationBuilder(args);


        builder.Services.AddTransient<IRunService, RunService>();

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        
        var app = builder.Build();

        // Activate the RunService
        var runService = app.Services.GetRequiredService<IRunService>();
        await runService.Run();

        await app.RunAsync();
    }
}

public interface IRunService
{
    Task Run();
}

public class RunService : IRunService
{
    private readonly ILogger<RunService> _logger;

    public RunService(ILogger<RunService> logger)
    {
        _logger = logger;
    }

    public async Task Run()
    {
        try
        {
            // Simulate some work with a delay
            await Task.Delay(1000);

            // Additional business logic could be placed here
            _logger.LogInformation("Performing some important work...");

            // Simulate another piece of work
            await Task.Delay(500);

            _logger.LogInformation("Run method completed successfully. ");
        }
        catch (Exception ex)
        {
            // Log any exceptions that occur within the Run method
            _logger.LogError(ex, "An error occurred in the Run method.");
        }
    }
}
