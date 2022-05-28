using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TechHealth.DoctorView.ViewModel
{
    public class PrescriptionViewModel:ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private Appointment appointment;
        private DateTime startDate;
        private DateTime finishDate;
        private string usage;
        private string frequency;
        private Medicine medicine;
        private List<ComboBoxGeneric<Medicine>> medicineComboBox = new List<ComboBoxGeneric<Medicine>>();
        private readonly MedicineController medicineController = new MedicineController();
        private readonly PrescribeMedicineController prescribeMedicineController = new PrescribeMedicineController();
        


        public List<ComboBoxGeneric<Medicine>> MedicineComboBox
        {

            get => medicineComboBox;
            set
            {
                medicineComboBox = value;
                OnPropertyChanged(nameof(MedicineComboBox));
            }
        }
        public Medicine MedicineData
        {
            get => medicine;
            set
            {
                medicine = value;
                OnPropertyChanged(nameof(MedicineData));
            }
        }
        public Appointment SelectedAppointment
        {
            get => appointment;
            set
            {
                appointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
            }
        }
        public DateTime StartDate{
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        public DateTime FinishDate{
            get => finishDate;
            set
            {
                finishDate = value;
                OnPropertyChanged(nameof(FinishDate));
            }
        }
        public string Frequency
        {
            get => frequency;
            set
            {
                frequency = value;
                OnPropertyChanged(nameof(Frequency));
            }
        }
        public string Usage
        {
            get => usage;
            set
            {
                usage = value;
                OnPropertyChanged(nameof(Usage));
            }
        }
        public string DoctorLabel { get; set; }
        public string PatientLabel { get; set; }
        public string RoomLabel { get; set; }
        
        public RelayCommand FinishCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public PrescriptionViewModel(Appointment selectedItemAppointment)
        {
            SelectedAppointment = selectedItemAppointment;
            FillComboData();
            DoctorLabel = "Doctor:  " + SelectedAppointment.Doctor.FullSpecialization;
            PatientLabel = "Patient:  " + SelectedAppointment.Patient.FullName;
            RoomLabel = "Room: " + SelectedAppointment.Room.roomId;
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
            CancelCommand = new RelayCommand(param => CloseWindow());
            
        }
        private void CloseWindow()
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure about that?", @"Cancel prescription", MessageBoxButtons.YesNo);
            if(dialogResult==(DialogResult) MessageBoxResult.Yes)
            {
                OnRequestClose?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CanExecute()
        {
            if (Frequency != null && Usage != null && MedicineData !=null)
            {
                if(StartDate<FinishDate)
                    return true;
            }

            return false;

        }

        public void Execute()
        {
            if (prescribeMedicineController.CheckAllergens(MedicineData, SelectedAppointment.Patient))
            {
                MessageBox.Show(@"Patient is allergic on selected medicine!",
                    @"Allergen exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CreatePrescription();
            }

            //MessageBox.Show(@"You are successfully create new prescription");
            if (OnRequestClose != null) OnRequestClose(this, EventArgs.Empty);
        }

        private void CreatePrescription()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            //DateTime dateTime = new DateTime(DatePicker.Day);
            Prescription prescription = new Prescription
            {
                PrescriptionId = randomGenerator.GenerateRandHash(),
                Medicine = medicine,
                Frequency = Frequency,
                Usage = Usage,
                StartDate = StartDate,
                FinishDate = FinishDate,
                ShouldSerialize = true,
                Appointment = SelectedAppointment
            };
            prescribeMedicineController.Create(prescription);
            MessageBox.Show(@"You are successfully created new prescription for " + PatientLabel);
        }

        private void FillComboData()
        {

            foreach (var m in medicineController.GetAllApproved())
            {
                medicineComboBox.Add(new ComboBoxGeneric<Medicine>() { DisplayText = m.MedicineName +  " - " + m.MainSubstance.SubstanceName, Entity = m });
            }
            
        }
 

    }
}