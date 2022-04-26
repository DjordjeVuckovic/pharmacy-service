using System;
using System.ComponentModel;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.ViewModel
{
    public class MedicalRecordViewModel:ViewModelBase
    {
        private Patient selectedItemPatient;
        private string name;
        private MedicalRecord medicalRecord;
        public String LabelName { get; set; }
        public String LabelSurName { get; set; }
        public String LabelFullName { get; set; }
        public String LabelBirth { get; set; }
        public String LabelId { get; set; }
        public String LabelLbo { get; set; }
        public String LabelGender { get; set; }
        public String LabelPhone { get; set; }
        public String LabelEmail { get; set; }
        public String LabelAddress { get; set; }
        public String LabelOur { get; set; }
        public String LabelProfession { get; set; }
        public String LabelWork { get; set; }
        public String LabelJob { get; set; }
        public String LabelMartialStatus { get; set; }
        public String LabelWeight { get; set; }
        public String LabelHeight { get; set; }
        public String LabelBloodType { get; set; }
        public String LabelHronical { get; set; }
        public String LabelAllergens { get; set; }
        public String LabelParentDiseases { get; set; }

        public MedicalRecord MedicalRecord
        {
            get => medicalRecord;
            set
            {
                medicalRecord = value;
                OnPropertyChanged(nameof(MedicalRecord));
            }
        }


        public Patient SelectedItemPatient
        {
            get => selectedItemPatient;
            set
            {
                selectedItemPatient = value;
                OnPropertyChanged(nameof(SelectedItemPatient));
            }
        }

        public MedicalRecordViewModel(Patient selectedItem)
        {
            SelectedItemPatient = selectedItem;
            LabelFullName = selectedItem.FullName;
            medicalRecord = MedicalRecordRepository.Instance.GetByPatientId(selectedItem.Jmbg);
            MedicalRecord = medicalRecord;
            LabelBirth ="Birthday:  " + SelectedItemPatient.Birthday.ToShortDateString();
            LabelEmail = "Email:  " + SelectedItemPatient.Email;
            LabelPhone = "Phone:  " + SelectedItemPatient.Phone;
            LabelId = "Jmbg:  " + SelectedItemPatient.Jmbg;
            LabelGender = "Gender:  " + MedicalRecord.GenderToString();
            LabelLbo = "Lbo:  " + SelectedItemPatient.Lbo;
            LabelAddress = "Address: " + SelectedItemPatient.Address.Street + "," + SelectedItemPatient.Address.StreetNumber + "," + SelectedItemPatient.Address.City + "," + SelectedItemPatient.Address.Postcode + "," + SelectedItemPatient.Address.Country;
            LabelMartialStatus = "Martial Status: " + MedicalRecord.MartialStatus;
            LabelOur = "Our:  " + MedicalRecord.EmlpoymentData.Our;
            LabelProfession = "Profession:  " + MedicalRecord.EmlpoymentData.Profession;
            LabelWork= "Workplace:  " + MedicalRecord.EmlpoymentData.Workplace;
            LabelJob = "Job:  " + MedicalRecord.EmlpoymentData.Job;
            LabelWeight = "Weight:  " + MedicalRecord.Weight;
            LabelHeight = "Height: " + MedicalRecord.Height;
            LabelBloodType = "BloodType:  " + MedicalRecord.BloodTypeToString();
            LabelHronical = "Chronic diseases:  " + MedicalRecord.ChronicDiseases;
            LabelAllergens = "Allergens:  " + GetAllergens();
            LabelParentDiseases = "ParentDiseases:  " + MedicalRecord.ParentDiseases;
            LabelName = "Name:  " + SelectedItemPatient.Name;
            LabelSurName = "Surname:  " + SelectedItemPatient.Surname;



        }

        private string GetAllergens()
        {
            string ret = "";
            foreach (var alg in MedicalRecord.Allergens)
            {
                ret += alg.Name;
                ret += ";";
            }

            return ret;
        }
    }
}