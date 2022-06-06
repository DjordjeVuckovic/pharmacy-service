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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for Note.xaml
    /// </summary>
    public partial class Note : Window
    {
        public Appointment Selected { get; set; }
        public Beleska Beleska { get; set; }

        public Note(Appointment termin, string patientId)
        {
            InitializeComponent();
            Beleska = new Beleska
            {
                selectedAppointment = termin,
                patient = PatientRepository.Instance.GetPatientbyId(patientId)
            };
            DataContext = this;
        }


        private void RadioButton_Checked_No(object sender, RoutedEventArgs e)
        {
        }

        private void RadioButton_Checked_Yes(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
          Beleska.noteId = Guid.NewGuid().ToString("N");
            Beleska.content = Sadrzaj.Text;
            Beleska.naslov = Naslov.Text;
            Beleska.patient = PatientRepository.Instance.GetById("2456");
            Beleska.selectedAppointment = Selected;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {

        }
    }
}
