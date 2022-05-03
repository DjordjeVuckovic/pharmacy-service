using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Controller;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.SecretaryView
{

    public partial class AllergensView : Window
    {
        private string jmbg;
        private Patient patient1;
        private ObservableCollection<PatientAllergens> allergens = new ObservableCollection<PatientAllergens>();
        private PatientAllergensController patientAllergensController = new PatientAllergensController();
        public AllergensView(Patient patient)
        {
            patient1 = patient;
            jmbg = patient.Jmbg;
            InitializeComponent();
            foreach (var pa in PatientAllergensRepository.Instance.GetAll().Values)
            {
                if (pa.PatientJMBG.Equals(patient.Jmbg))
                {
                    allergens.Add(pa);
                }
            }
            allergenList.ItemsSource = allergens;
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            new AddAllergen(jmbg).ShowDialog();
            Update();
        }
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (allergenList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an allergen.");
                return;
            }
            PatientAllergens patientAllergens = (PatientAllergens)allergenList.SelectedItems[0];
            new UpdateAllergen(patientAllergens).ShowDialog();
            Update();
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (allergenList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an allergen.");
                return;
            }
            PatientAllergens pa = (PatientAllergens)allergenList.SelectedItems[0];
            patientAllergensController.Delete(pa.PatientJMBG + "-" + pa.AllergenName);
            Update();
        }
        public void Update()
        {
            allergens.Clear();
            foreach (var pa in PatientAllergensRepository.Instance.GetAll().Values)
            {
                if (pa.PatientJMBG.Equals(patient1.Jmbg))
                {
                    allergens.Add(pa);
                }
            }
        }
    }
}
