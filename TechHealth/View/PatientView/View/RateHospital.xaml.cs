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

namespace TechHealth.View.PatientView.View
{
    /// <summary>
    /// Interaction logic for RateHospital.xaml
    /// </summary>
    public partial class RateHospital : UserControl
    {
        //public HospitalGrade AnketaBolnica { get; set; }
        public RateHospital()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HospitalGrade anketaBolnica = new HospitalGrade
            {
                Id = Guid.NewGuid().ToString("N"),
                OcenaCistoca = BasicRatingBarClean.Value,
                OcenaDostupnost = BasicRatingBarAvailable.Value,
                OcenaLakoca = BasicRatingBarEasy.Value,
                OcenaOprema =  BasicRatingBarEq.Value
            };
        }
    }
}
