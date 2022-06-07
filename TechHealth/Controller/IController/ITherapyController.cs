using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Controller.IController
{
    public interface ITherapyController:IController<Therapy,string>
    {
        List<Therapy> GetAllByPatientId(string patientId);
    }
}