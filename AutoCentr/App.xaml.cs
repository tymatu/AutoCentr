using AutoCentr.ModelView;
using AutoCentr.View;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;


namespace AutoCentr;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider? ServiceProvider { get; private set; }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowVM>();
        services.AddTransient<LoginView>();
        services.AddTransient<LoginVM>();
        services.AddTransient<Menu>();
        services.AddTransient<ZakaznikyView>();
        services.AddTransient<ZakaznikyVM>();
        services.AddTransient<PracovnikyView>();
        services.AddTransient<PracovnikyVM>();
        services.AddTransient<OpravyView>();
        services.AddTransient<OpravaVM>();
        services.AddTransient<ProfileView>();
        services.AddTransient<ProfileVM>();
    }

    private void Start(object sender, StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();
        var lg = ServiceProvider.GetRequiredService<MainWindow>();
        Current.MainWindow = lg;
        lg.Show();
    }
}

