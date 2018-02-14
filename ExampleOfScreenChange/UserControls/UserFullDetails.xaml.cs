using Unity;
using ViewModels.Interfaces;

namespace ExampleOfScreenChange.UserControls
{
    /// <summary>
    /// Interaction logic for SecondUserControl.xaml
    /// </summary>
    public partial class SecondUserControl : BaseView
    {
        public SecondUserControl()
        {
            InitializeComponent();
            this.DataContext = UniversalUnityContainer.Resolve<IUserFullDetails>();
        }
    }
}
