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
    public partial class AddAllergen : Window
    {
        private AllergenController allergenController = new AllergenController();
        private PatientAllergensController patientAllergensController = new PatientAllergensController();
        private string jmbg1;
        public AddAllergen(string jmbg)
        {
            jmbg1 = jmbg;
            InitializeComponent();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            int allergenId = 1;
            foreach (var al in AllergensRepository.Instance.GetAll().Values)
            {
                if (allergenId != Int32.Parse(al.Id))
                {
                    break;
                }
                else
                {
                    allergenId++;
                }
            }
            //allergenController.Create(allergenId.ToString(), allergenName.Text, allergenDescription.Text);
            PatientAllergens pa = new PatientAllergens();
            pa.PatientJMBG = jmbg1;
            pa.AllergenName = allergenName.Text;
            pa.AllergenDescription = allergenDescription.Text;
            patientAllergensController.Create(pa);
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
