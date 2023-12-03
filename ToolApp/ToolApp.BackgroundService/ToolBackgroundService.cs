using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToolApp.DAL.Entities;
using ToolApp.DAL.Interfaces;

namespace ToolApp.AppBackgroundService
{
    public class ToolBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _service;
        private readonly TimeSpan _interval = TimeSpan.FromSeconds(20);

        public ToolBackgroundService(IServiceProvider service)
        {
            _service = service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {

                using (var scope = _service.CreateScope())
                {
                    var toolRepository = scope.ServiceProvider.GetRequiredService<IToolRepository>();

                    try
                    {
                        toolRepository.DeleteTool(toolRepository.GetAllTools().First().Id);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}