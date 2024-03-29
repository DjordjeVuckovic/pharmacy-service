﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.DoctorView.CRUDAppointments;
using TechHealth.DoctorView.View;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TechHealth.DoctorView.ViewModel
{
    
    public class ViewModelAppointment:ViewModelBase
    {
        private ObservableCollection<Appointment> _appointments;
        private  string doctorId;
        private static ViewModelAppointment _instance;
        
        public RelayCommand NewExaminationCommand { get; set; }
        public RelayCommand NewSurgeryCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        private readonly  AppointmentController appointmentController = new AppointmentController();
        private readonly DoctorController doctorController = new DoctorController();
        private Doctor currentDoctor;
        public string DoctorId
        {
            get => doctorId;
            set
            {
                doctorId = value;
                OnPropertyChanged(nameof(DoctorId));
            }
        }
        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set
            {
                _appointments = value;
                OnPropertyChanged(nameof(Appointments));
            }
            
        }
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
        public static ViewModelAppointment GetInstance()
        {
            return _instance;
        }
        public ViewModelAppointment(string id)
        {
            _instance = this;
            doctorId = id;
            Appointments = new ObservableCollection<Appointment>(appointmentController.GetAllNotEvidentByDoctorId(doctorId));
            currentDoctor = doctorController.GetById(doctorId);
            NewExaminationCommand = new RelayCommand(param => Execute(),param => CanExecute());
            NewSurgeryCommand= new RelayCommand(param => Execute1(),param => CanExecute1());
            UpdateCommand= new RelayCommand(param => Execute2(),param => CanExecute2());
            DeleteCommand= new RelayCommand(param => Execute3(),param => CanExecute3());
            //RefreshView();

        }
        public void RefreshView()
        {
            Appointments.Clear();
            Appointments = new ObservableCollection<Appointment>(appointmentController.GetAllNotEvidentByDoctorId(doctorId));
        }
        private bool CanExecute()
        {
            
            return true;
        }

        private void Execute()
        {
            var vm = new CreateExaminationViewModel(doctorId, Appointments);
            var createExamination = new CreateExamination()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => createExamination.Close();
            createExamination.ShowDialog();
            
        }
        private bool CanExecute1()
        {
            if (currentDoctor.Specialization.IdSpecialization == 0)
            {
                return false;
            }
            return true;
        }

        private void Execute1()
        {
            var vm = new CreateSurgeryViewModel(doctorId, Appointments);
            CreateSurgery createSurgery = new CreateSurgery()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => createSurgery.Close();
            createSurgery.ShowDialog();
        }
        private bool CanExecute2()
        {
            if (SelectedItem == null )
            {
                return false;
            }

            return true;
        }

        private void Execute2()
        {
            //new AppointmentsUpdate(SelectedItem).ShowDialog();
            var vm = new UpdateAppointmentViewModel(doctorId, SelectedItem);
            var updateAppointment = new UpdateAppointment()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => updateAppointment.Close();
            updateAppointment.ShowDialog();
        }
        private bool CanExecute3()
        {
            if (SelectedItem == null )
            {
                return false;
            }

            return true;
        }

        private void Execute3()
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure?", @"Delete appointment", MessageBoxButtons.YesNo);
            if(dialogResult==(DialogResult) MessageBoxResult.Yes)
            {
                appointmentController.Delete(SelectedItem.IdAppointment);
                Appointments.Remove(SelectedItem);
                RecordViewModel.GetInstance().RefreshView();
                MessageBox.Show(@"You are successfully deleted an appointment");
            }

        }
    }
    
    
}