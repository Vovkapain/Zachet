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
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        public UserList()
        {
            InitializeComponent();
            DGMaterials.ItemsSource = AgentstvoEntities.GetContext().User.ToList();
        }



        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            //Manager.MainFrame.Navigate(new AddUsers(null));
        }

        private void btnUserClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPanel());
        }

        private void isvb(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {

                DGMaterials.ItemsSource = AgentstvoEntities.GetContext().Nedvizimost.ToList();
            }
        }

        private void BtnEditClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddUsers((sender as Button).DataContext as User));
        }

        private void btnDelClick(object sender, RoutedEventArgs e)
        {
            var Userremoving = DGMaterials.SelectedItems.Cast<User>().ToList();

            if (MessageBox.Show("Точно удалить выбранные элементы?") == MessageBoxResult.OK)
            {
                try
                {
                    AgentstvoEntities.GetContext().User.RemoveRange(Userremoving);
                    AgentstvoEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGMaterials.ItemsSource = AgentstvoEntities.GetContext().User.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnDogClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DogovorHatok());
        }
    }
}
