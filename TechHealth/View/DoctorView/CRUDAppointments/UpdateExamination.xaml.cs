using System.Collections.Generic;
using System.Windows;
using TechHealth.Model;

namespace TechHealth.View.DoctorView.CRUDAppointments
{
    public partial class UpdateExamination : Window
    {
        private Doctor doctor;
        private List<Patient> patients;
        private List<Room> rooms;
        private Appointment appointment;
        public UpdateExamination(Appointment dataAppointmentSelectedItem)
        {
            InitializeComponent();
            appointment = dataAppointmentSelectedItem;
            
        }

        private void FillFields()
        {
            
        }
    }  
}