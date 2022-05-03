using System.Windows;
using TechHealth.Controller;
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
