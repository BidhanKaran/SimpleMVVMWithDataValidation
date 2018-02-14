using Unity;
using ViewModels.Interfaces;
using ViewModels.ViewModels;

namespace ViewModels
{
    public class Configurator
    {
        private readonly IUnityContainer _unityContainer;
        public Configurator(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public void RegisterAll()
        {
            _unityContainer.RegisterType<IMainViewModel, MainWindowViewModel>();
            _unityContainer.RegisterType<IUserPersonalInfo, UserPersonalInfo>();
            _unityContainer.RegisterType<IUserFullDetails, UserFullDetails>();
        }
    }
}
