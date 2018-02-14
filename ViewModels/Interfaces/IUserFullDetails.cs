using System.Windows.Input;
using Models;

namespace ViewModels.Interfaces
{
    public interface IUserFullDetails
    {
        ICommand LoadDataCommand { get; }
        UserModel User { get; set; }
        string Status { get; set; }
    }
}
