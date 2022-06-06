using TechHealth.Model;

namespace TechHealth.Repository.IRepository
{
    public interface IAnamnesisRepository:IRepository<Anamnesis,string>
    {
        Anamnesis GetByAppointmentId(string appointmentId);
    }
}