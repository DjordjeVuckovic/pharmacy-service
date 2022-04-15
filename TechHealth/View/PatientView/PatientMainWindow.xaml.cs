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


namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for PatientMainWindow.xaml
    /// </summary>
    public partial class PatientMainWindow : Window
    {
        private ObservableCollection<Appointment> appointments;
        private AppointmentController appointmentController = new AppointmentController();
        public PatientMainWindow()
        {
            InitializeComponent();
            appointments = new ObservableCollection<Appointment>(AppointmentRepository.Instance.GetAll().Values);
            lvAppointments.ItemsSource = appointments;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            new AddAppointment().ShowDialog();
            UpdateView();
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (lvAppointments.SelectedIndex == -1)
            {
                MessageBox.Show("You must select appointment to update");
            }
            Appointment appointment = (Appointment)lvAppointments.SelectedItems[0];
            new UpdateAppointment(appointment).ShowDialog();
            UpdateView();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (lvAppointments.SelectedIndex == -1)
            {
                MessageBox.Show("You have to select an appointment before deleting it!");
            }
            Appointment selected = (Appointment)lvAppointments.SelectedItems[0];
            appointmentController.Delete(selected.IdAppointment);
            appointments = new ObservableCollection<Appointment>(AppointmentRepository.Instance.GetAll().Values);
            lvAppointments.ItemsSource = appointments;
            MessageBox.Show("You have successfully deleted an appointment");
        }

        public void UpdateView()
        {
            appointments.Clear();
            foreach (var a in AppointmentRepository.Instance.GetAll().Values)
            {
                appointments.Add(a);
            }
        }
    }
}
