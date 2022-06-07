using System;
using MaterialDesignThemes.Wpf;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.Windows;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class AccountViewModel
    {
        private readonly DoctorController doctorController = new DoctorController();
        private Doctor Doctor { get; set; }
        public RelayCommand VacationCommand { get; set; }
        public RelayCommand VacationHistoryCommand { get; set; }
        public string DoctorFullName { get; set; }
        public string Specialization { get; set; }
        public string LabelBirth { get; set; }
        public string LabelId { get; set; }
        public string LabelPhone { get; set; }
        public string LabelEmail { get; set; }
        public string LabelAddress { get; set; }
        public AccountViewModel(string doctorId)
        {
            Doctor = doctorController.GetById(doctorId);
            DoctorFullName = Doctor.FullName;
            Specialization = Doctor.Specialization.NameSpecialization;
            LabelBirth = Doctor.Birthday.ToShortDateString();
            LabelId = Doctor.Jmbg;
            LabelPhone = Doctor.Phone;
            LabelEmail = Doctor.Email;
            LabelAddress = Doctor.Address.Street + "," + Doctor.Address.StreetNumber + "," + Doctor.Address.City + "," + Doctor.Address.Postcode + "," + Doctor.Address.Country;
            VacationCommand = new RelayCommand(param => ExecuteVacation());
            VacationHistoryCommand = new RelayCommand(param => ExecuteVacationHistory());
        }

        private void ExecuteVacation()
        {
            var vm = new DoctorVacationViewModel(Doctor);
            var vacationView = new DoctorVacationWindow()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => vacationView.Close();
            vacationView.ShowDialog();
        }

        private void ExecuteVacationHistory()
        {
            var vm = new VacationHistoryViewModel(Doctor);
            MainViewModel.GetInstance().CurrentView = vm;
        }
        
    }
}