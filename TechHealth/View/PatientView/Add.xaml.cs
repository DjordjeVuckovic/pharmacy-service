﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TechHealth.Model;
using TechHealth.Repository;
using MessageBox = System.Windows.MessageBox;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private Patient patient;
        private List<Doctors> doctors;
        private List<Room> rooms;
        public Add(string patientId)
        {
            InitializeComponent();
            patient = PatientRepository.Instance.GetPatientbyId(patientId);
            doctors = DoctorRepository.Instance.DictionaryValuesToList();
            rooms = RoomRepository.Instance.DictionaryValuesToList();

            PatientTxt.Text = patient.ToString();
            DoctorsCombo.ItemsSource = doctors;
            RoomCombo.ItemsSource = rooms;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            if (DoctorsCombo.SelectionBoxItem == null || Picker.SelectedDate == null ||
                DoctorsCombo.SelectionBoxItem == null || RoomCombo.SelectionBoxItem == null)
            {
                MessageBox.Show("Please fill all fields!");
            }
            else
            {
                Appointment appointment = new Appointment()
                {
                    AppointmentType = AppointmentType.examination,
                    Date = DateTime.Parse(Picker.Text),
                    Patient = patient,
                    Emergent = false,
                    FinishTime = FinishTxt.Text,
                    StartTime = StartTxt.Text,
                    IdAppointment = DateTime.Now.ToString("f"),
                    Doctor = doctors[PatentCombo.SelectedIndex],
                    Room = rooms[RoomCombo.SelectedIndex]
                };
                AppointmentRepository.Instance.Create(appointment);
                MessageBox.Show("You have successfully created new appointment");
                Close();

            }
        }



        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure about that?", "Cancel appointment", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                Close();
            }

        }
    }
}