using System.IO;
using System.Text;
using System.Windows;
using MapDataVisualizer.App.Db.Context;
using MapDataVisualizer.App.Db.Repository;
using MapDataVisualizer.App.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace MapDataVisualizer.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();


            ConfigureServices(serviceCollection, Configuration);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            ApplicationContextInitializer contextInitializer = ServiceProvider.GetRequiredService<ApplicationContextInitializer>();
            contextInitializer.Initialize();
            contextInitializer.SeedData();

            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddNLog(configuration);
            });

            services.AddTransient(typeof(MainWindow));

            services.AddDbContext<ApplicationDbContext>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddTransient<ApplicationContextInitializer>();

            services.AddTransient<IDataStorageRepository, DataStorageRepository>();

            services.AddSingleton<MainViewModel>();
        }
    }
}