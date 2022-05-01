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
        private MedicalRecordController medicalRecordController = new MedicalRecordController();
        private MedicalRecord medicalRecord = new MedicalRecord();
        private string jmbg1;
        public AddAllergen(string jmbg)
        {
            jmbg1 = jmbg;
            foreach (var m in MedicalRecordRepository.Instance.GetAll().Values)
            {
                if (m.Patient.Jmbg.Equals(jmbg1))
                {
                    medicalRecord = m;
                }
            }
            InitializeComponent();
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
            List<Allergen> lista = new List<Allergen>();
            lista = medicalRecord.Allergens;
            Allergen a = new Allergen();
            a.Id = allergenId.ToString();
            a.Name = allergenName.Text;
            a.Description = allergenDescription.Text;
            lista.Add(a);
            medicalRecordController.Update(medicalRecord.RecordId, medicalRecord.BloodType, medicalRecord.Patient, medicalRecord.Weight, medicalRecord.Height, medicalRecord.ChronicDiseases, lista, medicalRecord.ParentDiseases, medicalRecord.MartialStatus, medicalRecord.EmlpoymentData);
            this.Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
