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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Morokva
{
    /// <summary>
    /// Логика взаимодействия для avtorizz.xaml
    /// </summary>
    public partial class avtorizz : Page
    {
        public avtorizz()
        {
            InitializeComponent();
            AppData.modelOdb = new AgentstvoEntities();
        }
        private void guestclick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Hatki());
        }

        private void Vhod(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppData.modelOdb.User.FirstOrDefault(x => x.Login == btLogin.Text && x.Password == tbPass.Password);
                if(userObj == null)
                {
                    MessageBox.Show("Пользователь не найден");
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            Manager.MainFrame.Navigate(new AdminPanel());
                            break;
                        case 2:
                            Manager.MainFrame.Navigate(new ManagerHatki());
                            break;
                        case 3:
                            Manager.MainFrame.Navigate(new Hatki()); ;
                            break;
                    }
                }
                //var userObj = AppData.modelOdb.User.FirstOrDefault(x => x.Login == btLogin.Text && x.Password == tbPass.Password);
                //if (userObj == null)
                //{
                //    MessageBox.Show("Пользователь не найден ");
                //}
                //else
                //{
                //    switch (userObj.Role)
                //    {
                //        case 1: MessageBox.Show("Ghbdtn");
                //            break;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString());
            }
        }

        private void reg(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CreateAc());
        }
    }
}
