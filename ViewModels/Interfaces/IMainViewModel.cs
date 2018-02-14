using System;
using System.Windows.Input;
using Models;

namespace ViewModels.Interfaces
{
    public interface IMainViewModel
    {
        event EventHandler<EventArgs> SaveData;
         ICommand Next { get; }
         ICommand Previous { get; }
         BindableBase SelectedView
        {
            get;
            set;
        }

        string NextButtonText { get; set; }
    }
}
