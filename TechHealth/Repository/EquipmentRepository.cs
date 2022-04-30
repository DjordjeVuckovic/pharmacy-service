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
            return entity.name;
        }

        protected override string GetPath()
        {
            return @"../../Json/equipment.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(Equipment entity)
        {
            entity.ShouldSerialize = true;
        }

        public List<String> GetEqNames()
        {
            List<String> eqNames = new List<String>();

            foreach (var eq in DictionaryValuesToList())
            {
                eqNames.Add(eq.name);
            }
            return eqNames;
        }

        public int GetEqIndex(string eqName, List<Equipment> eqList)
        {
            int index = 0;
            for (int i = 0; i < eqList.Count; i++)
            {
                if (eqList[i].name == eqName)
                {
                    index = i;
                    break;
                }
                i++;
            }
            return index;
        }

        public List<Equipment> GetEqListByRoomID(string roomID)
        {
            List<Equipment> eqList = new List<Equipment>();
            foreach (var eq in DictionaryValuesToList())
            {
                if (eq.roomID == roomID)
                {
                    eqList.Add(eq);
                }
            }
            return eqList;
        }

        public Equipment GetByEqName(string name)
        {
            Equipment eq = new Equipment();
            foreach (var v in DictionaryValuesToList())
            {
                if (v.name == name)
                {
                    eq = v;
                    break;
                }
            }
            return eq;
        }

        public List<Equipment> GetEqListByRoomEqList(List<RoomEquipment> re)
        {
            List<Equipment> eqList = new List<Equipment>();
            foreach (var r in re)
            {
                Equipment eq = GetByEqName(r.EquipmentName);
                eqList.Add(eq);
            }
            return eqList;
        }
    }
}
