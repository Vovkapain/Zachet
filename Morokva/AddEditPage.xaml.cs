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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Nedvizimost _currentMaterial = new Nedvizimost();
        public AddEditPage(Nedvizimost selectedMaterials)
        {
            InitializeComponent();

            if (selectedMaterials != null)
                _currentMaterial = selectedMaterials;

            DataContext = _currentMaterial;

        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentMaterial.Type))
                errors.AppendLine("Укажите ТИП недвижемости");
            if (_currentMaterial.Street == null)
                errors.AppendLine("Укажите улицу");
            if (_currentMaterial.Dom == null)
                errors.AppendLine("Укажите дом");
            if (_currentMaterial.Kvartira == null)
                errors.AppendLine("укажите Квартиру");
            if (_currentMaterial.Status == null)
                errors.AppendLine("укажите Статус");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaterial.IdNedviz == 0)
                AgentstvoEntities.GetContext().Nedvizimost.Add(_currentMaterial);

            try
            {
                AgentstvoEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            Manager.MainFrame.Navigate(new AdminPanel());

        }
    }
}
