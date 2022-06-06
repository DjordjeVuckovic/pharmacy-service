using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IEquipmentService:IService<Equipment,string>
    {
        List<Equipment> GetEquipmentByEqType(EquipmentType type);
        bool UpdateEquipmentQuantityIfItExists(List<Equipment> eqList, Equipment equipment);
    }
}