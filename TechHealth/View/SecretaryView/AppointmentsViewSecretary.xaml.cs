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

namespace TechHealth.View.SecretaryView
{
    public partial class AppointmentsViewSecretary : Window
    {
        private ObservableCollection<Appointment> examinations = new ObservableCollection<Appointment>();
        private AppointmentType type1;
        private DateTime date1;
        public AppointmentsViewSecretary(DateTime date, AppointmentType type)
        {
            InitializeComponent();
            type1 = type;
            date1 = date;
            foreach (var a in AppointmentRepository.Instance.GetAll().Values)
            {
                if (a.Date.Equals(date) && a.AppointmentType.Equals(type))
                {
                    examinations.Add(a);
                }
            }
            pickedDate.Content = date;
            examinationList.ItemsSource = examinations;
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            new AddAppointmentSecretary(type1).ShowDialog();
        }
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
        }
        private void Update()
        {
            foreach (var a in AppointmentRepository.Instance.GetAll().Values)
            {
                if (a.Date.Equals(date1) && a.AppointmentType.Equals(type1))
                {
                    examinations.Add(a);
                }
            }
            pickedDate.Content = date1;
            examinationList.ItemsSource = examinations;
        }
    }
}
