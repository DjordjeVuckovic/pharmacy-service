﻿using System;
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
    public partial class AddPatient : Window
    {
        private PatientController patientController = new PatientController();
        private MedicalRecordController medicalRecordController = new MedicalRecordController();
        public AddPatient()
        {
            InitializeComponent();
        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        private void Button_Meetings(object sender, RoutedEventArgs e)
        {
            new MeetingsPickDate().Show();
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
            if (accountName.Text == "" || accountSurname.Text == "" || accountJmbg.Text == "" || accountLbo.Text == "" || accountPhone.Text == "" || accountStreet.Text == "" || accountStreetNumber.Text == "" || accountCity.Text == "" || accountCountry.Text == "" || accountPostcode.Text == "" || accountUsername.Text == "" || accountPassword.Text == "")
            {
                MessageBox.Show("Fill out all the fields.");
                return;
            }

            var address = new Address();

            address.Street = accountStreet.Text;
            address.StreetNumber = accountStreetNumber.Text;
            address.City = accountCity.Text;
            address.Country = accountCountry.Text;
            try
            {
                int ap = Int32.Parse(accountPostcode.Text);
            }
            catch
            {
                MessageBox.Show("Postcode must have only numbers.");
                return;
            }
            address.Postcode = Int32.Parse(accountPostcode.Text);

            if (!patientController.CheckAvailability(accountJmbg.Text, accountUsername.Text)) { return; }

            patientController.Create(accountName.Text, accountSurname.Text, address, null, accountJmbg.Text, Int32.Parse(accountLbo.Text), false, accountUsername.Text, accountPassword.Text, accountEmail.Text, false, false, accountPhone.Text);

            Patient p = new Patient();
            p.Name = accountName.Text;
            p.Surname = accountSurname.Text;
            p.ChosenDoctor = null;
            p.Address = address;
            p.Jmbg = accountJmbg.Text;
            p.Lbo = Int32.Parse(accountLbo.Text);
            p.Guest = false;
            p.IsBanned = false;
            p.Email = accountEmail.Text;
            p.Employed = false;
            p.Phone = accountPhone.Text;
            p.Username = accountUsername.Text;
            p.Password = accountPassword.Text;

            EmlpoymentData ed = new EmlpoymentData();

            ed.Our = "";
            ed.Workplace = "";
            ed.Profession = "";
            ed.Job = "";

            medicalRecordController.Create(accountName.Text+accountSurname.Text+accountJmbg.Text, Bloodtype.None, p, "", "", "", "", "", ed);

            new AccountsView().Show();
            Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            new AccountsView().Show();
            Close();
        }

        private void accountStreet_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
