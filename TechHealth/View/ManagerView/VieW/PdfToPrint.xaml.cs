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
using System.Windows.Shapes;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for PdfToPrint.xaml
    /// </summary>
    public partial class PdfToPrint : Window
    {
        private BindingList<AppointmentGrade> surveys;
        public BindingList<AppointmentGrade> Surveys
        {
            get { return surveys; }
            set
            {
                surveys = value;
            }
        }
        private string startD;
        private string endD;

        public string StartD
        {
            get { return startD; }
            set
            {
                startD = value;
            }
        }

        public string EndD
        {
            get { return endD; }
            set
            {
                endD = value;
            }
        }
        public PdfToPrint(BindingList<AppointmentGrade> surveysList, string start, string end)
        {
            InitializeComponent();
            DataContext = this;

            startD = start;
            endD = end;
            surveys = surveysList;

        }
    }
}
