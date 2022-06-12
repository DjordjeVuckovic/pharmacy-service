using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TechHealth.Annotations;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.PatientView.ViewModel;

namespace TechHealth.View.PatientView.View
{
    public partial class AppointmentView : UserControl, INotifyPropertyChanged
    {
        private static AppointmentView _instance;
        private AppointmentController appController = new AppointmentController();
        private Appointment selected;
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand AddAppointmentCommand { get; set; }
        public RelayCommand UpdateAppointmentCommand { get; set; }
        public RelayCommand DeleteAppointmentCommand { get; set; }
        public RelayCommand SuggestAppointmentCommand { get; set; }
        private readonly AppointmentController appointmentController = new AppointmentController();
        public string PatientId { get; set; }
        public Doctor doctor;

        public Appointment GetSelected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Appointment> Appointment { get; set; }

        public static AppointmentView GetInstance()
        {
            return _instance;
        }

        public AppointmentView()
        {
            InitializeComponent();
            DataContext = this;
            _instance = this;
            Appointment = new ObservableCollection<Appointment>(appController.GetAllNotEvident());
            LoadDoctors();
            LoadRooms();
            AddAppointmentCommand = new RelayCommand(param => ExecuteAdd());
            DeleteAppointmentCommand = new RelayCommand(param => ExecuteDelete(), param => CanExecute1());
            UpdateAppointmentCommand = new RelayCommand(param => ExecuteUpdate(selected), param => CanExecute2());
            SuggestAppointmentCommand = new RelayCommand(param => ExecuteSuggest(), param => CanExecute3());
        }

        private bool CanExecute1()
        {
            return GetSelected != null;
        }

        private bool CanExecute3()
        {
            if (GetSelected == null)
            {
                return false;
            }
            return true;
        }

        private bool CanExecute2()
        {
            if (GetSelected == null)
            {
                return false;
            }
            return true;
        }

        private void LoadDoctors()
        {
            for (int i = 0; i < Appointment.Count; i++)
            {
                Appointment[i].Doctor = DoctorRepository.Instance.GetDoctorById(Appointment[i].Doctor.Jmbg);
            }
        }

        private void LoadRooms()
        {
            for (int i = 0; i < Appointment.Count; i++)
            {
                Appointment[i].Room = RoomRepository.Instance.GetRoombyId(Appointment[i].Room.RoomId);
            }
        }

        public void RefreshView()
        {
            Appointment.Clear();
            Appointment = new ObservableCollection<Appointment>(appointmentController.GetAllNotEvident());

        }

        private void ExecuteDelete()
        {
            if (dataAppointments.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an appointment that you want to delete!");
            }
            else
            {
                Appointment ap = (Appointment)dataAppointments.SelectedItem;
                AppointmentRepository.Instance.Delete(ap.IdAppointment);
                Appointment.Remove(ap);
                MessageBox.Show("You have successfully deleted selected appointment");
            }
                
        }

        private void ExecuteAdd()
        {
            new AddAppointment(Appointment).ShowDialog();
        }

        private void ExecuteUpdate(Appointment selected)
        {
            if(dataAppointments.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an appointment that you want to change");
            }
            else
            {
                UpdateAppointment updateap = new UpdateAppointment((Appointment)dataAppointments.SelectedItem);
                updateap.ShowDialog();
            }
        }

        private void ExecuteSuggest()
        {
            new SuggestAppointment(PatientId, Appointment).ShowDialog();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
 
    }
}