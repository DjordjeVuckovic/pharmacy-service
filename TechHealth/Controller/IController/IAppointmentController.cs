using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Controller.IController
{
    public interface IAppointmentController:IController<Appointment,string>
    {
        List<Appointment> GetAllNotEvident();
        List<Appointment> GetAllEvident();
        List<Appointment> GetAllNotEvidentByDoctorId(string doctorId);
        void Postpone(Appointment appointment);
        List<Appointment> GetByDoctorId(string doctorId);

    }
}