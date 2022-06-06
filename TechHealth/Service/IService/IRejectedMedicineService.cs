using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IRejectedMedicineService:IService<RejectedMedicine,string>
    {
        RejectedMedicine GetByMedicineId(string medId);
    }
}