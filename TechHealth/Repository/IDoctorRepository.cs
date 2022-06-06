using TechHealth.Model;

namespace TechHealth.Repository
{
    public interface IDoctorRepository:IRepository<Doctor,string>
    {
         Doctor GetDoctorByUser(string user);
    }
}