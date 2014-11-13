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

namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for OptionsMinimizeDisposeControl.xaml
    /// </summary>
    public partial class OptionsMinimizeDisposeControl : UserControl
    {
        public OptionsMinimizeDisposeControl()
        {
            InitializeComponent();
        }

        private void optionsButton_click(object sender, RoutedEventArgs e)
        {
            OptionPopUp.IsOpen = true;
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.pages.startPage.IsEnabled = true;
            StartWindow.SetPage(StartWindow.pages.startPage);
        }
    }
}
