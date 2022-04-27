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


namespace TechHealth.View.PatientView.View
{
    /// <summary>
    /// Interaction logic for PatientMainWindow.xaml
    /// </summary>
    public partial class AppointmentView : UserControl
    {
        private ObservableCollection<Appointment> apList;
        public ObservableCollection<Appointment> appointments
        {
            get => apList;
            set => apList = value;
        }


        public AppointmentView()
        {
            InitializeComponent();
            DataContext = this;
            apList = new ObservableCollection<Appointment>(AppointmentRepository.Instance.DictionaryValuesToList());
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            new AddAppointment().ShowDialog();
            UpdateView();
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (dataAppointment.SelectedIndex == -1)
            {
                MessageBox.Show("You must select appointment to update");
            }
            Appointment appointment = (Appointment)dataAppointment.SelectedItem;
            new UpdateAppointment(appointment).ShowDialog();
            UpdateView();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (dataAppointment.SelectedIndex == -1)
            {
                MessageBox.Show("You have to select an appointment before deleting it!");
            }
            else
            {
                Appointment selected = (Appointment)dataAppointment.SelectedItem;
                AppointmentRepository.Instance.Delete(selected.IdAppointment);
                appointments.Remove(selected);
                MessageBox.Show("You have successfully deleted an appointment");
            }
        }

        public void UpdateView()
        {
            appointments.Clear();
            foreach (var a in AppointmentRepository.Instance.GetAll().Values)
            {
                appointments.Add(a);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
