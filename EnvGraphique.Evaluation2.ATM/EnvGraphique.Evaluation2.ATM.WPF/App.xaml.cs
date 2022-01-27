using EnvGraphique.Evaluation2.ATM.Domain.Models;
using EnvGraphique.Evaluation2.ATM.Domain.Services;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Authentication;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.State;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            MainWindow window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<ATMEntities>();
            services.AddSingleton<IUserDataService, UserDataService>();
            services.AddSingleton<IAccountDataService, AccountDataService>();
            services.AddSingleton<ITransactionDataService, TransactionDataService>();
            services.AddSingleton<ITransactionService, TransactionService>();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IAdminManagementService, AdminManagementService>();

            services.AddScoped<Navigator>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<LoginViewModel>();
            services.AddScoped<ClientHomeViewModel>();
            services.AddScoped<AdminHomeViewModel>();
            services.AddScoped<ClientNavigationBarViewModel>();
            services.AddScoped<AdminNavigationBarViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
