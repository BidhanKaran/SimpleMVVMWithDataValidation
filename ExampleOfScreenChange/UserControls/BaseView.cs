using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Unity;

namespace ExampleOfScreenChange.UserControls
{
    public class BaseView:UserControl
    {
        public static IUnityContainer UniversalUnityContainer { get; set; }
    }
}
