using AutoCentr.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoCentr.View
{
    /// <summary>
    /// Interaction logic for PracovnikyView.xaml
    /// </summary>
    public partial class PracovnikyView : UserControl
    {
        public PracovnikyView(PracovnikyVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
