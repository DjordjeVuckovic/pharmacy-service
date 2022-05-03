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
            InitializeComponent();
            DataContext = this;
            //selected = AppointmentRepository.Instance.GetById(newAppointment.IdAppointment);
            selected = newAppointment;

            doctors = DoctorRepository.Instance.GetAllToList();

            CbDoctor.ItemsSource = doctors;
            BlackoutDates();
            TxtTime.Text = selected.StartTime;
            Date.SelectedDate = selected.Date;

        }

        /*public string TypeToString(AppointmentType type)
        {
            switch (type)
            {
                case AppointmentType.examination:
                    return "Examination";
                default:
                    return "Operation";
            }
        }*/

        /*public AppointmentType StringToType(string s)
        {
            switch (s)
            {
                case "Examination":
                    return AppointmentType.examination;
                default:
                    return AppointmentType.operation;
            }
        }*/

        private void BlackoutDates()
        {
            CalendarDateRange d1 = new CalendarDateRange(DateTime.MinValue, selected.Date.AddDays(-4));
            CalendarDateRange d2 = new CalendarDateRange(selected.Date.AddDays(4), DateTime.MaxValue);
            Date.BlackoutDates.Add(d1);
            Date.BlackoutDates.Add(d2);
        }

        private bool ValidateDate()
        {
            return (Date.SelectedDate.Value > selected.StartTimeD.AddDays(4)) || (Date.SelectedDate.Value < selected.StartTimeD.AddDays(-4));
        }

        private bool Validate()
        {
            if (!ValidateDate())
            {
                MessageBox.Show("Moguce je pomeriti termin za maksimalo 3 dana unapred ili unazad!");
                return false;
            }
            return true; //fali jos validacija za sve ostalo
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            selected.Date = DateTime.Parse(Date.Text);
            selected.StartTime = TxtTime.Text;
            selected.AppointmentType = AppointmentType.examination;
            selected.Doctor = doctors[CbDoctor.SelectedIndex];

            if (!Validate())
            {
                return;
            }
            
            AppointmentRepository.Instance.Update(selected);
            //appointmentController.Update(selected.Date, selected.StartTime, selected.AppointmentType, selected.Doctor, selected.IdAppointment);
            Close();
        }


        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        


    }
}
