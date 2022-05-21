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
        public List<Equipment> GetEquipmentByEqType(EquipmentType type)
        {
            return equipmentService.GetEquipmentByEqType(type);


        }
    }
}
