using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TechHealth.Controller;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for SuggestAppointment.xaml
    /// </summary>
    /// 

    class SuggestedAppointment
    {
        public SuggestedAppointment() { }
        public SuggestedAppointment(DateTime time)
        {
            Time = time;
            Doctors = DoctorRepository.Instance.GetAllToList();
        }
        public List<Doctor> Doctors { get; set; }
        public DateTime Time { get; set; } 
    }


    public partial class SuggestAppointment : Window //da li ovde treba user control
    {
        Patient patient;
        List<Appointment> apList;
        List<Appointment> suggestedAppointmentList;
        List<SuggestAppointment> suggestedApp;
        //AppointmentController controller = new AppointmentController();
        List<Doctor> doctors;
        
        private ObservableCollection<Appointment> apt;
        private DateTime time;

        public SuggestAppointment(Patient p)
        {
            InitializeComponent();
            patient = p;
            apList = AppointmentRepository.Instance.GetAllToList();
            DataContext = this;
        }







        private void CheckedDoctor(object sender, RoutedEventArgs e)
        {
            Date.IsEnabled = false;
        }

        private void CheckedDate(object sender, RoutedEventArgs e)
        {
            CbDoctor.IsEnabled = false;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
