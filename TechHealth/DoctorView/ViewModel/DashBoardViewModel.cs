using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.DoctorView.CRUDAppointments;
using TechHealth.DoctorView.MedicalHistory;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.Windows;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class DashBoardViewModel:ViewModelBase
    {
       public ObservableCollection<Appointment> MyAppointments { get; set; }
       private readonly AppointmentController appointmentController = new AppointmentController();
       private Appointment selectedItem;

       public Appointment SelectedItem
       {
           get => selectedItem;
           set
           {
               selectedItem = value;
               OnPropertyChanged(nameof(SelectedItem));
           }
       }
       public RelayCommand NewExaminationCommand { get; set; }
       public RelayCommand NewSurgeryCommand { get; set; }
       public RelayCommand NotificationCommand { get; set; }
       private NotificationView NotificationView { get; set; }
       public RelayCommand NewCommand { get; set; }
       public RelayCommand RateCommand { get; set; }

       public DashBoardViewModel()
       {
           NotificationView = new NotificationView();
           MyAppointments = new ObservableCollection<Appointment>(appointmentController.GetAllNotEvidentByDoctorId(MainViewModel.DoctorId));
           NewExaminationCommand = new RelayCommand(param => Execute(),param => CanExecute());
           NewSurgeryCommand= new RelayCommand(param => Execute1(),param => CanExecute1());
           NotificationCommand = new RelayCommand(o =>
               {
                   MainViewModel.GetInstance().CurrentView = NotificationView;
               }
           );
           NewCommand = new RelayCommand(param => ExecuteAnamnesis(),param=>CanExecuteAnamnesis());
           RateCommand = new RelayCommand(param => ExecuteRate());
       }

       private void ExecuteRate()
       {
           var rate = new RateApplicationWindow();
           rate.ShowDialog();
       }

       private bool CanExecuteAnamnesis()
       {
           if (SelectedItem != null)
           {
               return true;
           }

           return false;
       }
       private void ExecuteAnamnesis()
       {
           var vm = new NewAnamnesisViewModel(SelectedItem);
           NewAnamnesis newAnamnesis = new NewAnamnesis()
           {
               DataContext = vm
           };
           MyAppointments.Remove(SelectedItem);
           vm.OnRequestClose += (s, e) => newAnamnesis.Close();
           newAnamnesis.ShowDialog();
       }
       private bool CanExecute()
       {
            
           return true;
       }

       private void Execute()
       {
           var vm = new CreateExaminationViewModel(MainViewModel.DoctorId, MyAppointments);
           var createExamination = new CreateExamination()
           {
               DataContext = vm
           };
           vm.OnRequestClose += (s, e) => createExamination.Close();
           createExamination.ShowDialog();
            
       }
       private bool CanExecute1()
       {
           return true;
       }

       private void Execute1()
       {
           var vm = new CreateSurgeryViewModel(MainViewModel.DoctorId, MyAppointments);
           CreateSurgery createSurgery = new CreateSurgery()
           {
               DataContext = vm
           };
           vm.OnRequestClose += (s, e) => createSurgery.Close();
           createSurgery.ShowDialog();
       }
       
    }
}