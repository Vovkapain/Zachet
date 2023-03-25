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
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Page
    {
        private User _currentMaterial = new User();
        public AddUsers(User selectedMaterials)
        {
            InitializeComponent();
            if (selectedMaterials != null)
                _currentMaterial = selectedMaterials;

            DataContext = _currentMaterial;
            MaterialCombo.ItemsSource = AgentstvoEntities.GetContext().Role.ToList();
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

           

            if (string.IsNullOrWhiteSpace(_currentMaterial.Name))
                errors.AppendLine("Укажите имя");
            if (_currentMaterial.Role == null)
                errors.AppendLine("Укажите Должность");
            if (string.IsNullOrWhiteSpace(_currentMaterial.Login))
                errors.AppendLine("Введите Логин");
            if (string.IsNullOrWhiteSpace(_currentMaterial.Password))
                errors.AppendLine("Введите пароль Количество");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaterial.UserId == 0)
                AgentstvoEntities.GetContext().User.Add(_currentMaterial);

            try
            {
                AgentstvoEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            Manager.MainFrame.Navigate(new UserList());

        }
    }
}
