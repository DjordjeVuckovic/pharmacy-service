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
           /*Appointment appointment = new Appointment
           {
               AppointmentType = AppointmentType.operation,
               Date = DateTime.Now,
               Doctor = DoctorRepository.Instance.GetById("1313"),
               Emergent = false,
               Room = RoomRepository.Instance.GetById("soba1"),
               Patient = PatientRepository.Instance.GetById("2456"),
               StartTime = "03:00AM",
               FinishTime = "04:00AM",
               IdAppointment = "2",
           };
           AppointmentRepository.Instance.Create(appointment);*/
        
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
