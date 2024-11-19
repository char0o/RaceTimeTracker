using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using RacetimeTrackerClient.Services;

namespace RacetimeTrackerClient;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        ServiceCollection serviceCollection = new ServiceCollection();
        
        serviceCollection.AddHttpClient<UserService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5026");
        });
        
        serviceCollection.AddSingleton<UserService>();
        serviceCollection.AddSingleton<MainWindow>();
        
        ServiceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}