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
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (allergenList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an allergen.");
                return;
            }
            PatientAllergens pa = (PatientAllergens)allergenList.SelectedItems[0];
            patientAllergensController.Delete(pa.PatientJMBG+"-"+pa.AllergenName);
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
