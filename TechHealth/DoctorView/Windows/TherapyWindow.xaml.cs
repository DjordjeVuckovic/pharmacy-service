using System.Windows;

namespace TechHealth.DoctorView.Windows
{
    public partial class TherapyWindow : Window
    {
        //private Doctor doctor;
        //private Patient patient;
        public TherapyWindow()
        {
            InitializeComponent();
            // string doctorId = DoctorWindow.GetDoctorId();
            // doctor = DoctorRepository.Instance.GetById(doctorId);
            // patient = PatientRepository.Instance.GetById(selectedItem.Jmbg);
        }

        /*private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            CreateTherapy();
        }

        private void CreateTherapy()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            Therapy therapy = new Therapy
            {
                TherapyId = randomGenerator.GenerateRandHash(),
                Patient = patient,
                Doctor = doctor,
                StartDate = DateTime.Parse(DatePicker.Text),
                FinishDate = DateTime.Parse(DatePicker1.Text),
                Frequency = TextBox.Text,
                Description = TextBox1.Text
            };
            TherapyRepository.Instance.Create(therapy);
            
        }*/
    }
}