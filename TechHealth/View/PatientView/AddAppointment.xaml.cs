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
using System.Windows.Shapes;
using TechHealth.Model;
using TechHealth.Controller;
using TechHealth.Repository;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        private Appointment appointment;
        private AppointmentController appointmentController = new AppointmentController();
        private List<Doctor> doctors;

        public AddAppointment()
        {

            InitializeComponent();
            doctors = DoctorRepository.Instance.DictionaryValuesToList();
            CbDoctor.ItemsSource = doctors;
        }

        public AppointmentType StringToType(string t)
        {
            switch (t)
            {
                case "Operation":
                    return AppointmentType.operation;
                default:
                    return AppointmentType.examination;
            }
        }


        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            appointment = new Appointment();

            appointment.Date = DateTime.Parse(Date.Text);
            appointment.StartTime = TxtTime.Text;
            appointment.AppointmentType = StringToType(CbType.Text);
            appointment.Doctor = doctors[CbDoctor.SelectedIndex]; //ovde je greska verovatno

            appointmentController.Create(appointment.Date, appointment.StartTime, appointment.AppointmentType, appointment.Doctor);

            this.Close();

        }
    }
}
