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
        private ObservableCollection<Allergen> allergens = new ObservableCollection<Allergen>();
        public AllergensView(Patient patient)
        {
            patient1 = patient;
            jmbg = patient.Jmbg;
            InitializeComponent();
            foreach (var m in MedicalRecordRepository.Instance.GetAll().Values)
            {
                if (m.Patient.Jmbg.Equals(patient.Jmbg))
                {
                    foreach (var a in m.Allergens)
                    {
                        if (m.Allergens.Contains(a))
                        {
                            allergens.Add(a);
                        }
                    }
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
        }
        public void Update()
        {
            allergens.Clear();
            foreach (var m in MedicalRecordRepository.Instance.GetAll().Values)
            {
                if (m.Patient.Jmbg.Equals(patient1.Jmbg))
                {
                    foreach (var a in m.Allergens)
                    {
                        if (m.Allergens.Contains(a))
                        {
                            allergens.Add(a);
                        }
                    }
                }
            }
        }
    }
}
