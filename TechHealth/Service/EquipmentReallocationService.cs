using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.DTO;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class EquipmentReallocationService
    {
        public bool Create(EquipmentReallocationDTO dto)
        {
            return EquipmentReallocationRepository.Instance.Create(dto);
        }
    }
}
