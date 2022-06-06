using System;
using TechHealth.DTO;

namespace TechHealth.Service.IService
{
    public interface IEquipmentReallocationService:IService<EquipmentReallocationDTO,string>
    {
         void SubmitReallocation(EquipmentReallocationDTO dto);
         void ReallocateOnDate(object state);
         bool IsReallocationHappening(DateTime start, DateTime end, string roomID);

    }
}