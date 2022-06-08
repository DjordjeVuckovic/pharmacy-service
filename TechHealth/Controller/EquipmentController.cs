using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class EquipmentController
    {
        private IEquipmentService equipmentService = new EquipmentService();

        public List<Equipment> GetAllToList()
        {
            return equipmentService.GetAll();
        }
        public bool Create(Equipment eq)
        {
            return equipmentService.Create(eq);
        }

        public bool Update(Equipment eq)
        {
            return equipmentService.Update(eq);
        }

        public bool Delete(string eqID)
        {
            return equipmentService.Delete(eqID);
        }
        public List<Equipment> GetEquipmentByEqType(EquipmentType type)
        {
            return equipmentService.GetEquipmentByEqType(type);


        }

        public bool UpdateEquipmentQuantityIfItExists(List<Equipment> eqList, Equipment equipment)
        {
            return equipmentService.UpdateEquipmentQuantityIfItExists(eqList, equipment);
        }
    }
}
