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
using TechHealth.Core;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        private Appointment selected;
        private List<Doctor> doctors;
        private Doctor doctor;
        private Room room;
        private Patient patient;
        public string PatientFullName { get; set; }
        private AppointmentController appointmentController = new AppointmentController();
        private PatientController patientController = new PatientController();
        private DoctorController doctorController = new DoctorController();
        public int DoctorIndex { get; set; }
        public DateTime Date { get; set; }
        public string StartDate { get; set; }

        public RelayCommand FinishCommand { get; set; }

        public UpdateAppointment(Appointment newAppointment)
        {
            InitializeComponent();
            DataContext = this;
            selected = newAppointment;
            patient = selected.Patient;
            room = selected.Room;
            PatientFullName = patient.FullName;
            Picker.DisplayDateStart = DateTime.Now;
            Picker.SelectedDate = selected.Date;
            Timepicker1.SelectedTime = selected.StartTime;
            doctors = DoctorRepository.Instance.GetAllToList();
            CbDoctor.ItemsSource = doctors;
            CbDoctor.SelectedItem = selected.Doctor;
            BlackoutDates();
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());

        }

        private bool CanExecute()
        {
            if (StartDate != null && CbDoctor.SelectedItem != null)
            {
                return true;
            }
            return false;
        }

        private void Execute()
        {
            selected.Date = Date;
            selected.StartTime = DateTime.Parse(StartDate);
            selected.Doctor = doctors[CbDoctor.SelectedIndex];
            AppointmentRepository.Instance.Update(selected);
            Close();
        }

        private void BlackoutDates()
        {
            CalendarDateRange d1 = new CalendarDateRange(DateTime.MinValue, selected.Date.AddDays(-4));
            CalendarDateRange d2 = new CalendarDateRange(selected.Date.AddDays(4), DateTime.MaxValue);
            Picker.BlackoutDates.Add(d1);
            Picker.BlackoutDates.Add(d2);
        }

        /*private bool ValidateDate()
        {
            return (Picker.SelectedDate.Value > selected.StartTime.AddDays(4)) || (Picker.SelectedDate.Value < selected.StartTime.AddDays(-4));
        }*/


        /*private bool Validate()
        {
            if (!ValidateDate())
            {
                MessageBox.Show("Moguce je pomeriti termin za maksimalo 3 dana unapred ili unazad!");
                return false;
            }
            return true; //fali jos validacija za sve ostalo
        }*/



        /*private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            selected.Date = DateTime.Parse(Date.Text);
            selected.StartTime = DateTime.Parse(TxtTime.Text);
            selected.AppointmentType = AppointmentType.examination;
            selected.Doctor = DoctorData;

            if (!Validate())
            {
                return;
            }
            
            AppointmentRepository.Instance.Update(selected);
            //appointmentController.Update(selected.Date, selected.StartTime, selected.AppointmentType, selected.Doctor, selected.IdAppointment);
            Close();
        }*/


        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
