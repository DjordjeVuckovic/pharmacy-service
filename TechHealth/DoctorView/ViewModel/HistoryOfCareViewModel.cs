using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.DoctorView.MedicalHistory;
using TechHealth.DoctorView.Windows;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class HistoryOfCareViewModel:ViewModelBase
    {
        private Patient selectedItemPatient;
        private readonly AnamnesisController anamnesisController = new AnamnesisController();
        private readonly PrescribeMedicineController prescribeMedicineController = new PrescribeMedicineController();
        private readonly TherapyController therapyController = new TherapyController();
        public ObservableCollection<Anamnesis> AnamnesesSurgeries { get; set;}
        public ObservableCollection<Anamnesis> AnamnesesExaminations { get; set;}
        public ObservableCollection<Prescription> Prescriptions { get; set; }
        public ObservableCollection<Therapy> Therapies { get; set; }
        private string PatientLabel { get; set; }
        private ReviewAnamnesis reviewAnamnesis { get; set; }
        private int selectedIndex;
        public RelayCommand PreviewCommand { get; set; }
        private Anamnesis selectedAnamnesis;
        private Therapy selectedTherapy;
        private Prescription selectedPrescription;
        private TherapyPreview therapyPreview;
        private PrescriptionPreview prescriptionPreview;
        
        

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        public Prescription SelectedPrescription
        {
            get => selectedPrescription;
            set
            {
                selectedPrescription = value;
                OnPropertyChanged(nameof(SelectedPrescription));
            }
        }

        public Anamnesis SelectedAnamnesis
        {
            get => selectedAnamnesis;
            set
            {
                selectedAnamnesis = value;
                OnPropertyChanged(nameof(SelectedAnamnesis));
            }
        }
        public Therapy SelectedTherapy
        {
            get => selectedTherapy;
            set
            {
                selectedTherapy = value;
                OnPropertyChanged(nameof(SelectedTherapy));
            }
        }
        public  string LabelFullName { get; set; }

        public HistoryOfCareViewModel(Patient selectedItem)
        {
            selectedItemPatient = selectedItem;
            PatientLabel = selectedItem.FullName;
            AnamnesesSurgeries = anamnesisController.GetAllAnamnesisSurgeriesByPatient(selectedItem.Jmbg);
            AnamnesesExaminations = anamnesisController.GetAllAnamnesisExaminationsByPatient(selectedItem.Jmbg);
            Prescriptions = new ObservableCollection<Prescription>(prescribeMedicineController.GetAllByPatientId(selectedItem.Jmbg));
            Therapies = therapyController.GetAllByPatientId(selectedItem.Jmbg);
            SelectedIndex = 0;
            PreviewCommand = new RelayCommand(param => Execute(), param => CanExecute());
            LabelFullName ="History of care for patient: "+ selectedItemPatient.FullName;

        }
        

        private bool CanExecute()
        {
            if (SelectedIndex==0 & SelectedAnamnesis == null)
            {
                return false;
            }
            if (SelectedIndex==1 & SelectedAnamnesis == null)
            {
                return false;
            }
            if (SelectedIndex==3 & SelectedTherapy == null)
            {
                return false;
            }
            if (SelectedIndex==2 & SelectedPrescription == null)
            {
                return false;
            }

            return true;
        }

        private void Execute()
        {
            if (SelectedIndex == 0 || SelectedIndex == 1)
            {
                reviewAnamnesis= new ReviewAnamnesis(SelectedAnamnesis.Appointment);
                reviewAnamnesis.ShowDialog();
            }
            if (SelectedIndex == 3)
            {
                var vm = new TherapyPreviewViewModel(SelectedTherapy,selectedItemPatient);
                therapyPreview = new TherapyPreview
                {
                    DataContext = vm
                };
                therapyPreview.ShowDialog();
            }
            
            if (SelectedIndex == 2)
            {
                var vm = new PrescriptionPreviewViewModel(selectedItemPatient,SelectedPrescription);
                prescriptionPreview = new PrescriptionPreview
                {
                    DataContext = vm
                };
                prescriptionPreview.ShowDialog();
            }
            
        }
    }
}