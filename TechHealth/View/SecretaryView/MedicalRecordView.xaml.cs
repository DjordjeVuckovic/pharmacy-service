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
        public MedicalRecordView(MedicalRecord medicalRecord)
        {
            //MedicalRecord mr = MedicalRecordRepository.Instance.GetById(medicalRecord.RecordId);
            InitializeComponent();
            this.DataContext = this;
            name.Content = medicalRecord.Patient.Name + " " + medicalRecord.Patient.Surname;
            List <Bloodtype> lista = new List<Bloodtype>();
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
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            /*var address = new Address();

            address.Street = accountStreet.Text;
            address.StreetNumber = accountStreetNumber.Text;
            address.City = accountCity.Text;
            address.Country = accountCountry.Text;
            address.Postcode = Int32.Parse(accountPostcode.Text);

            patientController.Update(accountName.Text, accountSurname.Text, address, null, accountJmbg.Text, Int32.Parse(accountLbo.Text), false, accountUsername.Text, accountPassword.Text, accountEmail.Text, false, false, accountPhone.Text);

            this.Close();*/
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
