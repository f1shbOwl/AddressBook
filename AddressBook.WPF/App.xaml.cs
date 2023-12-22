using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using AddressBook.WPF.Mvvm.ViewModels;
using AddressBook.WPF.Mvvm.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace AddressBook.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost? _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<FileService>();
                    services.AddSingleton<ContactService>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<ContactListViewModel>();
                    services.AddTransient<ContactListView>();
                    services.AddTransient<ContactAddView>();
                    services.AddTransient<ContactAddViewModel>();
                    services.AddTransient<MainMenuViewModel>();
                })
                .Build();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host!.Start();

            var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
