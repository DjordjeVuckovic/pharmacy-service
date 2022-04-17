using System;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class TherapyViewModel:ViewModelBase
    {
        private Patient patient;
        private Doctor doctor;
        private DateTime startDate;
        private DateTime finishDate;
        private string description;

        public Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }
        public Doctor Doctor {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged(nameof(Doctor));
            }
        }
        public DateTime StartDate{
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        public DateTime FinishDate{
            get
            {
                return finishDate;
            }
            set
            {
                finishDate = value;
                OnPropertyChanged(nameof(FinishDate));
            }
        }
        public string Description{
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }
}