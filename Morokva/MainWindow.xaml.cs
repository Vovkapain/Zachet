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

namespace Morokva
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            MainFrame.Navigate(new avtorizz());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void MFcontent(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
                btnMenu.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
                btnMenu.Visibility = Visibility.Hidden;
            }
        }

        private void Buttonexit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new avtorizz());
        }
    }
}
