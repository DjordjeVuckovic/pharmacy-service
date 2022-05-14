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
    public partial class SecretaryMainWindow : Window
    {
        private ObservableCollection<Patient> users = new ObservableCollection<Patient>();
        private ObservableCollection<Patient> guests = new ObservableCollection<Patient>();
        private PatientController patientController = new PatientController();
        private PatientAllergensController patientAllergensController = new PatientAllergensController();
        private MedicalRecordController medicalRecordController = new MedicalRecordController();
        public SecretaryMainWindow()
        {
            InitializeComponent();
            foreach(var p in PatientRepository.Instance.GetAll().Values)
            {
                if (!p.Guest)
                {
                    users.Add(p);
                }
                else
                {
                    guests.Add(p);
                }
            }
            accountList.ItemsSource = users;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
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
            if(!p.Guest)
            {
                patientController.Delete(p.Jmbg);
                users = new ObservableCollection<Patient>(PatientRepository.Instance.GetAll().Values);
                accountList.ItemsSource = users;
                foreach(var pa in PatientAllergensRepository.Instance.GetAll().Values)
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
            new MedicalRecordView(medicalRecord).ShowDialog();
            Update();
        }
        private void Button_Click_LogOut(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        private void Button_Click_Examinations(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime date = DateTime.Parse(datePicker.Text);
                new AppointmentsViewSecretary(date, AppointmentType.examination).Show();
            }
            catch
            {
                MessageBox.Show("You didn't select a date.");
                return;
            }
        }
        private void Button_Click_Operations(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime date = DateTime.Parse(datePicker.Text);
                new AppointmentsViewSecretary(date, AppointmentType.operation).Show();
            }
            catch
            {
                MessageBox.Show("You didn't select a date.");
                return;
            }
        }
        public void Update()
        {
            users.Clear();
            guests.Clear();
            foreach (var r in PatientRepository.Instance.GetAll().Values)
            {
                if (!r.Guest)
                {
                    users.Add(r);
                }
                else
                {
                    guests.Add(r);
                }
            }
        }
        private void Button_Guests(object sender, RoutedEventArgs e) 
        {
            new GuestsView().Show();
            Close();
        }
        private void accountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
