using System;
using System.Collections.ObjectModel;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.ViewModel
{
    
    public class ViewModelAppointment
    {
        private ObservableCollection<Appointment> _appointments;
        public Appointment selectedItem;
        private readonly string doctorId;

        public ViewModelAppointment(string doctorId)
        {
            this.doctorId = doctorId;
        }

        public ObservableCollection<Appointment> Appointments =>
            _appointments ?? (_appointments =
                new ObservableCollection<Appointment>(AppointmentRepository.Instance.GetByDoctorId(doctorId)));
        
        
    }
    
}