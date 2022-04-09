using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Address address1 = new Address
            {
                City = "Novi Sad",
                StreetNumber = "21",
                Country = "Srbija",
                Street = "Puse Pusica",
                Postcode = 21000
            };
            Manager manager = new Manager()
            {
                Username = "Nenad",
                Password = "1",
                Email = "Nenad@Nenad",
                Name = "Nenad",
                Surname = "11",
                Jmbg = "1313",
                Employed = true,
                Phone = "0613412313",
                Address = address1
            };
            ManagerRepository.Instance.Create(manager);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
            
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            new LoginWindow().Show();
            this.Close();

        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            

            InitializeComponent();
        }
    }
}
