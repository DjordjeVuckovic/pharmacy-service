using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class EquipmentRepository : GenericRepository<string, Equipment>
    {
        private static readonly EquipmentRepository instance = new EquipmentRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static EquipmentRepository()
        {
        }

        private EquipmentRepository()
        {
        }

        public static EquipmentRepository Instance => instance;
        protected override string GetKey(Equipment entity)
        {
            return entity.id;
        }

        protected override string GetPath()
        {
            return @"../../Json/equipment.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }
    }
}
