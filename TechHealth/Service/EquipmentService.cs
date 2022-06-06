using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class EquipmentService:IEquipmentService
    {
        public List<Equipment> GetAll()
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

        public Equipment GetById(string key)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string eqID)
        {
            return EquipmentRepository.Instance.Delete(eqID);
        }

        public List<Equipment> GetEquipmentByEqType(EquipmentType type)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (var eq in GetAll())
            {
                if (eq.Type == type)
                {
                    equipmentList.Add(eq);
                }
            }
            return equipmentList;
        }

        public bool UpdateEquipmentQuantityIfItExists(List<Equipment> eqList, Equipment equipment)
        {
            bool createEq = true;
            foreach (var eq in eqList)
            {
                if (eq.Name == equipment.Name)
                {
                    eq.Quantity += equipment.Quantity;
                    Update(eq);
                    createEq = false;
                }
            }
            return createEq;
        }
    }
}
