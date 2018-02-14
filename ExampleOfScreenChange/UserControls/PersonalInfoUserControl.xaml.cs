using Unity;
using ViewModels.Interfaces;

namespace ExampleOfScreenChange.UserControls
{
    /// <summary>
    /// Interaction logic for FirstUserControl.xaml
    /// </summary>
    public partial class PersonalInfoUserControl : BaseView
    {
        public PersonalInfoUserControl()
        {
            InitializeComponent();
            this.DataContext = UniversalUnityContainer.Resolve<IUserPersonalInfo>();
        }
    }
}
