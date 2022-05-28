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
    public partial class AppointmentsViewSecretary : Window
    {
        //private ObservableCollection<Appointment> examinations = new ObservableCollection<Appointment>();
        private AppointmentType type1;
        private DateTime date1;
        private AppointmentController appointmentController = new AppointmentController();
        private ObservableCollection<AppointmentsDTO> list = new ObservableCollection<AppointmentsDTO>();
        private string spec;
        private string name;
        private DoctorController doctorController = new DoctorController();
        private PatientController patientController = new PatientController();
        private List<Appointment> tempList = AppointmentRepository.Instance.GetAllToList();
        public AppointmentsViewSecretary(DateTime date, AppointmentType type)
        {
            InitializeComponent();
            type1 = type;
            date1 = date;
            if (type.Equals(AppointmentType.examination))
            {
                pickedDate.Content = "Examinations ";
            }
            else
            {
                pickedDate.Content = "Operations ";
            }
            tempList.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
            foreach (var a in tempList)
            {
                if (a.Date.Equals(date) && a.AppointmentType.Equals(type))
                {
                    spec = doctorController.GetById(a.Doctor.Jmbg).FullSpecialization;
                    name = patientController.GetByPatientId(a.Patient.Jmbg).FullName;
                    AppointmentsDTO aDTO = new AppointmentsDTO(a.IdAppointment, a.StartTime, a.FinishTime, spec, name, a.Room.roomId);
                    list.Add(aDTO);
                }
            }
            pickedDate.Content += date.ToString("dd.MM.yyyy.");
            examinationList.ItemsSource = list;
        }
        private void Button_Guests(object sender, RoutedEventArgs e)
        {
            new GuestsView().Show();
            Close();
        }
        private void Button_Accounts(object sender, RoutedEventArgs e)
        {
            new AccountsView().Show();
            Close();
        }
        private void Button_Appointments(object sender, RoutedEventArgs e)
        {
            new AppointmentsPickDate().Show();
            Close();
        }
        private void Button_Equipment(object sender, RoutedEventArgs e)
        {
            new EquipmentRequestsView().Show();
            Close();
        }
        private void Button_EmergencyExamination(object sender, RoutedEventArgs e)
        {
            new EmergencyExamination().Show();
            Close();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            new AddAppointmentSecretary(date1, type1).Show();
            Close();
            Update();
        }
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (examinationList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an appointment.");
                return;
            }
            AppointmentsDTO a = (AppointmentsDTO)examinationList.SelectedItems[0];
            new UpdateAppointmentSecretary(AppointmentRepository.Instance.GetById(a.idAppointment)).Show();
            Close();
            Update();
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (examinationList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an appointment.");
                return;
            }
            AppointmentsDTO a = (AppointmentsDTO)examinationList.SelectedItems[0];
            appointmentController.Delete(a.idAppointment);
            Update();
        }
        private void Update()
        {
            list.Clear();
            foreach (var a in AppointmentRepository.Instance.GetAll().Values)
            {
                if (a.Date.Equals(date1) && a.AppointmentType.Equals(type1))
                {
                    spec = doctorController.GetById(a.Doctor.Jmbg).FullSpecialization;
                    name = patientController.GetByPatientId(a.Patient.Jmbg).FullName;
                    AppointmentsDTO aDTO = new AppointmentsDTO(a.IdAppointment, a.StartTime, a.FinishTime, spec, name, a.Room.roomId);
                    list.Add(aDTO);
                }
            }
            if (type1.Equals(AppointmentType.examination))
            {
                pickedDate.Content = "Examinations ";
            }
            else
            {
                pickedDate.Content = "Operations ";
            }
            pickedDate.Content += date1.ToString("dd.MM.yyyy.");
            examinationList.ItemsSource = list;
        }
    }
}
