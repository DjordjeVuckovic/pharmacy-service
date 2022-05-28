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
            allergensLabel.Content = patient.Name + " " + patient.Surname + "'s Allergens";
        }
        private void Button_Guests(object sender, RoutedEventArgs e)
        {
            new GuestsView().Show();
            Close();
        }
        private void Button_Accounts(object sender, RoutedEventArgs e)
        {
            new AccountsView().Show();
            Close();
        }
        private void Button_Appointments(object sender, RoutedEventArgs e)
        {
            new AppointmentsPickDate().Show();
            Close();
        }
        private void Button_Equipment(object sender, RoutedEventArgs e)
        {
            new EquipmentRequestsView().Show();
            Close();
        }
        private void Button_EmergencyExamination(object sender, RoutedEventArgs e)
        {
            new EmergencyExamination().Show();
            Close();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Hide();
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
            Hide();
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
            patientAllergensController.Delete(pa.PatientJMBG+"-"+pa.AllergenName);
            Update();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            new AccountsView().Show();
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
