using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.PatientView.View
{
    /// <summary>
    /// Interaction logic for RateHospital.xaml
    /// </summary>
    public partial class RateHospital : UserControl
    {
        public HospitalGrade AnketaBolnica { get; set; }  //Ova funkcija mi da ocenu bolnice za jednog pacijenta, ne znam da li treba da napravim da moze da menja ocenu ili ne
        public RelayCommand RateHospitalCommand { get; set; }
        

        public RateHospital()
        {
            InitializeComponent();
            AnketaBolnica = new HospitalGrade
            {
                Patient = PatientRepository.Instance.GetPatientbyId("2456") //zakucamo za sad
            };
            RateHospitalCommand = new RelayCommand(param => ExecuteRate());
            
        }

        private void ExecuteRate()
        {
            AnketaBolnica.Id = Guid.NewGuid().ToString("N");
            AnketaBolnica.OcenaCistoca = BasicRatingBarClean.Value;
            AnketaBolnica.OcenaDostupnost = BasicRatingBarAvailable.Value;
            AnketaBolnica.OcenaLakoca = BasicRatingBarEasy.Value;
            AnketaBolnica.OcenaOprema = BasicRatingBarEq.Value;
            HospitalGradeRepository.Instance.Create(AnketaBolnica);
        }

        /*private bool CanExecuteRate()
        {
            return false;
        }*/


        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            AnketaBolnica.Id = Guid.NewGuid().ToString("N");
            //Patient.Id = Guid.NewGuid().ToString("N");
            AnketaBolnica.OcenaCistoca = BasicRatingBarClean.Value;
            AnketaBolnica.OcenaDostupnost = BasicRatingBarAvailable.Value;
            AnketaBolnica.OcenaLakoca = BasicRatingBarEasy.Value;
            AnketaBolnica.OcenaOprema = BasicRatingBarEq.Value;
            HospitalGradeRepository.Instance.Create(AnketaBolnica);    
        }*/
    }
}
