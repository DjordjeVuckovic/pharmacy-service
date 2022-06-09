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
using TechHealth.Repository;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for AppointmentDetails.xaml
    /// </summary>
    public partial class AppointmentDetails : Window
    {
        private Appointment myAppointment;
        private Anamnesis currentAnamnesis;
        private Doctor appointmentDoctor;
        private Patient loggedPatient;
        public string DoctorLabel { get; set; }
        public string PateintLabel { get; set; }
        public string PateintLboLabel { get; set; }
        public string RoomLabel { get; set; }
        public string DateLabel { get; set; }

        public AppointmentDetails()
        {
            InitializeComponent();
        }

        public AppointmentDetails(Appointment selectedApp)
        {
            InitializeComponent();
            DataContext = this;
            myAppointment = selectedApp;
            currentAnamnesis = AnamnesisRepository.Instance.GetByAppointmentId(myAppointment.IdAppointment);
            DoctorLabel = "Doctor: " + myAppointment.Doctor.FullSpecialization;
            PateintLabel = "Patient: " + myAppointment.Patient.FullName;
            PateintLboLabel = "Patient Lbo: " + myAppointment.Patient.Lbo;
            RoomLabel = "Room: " + myAppointment.Room.RoomId;
            DateLabel = "Appointment Date: " + myAppointment.Date.ToString("d");
            FillUpFields();
        }

        private void FillUpFields()
        {
            Txt1.Text = currentAnamnesis.MainSymptom;
            Txt2.Text = currentAnamnesis.OtherSymptoms;
            Txt3.Text = currentAnamnesis.GeneralAmnesis;
            Txt4.Text = currentAnamnesis.Cns;
            txt5.Text = currentAnamnesis.Eye;
            txt6.Text = currentAnamnesis.Neck;
            txt7.Text = currentAnamnesis.Mss;
            txt8.Text = currentAnamnesis.Skin;
            txt9.Text = currentAnamnesis.Ear;
            txt10.Text = currentAnamnesis.Cus;
            txt11.Text = currentAnamnesis.Infectious;
            txt12.Text = currentAnamnesis.Ugs;
            txt13.Text = currentAnamnesis.Respiratory;
            txt14.Text = currentAnamnesis.Mouth;
            txt15.Text = currentAnamnesis.Gi;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
