﻿using System;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MinimizeDisposeControl : UserControl
    {
        public MinimizeDisposeControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void minimizeButton_click(object sender, RoutedEventArgs e)
        {
            StartWindow.window.WindowState = WindowState.Minimized;
            
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.window.Close();
        }
    }
}
