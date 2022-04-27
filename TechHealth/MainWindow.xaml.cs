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
using Scar.Common.WPF.Controls;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView;
using TechHealth.View.ManagerView.CRUDRooms;
using TechHealth.View.PatientView;

namespace TechHealth
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new PatientMainWindow().Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new ManagerMainWindow().Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            InitializeComponent();
        }

        private void initMed()
        {
             /*InitializeComponent();
            RandomGenerator randomGenerator = new RandomGenerator();
            Substance substance = new Substance
            {
                SubstanceId = "113",
                SubstanceName = "ibuprofen"
            };
            Substance substance1 = new Substance
            {
                SubstanceId = "114",
                SubstanceName = "laktoza"
            };
            Substance substance2 = new Substance
            {
                SubstanceId = "115",
                SubstanceName = "calcijum"
            };
            Substance substance3 = new Substance
            {
                SubstanceId = "116",
                SubstanceName = "paracetamol"
            };
            List<Substance> substances = new List<Substance>();
            substances.Add(substance);
            substances.Add(substance1);
            substances.Add(substance2);
            Medicine medicine = new Medicine
            {
                MedicineId = randomGenerator.GenerateRandHash(),
                Composition = substances,
                Quantity = 50,
                Units = "sirup",
                SideEffects = "/",
                MainSubstance = substance,
                HarmfulRate = 0,
                Price = 300,
                MedicineName = "Brufen",
                Allergens = "/",
                Approved = true
            };
            List<Substance> substances1 = new List<Substance>();
            substances1.Add(substance3);
            substances1.Add(substance2);
            Medicine medicine1 = new Medicine
            {
                MedicineId = randomGenerator.GenerateRandHash(),
                Composition = substances1,
                Quantity = 70,
                Units = "pill",
                SideEffects = "/",
                MainSubstance = substance3,
                HarmfulRate = 0,
                Price = 100,
                MedicineName = "Paracetamol Uno",
                Allergens = "/",
                Approved = false
            };
            MedicineRepository.Instance.Create(medicine);
            MedicineRepository.Instance.Create(medicine1);*/
             
             /*RandomGenerator randomGenerator = new RandomGenerator();
            Patient patient = PatientRepository.Instance.GetById("2456");
            Patient patient1 = PatientRepository.Instance.GetById("13456");
            Allergen allergen1 = new Allergen
            {
                Id = "1",
                Name = "dust",
                Description = "Fine powdery material such as dry earth or pollen that can be blown about in the air."
            };
            Allergen allergen2 = new Allergen
            {
                Id = "2",
                Name = "animal dander",
                Description = "/"
            };
            Allergen allergen3 = new Allergen
            {
                Id = "3",
                Name = "ibuprofen",
                Description = "/"
            };
            Allergen allergen4 = new Allergen
            {
                Id = "4",
                Name = "paracetamol",
                Description = "/"
            };
            List<Allergen> allergens = new List<Allergen>();
            allergens.Add(allergen1);
            allergens.Add(allergen2);
            List<Allergen> allergens1 = new List<Allergen>();
            allergens1.Add(allergen3);
            allergens1.Add(allergen4);
            EmlpoymentData emlpoymentData = new EmlpoymentData
            {
                Our = "1345",
                Profession = "moler",
                Workplace = "Duga",
                Job = "kasir"
            };
            MedicalRecord medicalRecord = new MedicalRecord
            {
                RecordId = randomGenerator.GenerateRandHash(),
                BloodType = Bloodtype.Ap,
                Patient = patient,
                Weight = "80 kg",
                Height = "170 cm",
                ChronicDiseases = "asma",
                Allergens = allergens1,
                ParentDiseases = "plucna maramica",
                EmlpoymentData = emlpoymentData,
                Gender = Gender.Male
            };
            EmlpoymentData emlpoymentData1 = new EmlpoymentData
            {
                Our = "1675",
                Profession = "Inzinjer elektrotehnike",
                Workplace = "FTN",
                Job = "asistent"
            };
            MedicalRecord medicalRecord1 = new MedicalRecord
            {
                RecordId = randomGenerator.GenerateRandHash(),
                BloodType = Bloodtype.Op,
                Patient = patient1,
                Weight = "80 kg",
                Height = "170 cm",
                ChronicDiseases = "asma",
                Allergens = allergens,
                ParentDiseases = "plucna maramica",
                EmlpoymentData = emlpoymentData1,
                Gender = Gender.Male
            };
            MedicalRecordRepository.Instance.Create(medicalRecord1);
            AllergensRepository.Instance.Create(allergen3);
            AllergensRepository.Instance.Create(allergen4);*/

        }
    }
}