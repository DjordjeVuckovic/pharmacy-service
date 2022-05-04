using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Controller;
using TechHealth.DTO;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.RecommendationService;
using TechHealth.View.PatientView.View;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for SuggestAppointment.xaml
    /// </summary>
    /// 

    /*class TerminZaPreporuku
    {
        private List<Doctor> doctors;
        private DateTime time;
        public TerminZaPreporuku() { }
        public TerminZaPreporuku(DateTime time)
        {
            this.Time = time;
            this.Doctors = DoctorRepository.Instance.GetAllToList();
        }
        public List<Doctor> Doctors { get; set; }
        public DateTime Time { get; set; }
    }*/


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
            suggestedAppointmentList = new List<Appointment>();
            suggestedApp = new List<SuggestAppointment>();
            doctors = DoctorRepository.Instance.GetAllToList();
            CbDoctor.ItemsSource = doctors;
            DataContext = this;
        }

        private void Preporuka()
        {
            if (radioDoc.IsChecked == true)
            {
                RecommendedAppointmentDTO recAppDTO = new RecommendedAppointmentDTO
                    (PatientRecommendType.DoctorRecommendation, doctors[CbDoctor.SelectedIndex].Jmbg, (DateTime)StartDate.SelectedDate, (DateTime)EndDate.SelectedDate,
                    LoginWindow.GetPatientId());
                RecommendedAppointmentController recController = new RecommendedAppointmentController();
                suggestedAppointmentList = recController.GetRecommendedAppointments(recAppDTO);
            }
            else
            {
                RecommendedAppointmentDTO recAppDTO = new RecommendedAppointmentDTO(
                    PatientRecommendType.DoctorRecommendation, null,
                    (DateTime)StartDate.SelectedDate, (DateTime)EndDate.SelectedDate,
                    LoginWindow.GetPatientId());
                RecommendedAppointmentController recController = new RecommendedAppointmentController();
                suggestedAppointmentList = recController.GetRecommendedAppointments(recAppDTO);
            }
        }

        public Patient Patient { get => patient; set => patient = value; }
        public List<Doctor> Doctors { get => doctors; set => doctors = value; }


        private void CheckedDoctor(object sender, RoutedEventArgs e)
        {
            
        }

        private void CheckedDate(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            Preporuka();
            SuggestedAppointmentsView preporuceni = new SuggestedAppointmentsView();
            preporuceni.addTermini(suggestedAppointmentList);
        }


    }
}
