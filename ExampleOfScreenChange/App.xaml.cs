using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using ExampleOfScreenChange.UserControls;
using Models;
using Unity;
using ViewModels;
using ViewModels.Interfaces;

namespace ExampleOfScreenChange
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterInstance(unityContainer);
            var configurator = new Configurator(unityContainer);
            configurator.RegisterAll();
            BaseView.UniversalUnityContainer = unityContainer;
            UserModel user = new UserModel();
            BaseView.UniversalUnityContainer.RegisterInstance(user);
            var mainViewModel = unityContainer.Resolve<IMainViewModel>();
            BaseView.UniversalUnityContainer.RegisterInstance(mainViewModel);
            var mainWindow = new MainWindow {DataContext = mainViewModel};
            mainWindow.Show();
        }
    }
}
