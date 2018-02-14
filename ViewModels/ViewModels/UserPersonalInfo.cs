using System.Windows.Input;
using Models;
using Unity;
using ViewModels.Common;
using ViewModels.Interfaces;

namespace ViewModels.ViewModels
{
    public class UserPersonalInfo : BindableBase, IUserPersonalInfo
    {
        private readonly IUnityContainer _unityContainer;
        private UserModel _user;

        public UserPersonalInfo(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            LoadCommand = new RelayCommand(method=>Load());
        }

        private void Load()
        {
            if (_unityContainer != null)
                User = _unityContainer.Resolve<UserModel>(); //We can resolve both interface and class provided we have registered for it. See app.cs for registration.
        }

        public ICommand LoadCommand { get; }

        public UserModel User
        {
            get { return _user; }

            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

    }
}
