using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface ITherapyService:IService<Therapy,string>
    {
        List<Therapy> GetAllByPatientId(string patientId);

    }
}