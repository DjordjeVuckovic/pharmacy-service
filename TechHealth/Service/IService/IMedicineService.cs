using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IMedicineService:IService<Medicine,string>
    {
        List<Medicine> GetAllApproved();
    }
}