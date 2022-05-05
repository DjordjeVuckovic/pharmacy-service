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

namespace TechHealth.DoctorView.MedicalHistory
{
    /// <summary>
    /// Interaction logic for ReviewAnamnesis.xaml
    /// </summary>
    public partial class ReviewAnamnesis : Window
    {
        private Appointment myappointment;
        private Anamnesis currentAnamnesis;
        public string DoctorLabel { get; set; }
        public string PateintLabel { get; set; }
        public string PateintLboLabel { get; set; }
        public string RoomLabel { get; set; }
        public string DateLabel { get; set; }
        public ReviewAnamnesis()
        {
            InitializeComponent();
        }
        public ReviewAnamnesis(Appointment appointment)
        {
            InitializeComponent();
            DataContext = this;
            myappointment = appointment;
            currentAnamnesis=AnamnesisRepository.Instance.GetByAppointmentId(myappointment.IdAppointment);
            DoctorLabel = "Doctor: " + myappointment.Doctor.FullSpecialization;
            PateintLabel = "Patient: " + myappointment.Patient.FullName;
            PateintLboLabel = "Patient Lbo: " + myappointment.Patient.Lbo;
            RoomLabel = "Room: " + myappointment.Room.roomId;
            DateLabel = "Appointment Date: " + myappointment.Date.ToString("d");
            FillUpFields();
            
        }

        private void FillUpFields()
        {
            Txt1.Text = currentAnamnesis.MainSymptom;
            Txt2.Text = currentAnamnesis.OtherSymptoms;
            Txt3.Text = currentAnamnesis.GeneralAmnesis;
            Txt4.Text =  currentAnamnesis.Cns; 
            txt5.Text=  currentAnamnesis.Eye;
            txt6.Text=  currentAnamnesis.Neck;
            txt7.Text=  currentAnamnesis.Mss;
            txt8.Text=  currentAnamnesis.Skin;
            txt9.Text=  currentAnamnesis.Ear;
            txt10.Text=  currentAnamnesis.Cus;
            txt11.Text=  currentAnamnesis.Infectious;
            txt12.Text=  currentAnamnesis.Ugs;
            txt13.Text=  currentAnamnesis.Respiratory;
            txt14.Text=  currentAnamnesis.Mouth;
            txt15.Text=  currentAnamnesis.Gi;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
