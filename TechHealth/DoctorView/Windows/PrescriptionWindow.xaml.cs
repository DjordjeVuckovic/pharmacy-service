using System.Windows;
using TechHealth.Model;

namespace TechHealth.DoctorView.Windows
{
    public partial class PrescriptionWindow : Window
    {
        //private List<Patient> patients;
        private Medicine medicine;

        public PrescriptionWindow()
        {
            InitializeComponent();
            // patients = PatientRepository.Instance.GetAllToList();
            // ComboBox.ItemsSource = patients;
            // medicine = selectedItem;
            // TextBox.Text = medicine.MedicineName;
        }

        /*private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            CreatePrescription();
            Close();
        }

        private void CreatePrescription()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            var culture = new CultureInfo("en-US", true);
            DateTime date = DateTime.Parse(DatePicker.Text);
            DateTime date1 = DateTime.Parse(DatePicker1.Text);
            
            Doctor doctor = DoctorRepository.Instance.GetById(DoctorWindow.GetDoctorId());
            //DateTime dateTime = new DateTime(DatePicker.Day);
            Prescription prescription = new Prescription
            {
                PrescriptionId = randomGenerator.GenerateRandHash(),
                Medicine = medicine,
                Frequency = TextBox1.Text,
                SideEffects = TextBox3.Text,
                Usage = TextBox2.Text,
                StartDate = date,
                FinishDate = date1,
                Doctor = doctor,
                Patient = (Patient) ComboBox.SelectionBoxItem
            };
            PrescribeMedicineRepository.Instance.Create(prescription);
        }
    }*/
    }
}