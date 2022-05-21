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
using TechHealth.View.PatientView.ViewModel;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for PatientMainWindow.xaml
    /// </summary>
    public partial class PatientMainWindow : Window
    {
        private static string _patientId;

        public PatientMainWindow()
        {
            InitializeComponent();
            /*DataContext = MainViewModel.GetInstance(patientJmbg);
            _patientId = patientJmbg;*/
        }
        /*public static string GetPatientId()
        {
            return _patientId;
        }*/
    }
}
