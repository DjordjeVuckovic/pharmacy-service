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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechHealth.Controller;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.PatientView.View
{
    /// <summary>
    /// Interaction logic for MedicalRecordView.xaml
    /// </summary>
    public partial class MedicalRecordView : UserControl
    {
        private Patient SelectedPatient { get; set; }
        private MedicalRecordController medicalRecordController = new MedicalRecordController();
        public string LabelName { get; set; }
        public string LabelSurName { get; set; }
        public string LabelFullName { get; set; }
        public string LabelBirth { get; set; }
        public string LabelId { get; set; }
        public string LabelLbo { get; set; }
        public string LabelGender { get; set; }
        public string LabelPhone { get; set; }
        public string LabelEmail { get; set; }
        public string LabelAddress { get; set; }
        public string LabelOur { get; set; }
        public string LabelProfession { get; set; }
        public string LabelWork { get; set; }
        public string LabelJob { get; set; }
        public string LabelMartialStatus { get; set; }
        public string LabelWeight { get; set; }
        public string LabelHeight { get; set; }
        public string LabelBloodType { get; set; }
        public string LabelHronical { get; set; }
        public string LabelAllergens { get; set; }

        public MedicalRecord MedicalRecord { get; set; }

        public MedicalRecordView()
        {
            InitializeComponent();
            DataContext = this;

            SelectedPatient = PatientRepository.Instance.GetPatientbyId("2456");
            LabelFullName = SelectedPatient.FullName;
            MedicalRecord = medicalRecordController.GetByPatientId("2456");
            LabelBirth = "Birthday:  " + SelectedPatient.Birthday.ToShortDateString();
            LabelEmail = "Email:  " + SelectedPatient.Email;
            LabelPhone = "Phone:  " + SelectedPatient.Phone;
            LabelId = "Jmbg:  " + SelectedPatient.Jmbg;
            LabelGender = "Gender:  " + MedicalRecord.GenderToString();
            LabelLbo = "Lbo:  " + SelectedPatient.Lbo;
            LabelAddress = "Address: " + SelectedPatient.Address.Street + "," + SelectedPatient.Address.StreetNumber + "," + SelectedPatient.Address.City + "," + SelectedPatient.Address.Postcode + "," + SelectedPatient.Address.Country;
            LabelMartialStatus = "Martial Status: " + MedicalRecord.MartialStatus;
            LabelOur = "Our:  " + MedicalRecord.EmlpoymentData.Our;
            LabelProfession = "Profession:  " + MedicalRecord.EmlpoymentData.Profession;
            LabelWork = "Workplace:  " + MedicalRecord.EmlpoymentData.Workplace;
            LabelJob = "Job:  " + MedicalRecord.EmlpoymentData.Job;
            LabelWeight = "Weight:  " + MedicalRecord.Weight;
            LabelHeight = "Height: " + MedicalRecord.Height;
            LabelBloodType = "BloodType:  " + MedicalRecord.BloodTypeToString();
            LabelHronical = "Chronic diseases:  " + MedicalRecord.ChronicDiseases;
            LabelAllergens = "Allergens:  " + GetAllergens();
            LabelName = "Name:  " + SelectedPatient.Name;
            LabelSurName = "Surname:  " + SelectedPatient.Surname;

        }

        private string GetAllergens()
        {
            string ret = "";
            foreach (var alg in PatientAllergensRepository.Instance.PatientAllergensList(SelectedPatient.Jmbg))
            {
                ret += alg;
                ret += ";";
            }

            return ret;
        }
    }
}
