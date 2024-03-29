﻿using System;
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
    public partial class AppointmentsPickDate : Window
    {
        public AppointmentsPickDate()
        {
            InitializeComponent();
        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
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

        private void Button_Click_Examinations(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime date = DateTime.Parse(datePicker.Text);
                new AppointmentsViewSecretary(date, AppointmentType.examination).Show();
                Close();
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
                Close();
            }
            catch
            {
                MessageBox.Show("You didn't select a date.");
                return;
            }
        }
        private void accountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
