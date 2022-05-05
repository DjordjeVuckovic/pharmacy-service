using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TechHealth.Annotations;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.PatientView.ViewModel;

namespace TechHealth.View.PatientView.View
{
    public partial class AppointmentView : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Appointment> aplist;
        private Appointment selected;
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand AddAppointmentCommand { get; set; }
        public RelayCommand UpdateAppointmentCommand { get; set; }
        public RelayCommand DeleteAppointmentCommand { get; set; }
        public RelayCommand SuggestAppointmentCommand { get; set; }
        private Patient currentPatient;
        public string PatientId { get; set; }

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
        public ObservableCollection<Appointment> Appointment
        {
            get
            {
                return aplist;
            }
            set
            {
                aplist = value;
            }
        }

        public AppointmentView()
        {
            InitializeComponent();
            DataContext = this;
            aplist = new ObservableCollection<Appointment>(AppointmentRepository.Instance.GetAllToList());

            AddAppointmentCommand = new RelayCommand(param => ExecuteAdd());
            DeleteAppointmentCommand = new RelayCommand(param => ExecuteDelete());
            UpdateAppointmentCommand = new RelayCommand(param => ExecuteUpdate(selected));
            SuggestAppointmentCommand = new RelayCommand(param => ExecuteSuggest());

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

        private bool CanExecute()
        {
            if (selected == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteAdd()
        {
            new AddAppointment(PatientId,aplist).ShowDialog();
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
            new SuggestAppointment(PatientId, aplist).ShowDialog();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}