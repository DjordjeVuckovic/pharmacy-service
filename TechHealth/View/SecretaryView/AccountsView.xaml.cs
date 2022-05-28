using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TechHealth.View.SecretaryView
{
    public partial class AccountsView : Window
    {
        private ObservableCollection<Patient> users = new ObservableCollection<Patient>();
        private PatientController patientController = new PatientController();
        private PatientAllergensController patientAllergensController = new PatientAllergensController();
        private MedicalRecordController medicalRecordController = new MedicalRecordController();
        public AccountsView()
        {
            InitializeComponent();
            foreach (var p in PatientRepository.Instance.GetAll().Values)
            {
                if (!p.Guest)
                {
                    users.Add(p);
                }
            }
            accountList.ItemsSource = users;
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Hide();
            new AddPatient().ShowDialog();
            Update();
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (accountList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an account.");
                return;
            }
            Patient p = (Patient)accountList.SelectedItems[0];
            if (!p.Guest)
            {
                patientController.Delete(p.Jmbg);
                Update();
                foreach (var pa in PatientAllergensRepository.Instance.GetAll().Values)
                {
                    if (pa.PatientJMBG.Equals(p.Jmbg))
                    {
                        patientAllergensController.Delete(pa.PatientJMBG + "-" + pa.AllergenName);
                    }
                }
            }
            medicalRecordController.Delete(p.Name + p.Surname + p.Jmbg);
        }
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (accountList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an account.");
                return;
            }
            Patient patient = (Patient)accountList.SelectedItems[0];
            Hide();
            new UpdatePatient(patient).ShowDialog();
            Update();
        }
        private void Button_Click_Allergens(object sender, RoutedEventArgs e)
        {
            if (accountList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an account.");
                return;
            }
            Patient patient = (Patient)accountList.SelectedItems[0];
            Hide();
            new AllergensView(patient).ShowDialog();
            Update();
        }
        private void Button_Click_MedicalRecord(object sender, RoutedEventArgs e)
        {
            if (accountList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an account.");
                return;
            }
            Patient patient = (Patient)accountList.SelectedItems[0];
            MedicalRecord medicalRecord = new MedicalRecord();
            foreach (var mr in MedicalRecordRepository.Instance.GetAll().Values)
            {
                if (mr.Patient.Jmbg.Equals(patient.Jmbg))
                {
                    medicalRecord = mr;
                }
            }
            Hide();
            new MedicalRecordView(medicalRecord).ShowDialog();
            Update();
        }
        public void Update()
        {
            users.Clear();
            foreach (var r in PatientRepository.Instance.GetAll().Values)
            {
                if (!r.Guest)
                {
                    users.Add(r);
                }
            }
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
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
    }
}
