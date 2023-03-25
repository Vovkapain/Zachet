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
    /// Логика взаимодействия для ManagerHatki.xaml
    /// </summary>
    public partial class ManagerHatki : Page
    {
        public ManagerHatki()
        {
            InitializeComponent();
            DGMaterials.ItemsSource = AgentstvoEntities.GetContext().Nedvizimost.ToList();
        }
        

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnEditClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Nedvizimost));
        }

        private void btnDelClick(object sender, RoutedEventArgs e)
        {
            var materialsremoving = DGMaterials.SelectedItems.Cast<Nedvizimost>().ToList();

            if (MessageBox.Show("Точно удалить выбранные элементы?") == MessageBoxResult.OK)
            {
                try
                {
                    AgentstvoEntities.GetContext().Nedvizimost.RemoveRange(materialsremoving);
                    AgentstvoEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGMaterials.ItemsSource = AgentstvoEntities.GetContext().Nedvizimost.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnDogClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DogovorHatokManager());
        }
    }
}
