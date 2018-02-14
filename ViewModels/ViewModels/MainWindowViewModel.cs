using System;
using System.Windows.Input;
using Models;
using Unity;
using ViewModels.Common;
using ViewModels.Interfaces;

namespace ViewModels.ViewModels
{
    public class MainWindowViewModel : BindableBase, IMainViewModel
    {
        private BindableBase _selectedView;
        private readonly IUnityContainer _unityContainer;
        private string _nextButtonText;
        public event EventHandler<EventArgs> SaveData;
        public MainWindowViewModel(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            Next = new RelayCommand(action=>ChangeNextView());
            Previous = new RelayCommand(action=> ChangePreviousView());
            SelectedView = (_unityContainer.Resolve<IUserPersonalInfo>() as UserPersonalInfo);
            NextButtonText = "Next";
        }

        public BindableBase SelectedView
        {
            get{ return _selectedView; }
            set { _selectedView = value; OnPropertyChanged("SelectedView"); }
        }

        public ICommand Next { get; }
        public ICommand Previous { get; }

        public string NextButtonText
        {
            get
            {
                return _nextButtonText;
            }

            set
            {
                _nextButtonText = value;
                OnPropertyChanged("NextButtonText");
            }
        }

        private void ChangeNextView()
        {
            if( SelectedView is UserPersonalInfo)
            { 
                var thirdViewModel = (_unityContainer.Resolve<IUserFullDetails>() as UserFullDetails);
                if (thirdViewModel != null)
                {
                    SelectedView = thirdViewModel;
                    NextButtonText = "Save";
                }
            }
            else if (SelectedView is UserFullDetails)
            {
                var user = _unityContainer.Resolve<UserModel>();
                OnSaveData(new EventArgs());
            }
        }

       
        protected virtual void OnSaveData(EventArgs e)
        {
            EventHandler<EventArgs> handler = SaveData;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void ChangePreviousView()
        {
            if (SelectedView is UserFullDetails)
            {
                SelectedView = (_unityContainer.Resolve<IUserPersonalInfo>() as UserPersonalInfo);
                NextButtonText = "Next";
            }
        }
    }
}
