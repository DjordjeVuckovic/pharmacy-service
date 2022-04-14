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
using Scar.Common.WPF.Controls;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView;


namespace TechHealth
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*Doctor specialist = new Doctor
            {
                Address = null,
                Email = "spec@spec.com",
                Employed = true,
                Jmbg = "131213121111",
                Name = "John",
                Surname = "Black",
                Password = "1",
                Username = "1",
                Phone = "06123111114",
                Specialization = specialization
            };*/
            //DoctorRepository.Instance.Create(specialist);
            //Doctor doctor = DoctorRepository.Instance.GetById("1313");
            

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
            new ManagerMainWindow().Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            new LoginWindow().Show();
            Close();

        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            

            InitializeComponent();
        }
    }
}
