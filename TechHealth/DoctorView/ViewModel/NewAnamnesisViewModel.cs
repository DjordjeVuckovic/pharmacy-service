using System;
using System.Windows;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Exceptions;
using TechHealth.Model;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TechHealth.DoctorView.ViewModel
{
    public class NewAnamnesisViewModel:ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private Appointment appointment;
        private string mainSymptom;
        private DateTime anamnesisDate;
        private string otherSymptoms;
        private string generalAmnesis;
        private string cns;
        private string eye;
        private string neck;
        private string mss;
        private string skin;
        private string ear;
        private string cus;
        private string infectious;
        private string ugs;
        private string respiratory;
        private string mouth;
        private string gi;
        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly AnamnesisController anamnesisController = new AnamnesisController();
        public RelayCommand FinishCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public Appointment Appointment
        {
            get => appointment;
            set
            {
                appointment = value;
                OnPropertyChanged(nameof(Appointment));
            }
        }

        public string MainSymptom
        {
            get => mainSymptom;
            set
            {
                mainSymptom = value;
                OnPropertyChanged(nameof(MainSymptom));
            }
        }

        public DateTime AnamnesisDate
        {
            get => anamnesisDate;
            set
            
            { 
                anamnesisDate = value;
                OnPropertyChanged(nameof(AnamnesisDate));
            }
        }
        

        public string OtherSymptoms
        {
            get => otherSymptoms;
            set
            {
                otherSymptoms = value;
                OnPropertyChanged(nameof(OtherSymptoms));
            } 
        }

        public string GeneralAmnesis
        {
            get => generalAmnesis;
            set
            { 
                generalAmnesis = value;
                OnPropertyChanged(nameof(GeneralAmnesis));
            }
        }

        public string Cns
        {
            get => cns;
            set
            {
                cns = value;
                OnPropertyChanged(nameof(Cns));
            }
        }

        public string Eye
        {
            get => eye;
            set
            {
                eye = value;
                OnPropertyChanged(nameof(Eye));
            }
        }

        public string Neck
        {
            get => neck;
            set
            {
                neck = value;
                OnPropertyChanged(nameof(Neck));
            }
        }

        public string Mss
        {
            get => mss;
            set
            {
                 mss = value;
                 OnPropertyChanged(nameof(Mss));
            }
        }

        public string Skin
        {
            get => skin;
            set
            {
                skin = value;
                OnPropertyChanged(nameof(Skin));
            }
        }

        public string Ear
        {
            get => ear;
            set
            {
                ear = value;
                OnPropertyChanged(nameof(Ear));
            }
        }

        public string Cus
        {
            get => cus;
            set
            {
                 cus = value;
                 OnPropertyChanged(nameof(Cus));
            }
        }

        public string Infectious
        {
            get => infectious;
            set
            {
                 infectious = value;
                 OnPropertyChanged(nameof(Infectious));
            }
        }

        public string Ugs
        {
            get => ugs;
            set
            {
                ugs = value;
                OnPropertyChanged(nameof(Ugs));
            }
        }

        public string Respiratory
        {
            get => respiratory;
            set
            { 
                 respiratory = value;
                 OnPropertyChanged(nameof(Respiratory));
            }
        }

        public string Mouth
        {
            get => mouth;
            set
            {
                mouth = value;
                OnPropertyChanged(nameof(Mouth));
            }
        }

        public string Gi
        {
            get => gi;
            set
            {
                gi = value;
                OnPropertyChanged(nameof(Gi));
            }
        }
        public string DoctorLabel { get; set; }
        public string PateintLabel { get; set; }
        public string PateintLboLabel { get; set; }
        public string RoomLabel { get; set; }
        public string DateLabel { get; set; }

        public NewAnamnesisViewModel(Appointment appointment)
        {
            Appointment = appointment;
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
            CancelCommand = new RelayCommand(param => CloseWindow());
            DoctorLabel = "Doctor: " + Appointment.Doctor.FullSpecialization;
            PateintLabel = "Patient: " + Appointment.Patient.FullName;
            PateintLboLabel = "Patient Lbo: " + Appointment.Patient.Lbo;
            RoomLabel = "Room: " + Appointment.Room.roomId;
            DateLabel = "Appointment Date: " + Appointment.Date.ToString("d");

        }
        public bool CanExecute()
        {
            if (MainSymptom != null && OtherSymptoms != null && GeneralAmnesis != null )
            {
               
                    return true;
            }

            return false;

        }

        public void Execute()
        {
            CreateAnamnesis();
            Appointment.Evident = true;
            appointmentController.Update(Appointment);
            ViewModelAppointment.GetInstance().RefreshView();
            OnRequestClose(this, new EventArgs());
        }
        private void CloseWindow()
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure about that?", @"Cancel appointment", MessageBoxButtons.YesNo);
            if(dialogResult==(DialogResult) MessageBoxResult.Yes)
            {
                OnRequestClose(this, new EventArgs());
            }
        }
        private void CreateAnamnesis()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            Anamnesis anamnesis = new Anamnesis
            {
                Appointment = Appointment,
                MainSymptom = MainSymptom,
                AnamnesisDate = DateTime.Now,
                AnamnesisId = randomGenerator.GenerateRandHash(),
                OtherSymptoms = OtherSymptoms,
                GeneralAmnesis = GeneralAmnesis,
                Cns = Cns,
                Eye = Eye,
                Neck =Neck,
                Mss = Mss,
                Skin = Skin,
                Ear = Ear,
                Cus = Cus,
                Infectious = Infectious,
                Ugs = Ugs,
                Respiratory = Respiratory,
                Mouth = Mouth,
                Gi = Gi
            };
            anamnesisController.Create(anamnesis);
        }

    }
    
}