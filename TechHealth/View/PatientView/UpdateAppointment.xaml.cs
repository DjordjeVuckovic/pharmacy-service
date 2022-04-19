using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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
using MessageBox = System.Windows.MessageBox;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        private Appointment selected;
        private List<Doctor> doctors;
        private List<Appointment> appointments;

        private AppointmentController appointmentController = new AppointmentController();

        public UpdateAppointment(Appointment newAppointment)
        {
            
            selected = AppointmentRepository.Instance.GetById(newAppointment.IdAppointment);
            InitializeComponent();
            doctors = DoctorRepository.Instance.DictionaryValuesToList();
            appointments = AppointmentRepository.Instance.DictionaryValuesToList();
            


            CbDoctor.ItemsSource = doctors;
            KalendarDostupnaIzmena();
            this.DataContext = this;
            CbAppointment.ItemsSource = appointments;
            Date.SelectedDate = selected.Date;

        }


        /*public void CreateMyDateTimePicker()
        {
            // Create a new DateTimePicker control and initialize it.
            DateTimePicker dateTimePicker1 = new DateTimePicker();

            // Set the MinDate and MaxDate.
            dateTimePicker1.MinDate = new DateTime(1985, 6, 20);
            dateTimePicker1.MaxDate = DateTime.Today;

            // Set the CustomFormat string.
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            // Show the CheckBox and display the control as an up-down control. Skinuto sa neta
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.ShowUpDown = true;
        }*/

        private void KalendarDostupnaIzmena()
        {
            CalendarDateRange datemin = new CalendarDateRange(DateTime.MinValue, selected.Date.AddDays(-4));
            CalendarDateRange datemax = new CalendarDateRange(selected.Date.AddDays(4), DateTime.MaxValue);
            Date.BlackoutDates.Add(datemin);
            Date.BlackoutDates.Add(datemax);
        }

        bool ValidateDate()
        {
            return (Date.SelectedDate.Value > selected.Date.AddDays(2)) ||
                   (Date.SelectedDate.Value < selected.Date.AddDays(-3));
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

        private bool Validate() //fali validacija za ostala polja
        {
            if (ValidateDate())
            {
                MessageBox.Show("It is possible to change initial date of appointment by only 3 days");
                return false;
            }
            return true;
        }


        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            if (!Validate())
            {
                return;
            }
            selected.Date = DateTime.Parse(Date.Text);
            selected.AppointmentType = AppointmentType.examination;
            selected.Doctor = doctors[CbDoctor.SelectedIndex];

            
            AppointmentRepository.Instance.Update(selected);
            //appointmentController.Update(selected.Date, selected.StartTime, selected.AppointmentType, selected.Doctor, selected.IdAppointment);

            this.Close();
        }


            private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        


    }
}
