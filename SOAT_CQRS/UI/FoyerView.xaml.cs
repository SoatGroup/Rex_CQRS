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

namespace SOAT_CQRS.UI
{
    /// <summary>
    /// Logique d'interaction pour FoyerView.xaml
    /// </summary>
    public partial class FoyerView : UserControl
    {
        public FoyerView()
        {
            InitializeComponent();
        }


        private void FoyerView_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new FoyerviewModel();
        }
    }
}
