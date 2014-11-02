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
using System.Windows.Shapes;

namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public static StartPage _startPage = new StartPage();
        public static StartWindow window;
        public StartWindow()
        {
            InitializeComponent();
            this.Content = _startPage;
            window = this;
        }

        public static void SetPage(UserControl page)
        {
            window.Content = page;
        }
    }
}
