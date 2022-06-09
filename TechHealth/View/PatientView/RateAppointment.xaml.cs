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

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for RateAppointment.xaml
    /// </summary>
    public partial class RateAppointment : Window
    {
        public string DoctorName { get; set; }
        public AppointmentGrade AnketaLekara { get; set; }

        public RateAppointment(Appointment termin)
        {
            InitializeComponent();
            AnketaLekara = new AppointmentGrade
            {
                EvidentAppointment = termin
            };
            DataContext = this;
            DoctorName = termin.Doctor.FullName;
        }
        
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            AnketaLekara.Id = Guid.NewGuid().ToString("N"); //foreach za id 
            AnketaLekara.OcenaLekara = BasicRatingBar.Value;
            AnketaLekara.OcenaOsoblje = BasicRatingBarStaff.Value;
            AnketaLekara.UkupnaOcena = BasicRatingBarTotal.Value;     
            GradeRepository.Instance.Create(AnketaLekara);
            //AnketaLekara.EvidentAppointment.Graded = true;
            Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
