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
        public AppointmentsViewSecretary(DateTime date, AppointmentType type)
        {
            InitializeComponent();
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
    }
}
