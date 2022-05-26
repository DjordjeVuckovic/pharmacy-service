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
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            PatientAllergens pa = new PatientAllergens();
            pa.PatientJMBG = jmbg1;
            pa.AllergenName = allergenName.Text;
            pa.AllergenDescription = allergenDescription.Text;
            patientAllergensController.Update(pa);
            this.Close();
            new AllergensView(PatientRepository.Instance.GetById(jmbg1)).Show();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            new AllergensView(PatientRepository.Instance.GetById(jmbg1)).Show();
        }
    }
}
