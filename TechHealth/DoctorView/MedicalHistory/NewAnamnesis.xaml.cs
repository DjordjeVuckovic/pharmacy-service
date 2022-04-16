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
using TechHealth.DoctorView.ViewModel;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.MedicalHistory
{
    /// <summary>
    /// Interaction logic for NewAnamnesis.xaml
    /// </summary>
    public partial class NewAnamnesis : Window
    {
        private Appointment myappointment;
        public NewAnamnesis()
        {
            InitializeComponent();
        }

        public NewAnamnesis(Appointment appointment)
        {
            InitializeComponent();
            DataContext = this;
            myappointment = appointment;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //Finish
            Anamnesis anamnesis = CreateAnamnesis();
            AnamnesisRepository.Instance.Create(anamnesis);
            Close();
            myappointment.Evident = true;
            UpdateList(myappointment);
            AppointmentRepository.Instance.Update(myappointment);
        }

        private Anamnesis CreateAnamnesis()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            Anamnesis anamnesis = new Anamnesis
            {
                Appointment = myappointment,
                MainIssue = Txt1.Text,
                AnamnesisDate = DateTime.Now,
                AnamnesisId = randomGenerator.GenerateRandHash(),
                OtherSymptoms = Txt2.Text,
                GeneralAmnesis = Txt3.Text,
                Cns = Txt4.Text,
                Eye = txt5.Text,
                Neck = txt6.Text,
                Mss = txt7.Text,
                Skin = txt8.Text,
                Ear = txt9.Text,
                Cus = txt10.Text,
                Infectious = txt11.Text,
                Ugs = txt12.Text,
                Respiratory = txt13.Text,
                Mouth = txt14.Text,
                Gi = txt15.Text,
            };
            return anamnesis;
        }
        private void UpdateList(Appointment app1)
        {
            int index=RecordViewModel.GetInstance().Appointments.IndexOf(app1);
            RecordViewModel.GetInstance().Appointments.Remove(app1);
            RecordViewModel.GetInstance().Appointments.Insert(index, myappointment);   
        }
        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
