using System;
using System.Windows.Input;
using Models;
using Unity;
using ViewModels.Common;
using ViewModels.Interfaces;

namespace ViewModels.ViewModels
{
    public class UserFullDetails : BindableBase, IUserFullDetails
    {
       
        private readonly IUnityContainer _unityContainer;
        private UserModel _user;
        private string _status;

        public UserFullDetails(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            var mainViewModel = _unityContainer.Resolve<IMainViewModel>() as MainWindowViewModel;
            mainViewModel.SaveData += MainViewModel_SaveData;
            LoadDataCommand = new RelayCommand(method => LoadData());
        }

        private void MainViewModel_SaveData(object sender, EventArgs e)
        {
            Status = "Data is being saved.";
        }

        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public ICommand LoadDataCommand { get; }

        public string Status
        {
            get
            {
                return  _status;
            }

            set
            {
               _status = value;
                OnPropertyChanged("Status");
            }
        }

        private void LoadData()
        {
            if (_unityContainer != null)
                User = _unityContainer.Resolve<UserModel>();
        }
    }
}
