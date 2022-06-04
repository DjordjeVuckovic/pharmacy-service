using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TechHealth.Controller;
using TechHealth.Model;

namespace TechHealth.DoctorView.GeneratePdf
{
    public partial class PdfForPateintCare : Window
    {
        public ObservableCollection<Anamnesis> AnamnesisViewModel { get; set; }
        private readonly AnamnesisController anamnesisController = new AnamnesisController();
        private readonly MedicalRecordController medicalRecordController = new MedicalRecordController();
        public PdfForPateintCare(Patient patient, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            DataContext = this;
            BindData(patient, startDate, endDate);
            DataGridAnamnesis.ItemsSource = AnamnesisViewModel;
            if (AnamnesisViewModel.Count == 0)
                MessageBox.Show("Medical reports for that period  dont exist.");
            else
                InitiatePdfSave();
        }
        private void InitiatePdfSave()
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(print, "inovice");
                MessageBox.Show("Your are successfully created report");
            }

        }
        private void BindData(Patient patient, DateTime startDate, DateTime endDate)
        {
            MedicalRecord medicalRecord = medicalRecordController.GetByPatientId(patient.Jmbg);
            AnamnesisViewModel = new ObservableCollection<Anamnesis>(anamnesisController.GetAllAnamnesisByDate(patient.Jmbg, startDate, endDate));
            LabelPatientName.Content = "Patient: " + patient.FullName;
            LabelBirthDate.Content = "Birthday: " + patient.Birthday;
            LabelGender.Content = "Gender: " + medicalRecord.GenderToString();
            LabelBlood.Content = "Bloodtype: " + medicalRecord.BloodTypeToString();
            LabelDateReport.Content = "Report for period: " + startDate.ToString("d") + " - " + endDate.ToString("d");
        }
    }
}