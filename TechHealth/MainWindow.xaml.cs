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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
            /*Secretary secretary = new Secretary()
            {
                Email = "adsa@adsa",
                Address = null,
                Employed = true,
                Jmbg = "13443",
                Name = "igor",
                Surname = "Miskic",
                Password = "11",
                Phone = "05111331",
                Username = "igor"
            };
            Secretary secretary1 = new Secretary()
            {
                Email = "adsa@adsa",
                Address = null,
                Employed = true,
                Jmbg = "13456",
                Name = "miki",
                Surname = "Miskic",
                Password = "111",
                Phone = "05111331",
                Username = "miki"
            };*/
            Patient patient = new Patient()
            {
                Email = "dsa@adsa",
                Address = null,
                Employed = false,
                Jmbg = "13456",
                Name = "miki",
                Surname = "Djuricic",
                Password = "1311",
                Phone = "06105111331",
                Username = "Djura"
            };
            PatientRepository.Instance.Create(patient);

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
