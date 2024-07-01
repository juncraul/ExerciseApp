using ExerciseApp.ConfigurationOptions;
using ExerciseApp.Contracts;
using Microsoft.Extensions.Options;

namespace ExerciseApp.Services
{
    public class RunService : IRunService
    {
        private readonly ILogger<RunService> _logger;
        private readonly RunServiceOptions _options;

        public RunService(ILogger<RunService> logger, IOptions<RunServiceOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public async Task Run()
        {
            try
            {
                // Simulate some work with a delay
                await Task.Delay(_options.DelayMilliseconds);

                // Additional business logic could be placed here
                _logger.LogInformation("Performing some important work...");

                // Simulate another piece of work
                await Task.Delay(_options.DelayMilliseconds);

                _logger.LogInformation("Run method completed successfully. ");
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur within the Run method
                _logger.LogError(ex, "An error occurred in the Run method.");
            }
        }
    }
}
