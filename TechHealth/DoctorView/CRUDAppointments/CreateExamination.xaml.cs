using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.DoctorView.MedicalHistory;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.ViewModel;
using TechHealth.Model;
using TechHealth.Repository;
using MessageBox = System.Windows.MessageBox;

namespace TechHealth.DoctorView.CRUDAppointments
{
    /// <summary>
    /// Interaction logic for CreateExamination.xaml
    /// </summary>
    public partial class CreateExamination : Window
    {
        public CreateExamination()
        {
            InitializeComponent();
        }
    }
}
