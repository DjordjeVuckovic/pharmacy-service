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
using TechHealth.Controller;
using TechHealth.Repository;
using TechHealth.Model;

namespace TechHealth.View.SecretaryView
{
    public partial class UpdateAllergen : Window
    {
        private AllergenController allergenController = new AllergenController();
        private PatientAllergensController patientAllergensController = new PatientAllergensController();
        private string jmbg1;
        public UpdateAllergen(PatientAllergens patientAllergens)
        {
            InitializeComponent();

            this.DataContext = this;

            allergenName.Text = patientAllergens.AllergenName;
            allergenDescription.Text = patientAllergens.AllergenDescription;
            jmbg1 = patientAllergens.PatientJMBG;
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            PatientAllergens pa = new PatientAllergens();
            pa.PatientJMBG = jmbg1;
            pa.AllergenName = allergenName.Text;
            pa.AllergenDescription = allergenDescription.Text;
            patientAllergensController.Update(pa);
            this.Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
