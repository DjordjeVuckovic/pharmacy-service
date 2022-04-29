using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.DoctorView.CRUDAppointments;
using TechHealth.DoctorView.View;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;

namespace TechHealth.DoctorView.ViewModel
{
    
    public class ViewModelAppointment:ViewModelBase
    {
        private ObservableCollection<Appointment> _appointments;
        private  string doctorId;
        private static ViewModelAppointment _instance;
        public RelayCommand NewExaminationCommand { get; set; }
        public RelayCommand NewSurgeryCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        private readonly  AppointmentController appointmentController = new AppointmentController();
        public string DoctorId
        {
            get => doctorId;
            set
            {
                doctorId = value;
                OnPropertyChanged(nameof(DoctorId));
            }
        }
        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set
            {
                _appointments = value;
                OnPropertyChanged(nameof(Appointments));
            }
            
        }
        private Appointment selectedItem;
        public Appointment SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public static ViewModelAppointment GetInstance()
        {
            return _instance;
        }
        public ViewModelAppointment()
        {
            _instance = this;
            doctorId = LoginWindow.GetDoctorId();
            Appointments = appointmentController.GetAllNotEvident(doctorId);
            NewExaminationCommand = new RelayCommand(param => Execute(),param => CanExecute());
            NewSurgeryCommand= new RelayCommand(param => Execute1(),param => CanExecute1());
            UpdateCommand= new RelayCommand(param => Execute2(),param => CanExecute2());
            DeleteCommand= new RelayCommand(param => Execute3(),param => CanExecute3());
            //RefreshView();

        }
        public void RefreshView()
        {
           var temp =  new ObservableCollection<Appointment>(appointmentController.GetByDoctorId(doctorId));
           Appointments.Clear();
           Appointments = appointmentController.GetAllNotEvident(doctorId);
        }
        private bool CanExecute()
        {
            
            return true;
        }

        private void Execute()
        {
            new CreateExamination(doctorId,Appointments).ShowDialog();
            
        }
        private bool CanExecute1()
        {

            return true;
        }

        private void Execute1()
        {
            new CreateSurgery(doctorId,Appointments).ShowDialog();
        }
        private bool CanExecute2()
        {
            if (SelectedItem == null )
            {
                return false;
            }

            return true;
        }

        private void Execute2()
        {
            new AppointmentsUpdate(SelectedItem).ShowDialog();
        }
        private bool CanExecute3()
        {
            if (SelectedItem == null )
            {
                return false;
            }

            return true;
        }

        private void Execute3()
        {
            appointmentController.Delete(SelectedItem.IdAppointment);
            Appointments.Remove(SelectedItem);
            RecordViewModel.GetInstance().RefreshView();
            MessageBox.Show(@"You are successfully deleted an appointment");

        }
    }
    
    
}