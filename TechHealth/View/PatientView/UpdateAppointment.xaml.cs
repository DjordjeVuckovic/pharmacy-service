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
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        private Appointment selected;
        private List<Doctor> doctors;
        
        private AppointmentController appointmentController = new AppointmentController();

        public UpdateAppointment(Appointment newAppointment)
        {
            
            selected = AppointmentRepository.Instance.GetById(newAppointment.IdAppointment);
            InitializeComponent();
            doctors = DoctorRepository.Instance.DictionaryValuesToList();
            this.DataContext = this;


            CbDoctor.ItemsSource = doctors;
            TxtTime.Text = selected.StartTime;
            CbType.Text = TypeToString(selected.AppointmentType);
            Date.SelectedDate = selected.Date;

        }

        public string TypeToString(AppointmentType type)
        {
            switch (type)
            {
                case AppointmentType.examination:
                    return "Examination";
                default:
                    return "Operation";
            }
        }

        public AppointmentType StringToType(string s)
        {
            switch (s)
            {
                case "Examination":
                    return AppointmentType.examination;
                default:
                    return AppointmentType.operation;
            }
        }


        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            selected.Date = DateTime.Parse(Date.Text);
            selected.StartTime = TxtTime.Text;
            selected.AppointmentType = StringToType(CbType.Text);
            selected.Doctor = doctors[CbDoctor.SelectedIndex];

            appointmentController.Update(selected.Date, selected.StartTime, selected.AppointmentType, selected.Doctor);

            this.Close();
        }


            private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        


    }
}
