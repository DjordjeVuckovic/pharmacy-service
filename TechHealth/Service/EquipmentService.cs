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
        public List<Equipment> GetAllToList()
        {
            return EquipmentRepository.Instance.GetAllToList();
        }
        public bool Create(Equipment eq)
        {
            return EquipmentRepository.Instance.Create(eq);
        }

        public bool Update(Equipment eq)
        {
            return EquipmentRepository.Instance.Update(eq);
        }

        public bool Delete(string eqID)
        {
            return EquipmentRepository.Instance.Delete(eqID);
        }

        public List<Equipment> GetEquipmentByEqType(EquipmentType type)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (var eq in GetAllToList())
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
