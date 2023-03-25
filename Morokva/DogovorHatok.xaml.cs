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
    /// Логика взаимодействия для DogovorHatok.xaml
    /// </summary>
    public partial class DogovorHatok : Page
    {
        public DogovorHatok()
        {
            InitializeComponent();
            DGMaterials.ItemsSource = AgentstvoEntities.GetContext().Dogovor.ToList();
        }

        private void btnUserClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserList());
        }

        private void btnDogClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPanel());
        }
    }
}
