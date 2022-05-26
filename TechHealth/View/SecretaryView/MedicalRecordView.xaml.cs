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
using TechHealth.Controller;
using TechHealth.Repository;

namespace TechHealth.View.SecretaryView
{
    public partial class MedicalRecordView : Window
    {
        private MedicalRecordController medicalRecordController = new MedicalRecordController();
        private string id;
        private Patient p;
        private List<Bloodtype> lista = new List<Bloodtype>();
        
        public MedicalRecordView(MedicalRecord medicalRecord)
        {
            id = medicalRecord.RecordId;
            p = medicalRecord.Patient;
            InitializeComponent();
            this.DataContext = this;
            name.Content = medicalRecord.Patient.Name + " " + medicalRecord.Patient.Surname;
            lista.Add(Bloodtype.Op);
            lista.Add(Bloodtype.On);
            lista.Add(Bloodtype.Ap);
            lista.Add(Bloodtype.An);
            lista.Add(Bloodtype.Bp);
            lista.Add(Bloodtype.Bn);
            lista.Add(Bloodtype.ABp);
            lista.Add(Bloodtype.ABn);
            lista.Add(Bloodtype.None);
            bloodTypeCombo.ItemsSource = lista;
            bloodTypeCombo.SelectedItem = medicalRecord.BloodType;
            textboxWeight.Text = medicalRecord.Weight;
            textboxHeight.Text = medicalRecord.Height;
            textboxChronicDiseases.Text = medicalRecord.ChronicDiseases;
            textboxParentDiseases.Text = medicalRecord.ParentDiseases;
            textboxMartialStatus.Text = medicalRecord.MartialStatus;
            textboxOur.Text = medicalRecord.EmlpoymentData.Our;
            textboxProfession.Text = medicalRecord.EmlpoymentData.Profession;
            textboxWorkplace.Text = medicalRecord.EmlpoymentData.Workplace;
            textboxJob.Text = medicalRecord.EmlpoymentData.Job;
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
            EmlpoymentData ed = new EmlpoymentData();

            ed.Our = textboxOur.Text;
            ed.Workplace = textboxWorkplace.Text;
            ed.Profession = textboxProfession.Text;
            ed.Job = textboxJob.Text;

            medicalRecordController.Update(id, lista[bloodTypeCombo.SelectedIndex], p, textboxWeight.Text, textboxHeight.Text, textboxChronicDiseases.Text, textboxParentDiseases.Text, textboxMartialStatus.Text, ed);

            this.Close();
            new AccountsView().Show();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            new AccountsView().Show();
        }
    }
}
