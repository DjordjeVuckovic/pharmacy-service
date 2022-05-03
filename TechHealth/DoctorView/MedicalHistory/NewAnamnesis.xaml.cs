using System;
using System.Windows;
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
        private Appointment app;
        public NewAnamnesis()
        {
            InitializeComponent();
        }

        public NewAnamnesis(Appointment appointment)
        {
            InitializeComponent();
            //DataContext = this;
            myappointment = AppointmentRepository.Instance.GetById(appointment.IdAppointment);
            app = appointment;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //Finish
            CreateAnamnesis();
            app.Evident = true;
            //UpdateList(myappointment);
            AppointmentRepository.Instance.Update(app);
            ViewModelAppointment.GetInstance().RefreshView();
            Close();
        }

        private void CreateAnamnesis()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            Anamnesis anamnesis = new Anamnesis
            {
                AnmnesisAppointment = myappointment,
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
            AnamnesisRepository.Instance.Create(anamnesis);
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
