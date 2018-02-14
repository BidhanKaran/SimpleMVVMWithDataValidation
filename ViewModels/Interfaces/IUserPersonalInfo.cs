using System.Windows.Input;
using Models;

namespace ViewModels.Interfaces
{
    public interface IUserPersonalInfo
    {
        UserModel User { get; set; }
        ICommand LoadCommand { get; }
    }
}
