using TechHealth.Model;

namespace TechHealth.Repository.IRepository
{
    public interface IDoctorRepository:IRepository<Doctor,string>
    {
         Doctor GetDoctorByUser(string user);
    }
}