using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class EquipmentController
    {
        private EquipmentService equipmentService = new EquipmentService();

        public List<Equipment> GetAllToList()
        {
            return equipmentService.GetAllToList();
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
    }
}
