using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IDoctorService:IService<Doctor,string>
    {
        List<Doctor> GetAllBySpecializationId(int id);
    }
}