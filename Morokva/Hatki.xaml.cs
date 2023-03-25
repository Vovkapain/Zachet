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
    /// Логика взаимодействия для Hatki.xaml
    /// </summary>
    public partial class Hatki : Page
    {
        public Hatki()
        {
            InitializeComponent();
            DGMaterials.ItemsSource = AgentstvoEntities.GetContext().Nedvizimost.ToList();
        }

        


        private void isvb(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {

                DGMaterials.ItemsSource = AgentstvoEntities.GetContext().Nedvizimost.ToList();
            }
        }

        
    }
}
