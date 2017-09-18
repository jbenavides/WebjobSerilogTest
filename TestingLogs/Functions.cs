using Microsoft.Azure.WebJobs;
using Serilog;
using TestingLogs.Logic;

namespace TestingLogs
{
    public class Functions
    {
        private readonly ILogicTest _logicTest;
        private readonly ILogger _logger;

        public Functions(ILogicTest logicTest, ILogger logger)
        {
            _logger = logger;
            _logicTest = logicTest;
        }

        public void ProcessQueueMessage([QueueTrigger("serilogtesting")] string message)
        {
            _logger.Information($"Final Message: {_logicTest.GetMessage(message)} - Information");
            _logger.Warning($"Final Message: {_logicTest.GetMessage(message)} - Warning");
            _logger.Error($"Final Message: {_logicTest.GetMessage(message)} - Error");
            _logger.Fatal($"Final Message: {_logicTest.GetMessage(message)} - Fatal");
        }
    }
}
