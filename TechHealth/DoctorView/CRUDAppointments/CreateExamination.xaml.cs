using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.DoctorView.MedicalHistory;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.ViewModel;
using TechHealth.Model;
using TechHealth.Repository;
using MessageBox = System.Windows.MessageBox;

namespace TechHealth.DoctorView.CRUDAppointments
{
    /// <summary>
    /// Interaction logic for CreateExamination.xaml
    /// </summary>
    public partial class CreateExamination : Window
    {
        // private Doctor doctor;
        // private List<Patient> patients;
        // private List<Room> rooms;
        // private string doctorId;
        // private ObservableCollection<Appointment> Appointments { get; set; }
        public CreateExamination()
        {
            InitializeComponent();
            // DataContext = this;
            // doctor = DoctorRepository.Instance.GetDoctorbyId(doctorId);
            // patients = PatientRepository.Instance.GetAllToList();
            // rooms = RoomRepository.Instance.GetAllToList();
            // Appointments = observableCollection;
            //
            // DoctorTxt.Text = doctor.FullSpecialization;
            // PatentCombo.ItemsSource = patients;
            // RoomCombo.ItemsSource = rooms;
            // this.doctorId = doctorId;
        }
    }
}
