using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IAppointmentService:IService<Appointment,string>
    {
        List<Appointment> GetAllNotEvidentByDoctorId(string doctorId);
        void Postpone(Appointment appointment);
        List<Appointment> GetAllNotEvident();
        List<Appointment> GetByDoctorId(string doctorId);
        void CheckAvailability(Appointment appointment);
        List<Appointment> GetAllEvident();

    }
}