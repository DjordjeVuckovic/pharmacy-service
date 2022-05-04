using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Controller;
using TechHealth.DTO;
using TechHealth.Model;
using TechHealth.Repository;

using TechHealth.View.PatientView.View;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for SuggestAppointment.xaml
    /// </summary>
    /// 

    /*class TerminZaPreporuku
    {
        private List<Doctor> doctors;
        private DateTime time;
        public TerminZaPreporuku() { }
        public TerminZaPreporuku(DateTime time)
        {
            this.Time = time;
            this.Doctors = DoctorRepository.Instance.GetAllToList();
        }
        public List<Doctor> Doctors { get; set; }
        public DateTime Time { get; set; }
    }*/


    public partial class SuggestAppointment : Window //da li ovde treba user control
    {
        private void CheckedDate(object sender, RoutedEventArgs e)
        {

        }

        private void CheckedDoctor(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {

        }
    }
}
