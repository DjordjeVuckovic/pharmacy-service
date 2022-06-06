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
using TechHealth.View.PatientView.View;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        private Appointment selected;
        private List<Doctor> doctors;
        private Patient patient;
        public string PatientFullName { get; set; }
        private AppointmentController appointmentController = new AppointmentController();
        private DoctorController doctorController = new DoctorController();
        private List<ComboBoxGeneric<Doctor>> doctorComboBox = new List<ComboBoxGeneric<Doctor>>();
        public int DoctorIndex { get; set; }
        public string StartDate { get; set; }
        public Doctor DoctorData { get; set; }

        public UpdateAppointment(Appointment newAppointment)
        {
            InitializeComponent();
            DataContext = this;
            selected = newAppointment;
            patient = PatientRepository.Instance.GetPatientbyId("2456");
            PatientFullName = patient.FullName;
            doctors = DoctorRepository.Instance.GetAllToList();
            FillComboData();
            FillIndex();
            DoctorData = selected.Doctor;
            CbDoctor.ItemsSource = doctors;
            Date.SelectedDate = selected.Date;
            StartDate = selected.StartTime.ToString("t");
            BlackoutDates();
            

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
            return (Date.SelectedDate.Value > selected.StartTime.AddDays(4)) || (Date.SelectedDate.Value < selected.StartTime.AddDays(-4));
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
            
        }


        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FillComboData()
        {

            foreach (var d in DoctorRepository.Instance.GetAllToList())
            {
                doctorComboBox.Add(new ComboBoxGeneric<Doctor>() { DisplayText = d.Name + " " + d.Surname, Entity = d });
            }
        }

        private void FillIndex()
        {
            int cnt = 0;
            foreach (var combo in doctorComboBox)
            {
                if (combo.Entity.Jmbg.Equals(selected.Doctor.Jmbg))
                {
                    break;
                }

                cnt++;
            }

            DoctorIndex = cnt;

        }




    }
}
