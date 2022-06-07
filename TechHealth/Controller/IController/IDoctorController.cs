using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Controller.IController
{
    public interface IDoctorController:IController<Doctor,string>
    {
        List<Doctor> GetAllBySpecializationId(int id);
    }
}