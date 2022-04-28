using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.DoctorView.CRUDAppointments;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.ViewModel
{
    
    public class ViewModelAppointment:ViewModelBase
    {
        private ObservableCollection<Appointment> _appointments;
        private  string doctorId;
        public RelayCommand NewExaminationCommand { get; set; }
        public RelayCommand NewSurgeryCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        private AppointmentController appointmentController;
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

        // public ObservableCollection<Appointment> Appointments =>
        //     _appointments ?? (_appointments =
        //         new ObservableCollection<Appointment>(AppointmentRepository.Instance.GetByDoctorId(DoctorId)));
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

        public ViewModelAppointment()
        {
            appointmentController = new AppointmentController();
            doctorId = LoginWindow.GetDoctorId();
            Appointments = new ObservableCollection<Appointment>(AppointmentRepository.Instance.GetByDoctorId(doctorId));
            NewExaminationCommand = new RelayCommand(param => Execute(),param => CanExecute());
            NewSurgeryCommand= new RelayCommand(param => Execute1(),param => CanExecute1());
            UpdateCommand= new RelayCommand(param => Execute2(),param => CanExecute2());
            DeleteCommand= new RelayCommand(param => Execute3(),param => CanExecute3());

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
            Appointments.Remove(SelectedItem);
            appointmentController.Delete(SelectedItem.IdAppointment);
            MessageBox.Show(@"You are successfully deleted an appointment");

        }
    }
    
    
}