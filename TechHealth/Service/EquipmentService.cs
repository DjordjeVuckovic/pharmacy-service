using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class EquipmentService
    {
        public List<Equipment> GetEquipmentByEqType(EquipmentType type)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (var eq in EquipmentRepository.Instance.GetAllToList())
            {
                if (eq.type == type)
                {
                    equipmentList.Add(eq);
                }
            }
            return equipmentList;
        }
    }
}
