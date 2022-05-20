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
using TechHealth.Repository;
using TechHealth.Controller;
using System.Collections.ObjectModel;
using TechHealth.DTO;

namespace TechHealth.View.SecretaryView
{
    public partial class BookedAppointmentsForEmergency : Window
    {
        private AppointmentType type;
        private DateTime date;
        private AppointmentController appointmentController = new AppointmentController();
        private ObservableCollection<AppointmentsDTO> list = new ObservableCollection<AppointmentsDTO>();
        private string spec;
        private string name;
        private DoctorController doctorController = new DoctorController();
        private PatientController patientController = new PatientController();
        public BookedAppointmentsForEmergency(DateTime date, AppointmentType type)
        {
            InitializeComponent();
            this.type = type;
            this.date = date;
            if (type.Equals(AppointmentType.examination)){ pickedDate.Content = "Examinations "; }else{ pickedDate.Content = "Operations "; }
            pickedDate.Content += date.ToString("dd.MM.yyyy.");
            GenerateAppointments();
        }
        private void GenerateAppointments()
        {
            foreach (var a in AppointmentRepository.Instance.GetAll().Values)
            {
                if (a.Date.Equals(date) && a.AppointmentType.Equals(type))
                {
                    if (DateTime.Compare(DateTime.Parse(a.StartTimeD.ToString("HH:mm")), DateTime.Now) >= 0)
                    {
                        if (DateTime.Compare(DateTime.Parse(a.StartTimeD.ToString("HH:mm")), DateTime.Now.AddMinutes(30)) <= 0)
                        {
                            spec = doctorController.GetById(a.Doctor.Jmbg).FullSpecialization;
                            name = patientController.GetByPatientId(a.Patient.Jmbg).FullName;
                            AppointmentsDTO aDTO = new AppointmentsDTO(a.IdAppointment, a.StartTimeD, a.FinishTimeD, spec, name, a.Room.roomId);
                            list.Add(aDTO);
                        }
                    }
                }
            }
            examinationList.ItemsSource = list;
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Postpone(object sender, RoutedEventArgs e)
        {
        }
    }
}
