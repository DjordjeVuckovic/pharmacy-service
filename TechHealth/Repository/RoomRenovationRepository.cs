using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class RoomRenovationRepository : GenericRepository<string, RoomRenovation>
    {
        private static readonly RoomRenovationRepository instance = new RoomRenovationRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RoomRenovationRepository()
        {
        }

        private RoomRenovationRepository()
        {
        }

        public static RoomRenovationRepository Instance => instance;
        protected override string GetKey(RoomRenovation entity)
        {
            return entity.RenovationID;
        }

        protected override string GetPath()
        {
            return @"../../Json/roomRenovation.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(RoomRenovation entity)
        {
            entity.ShouldSerialize = true;
        }

        public RoomRenovation GetRrByRoomID(string roomID)
        {
            RoomRenovation r = new RoomRenovation();
            foreach (var rr in GetAllToList())
            {
                if (rr.RoomID == roomID)
                {
                    r = rr;
                    break;
                }
            }
            return r;
        }

        public bool ExistsInRenovations(string roomID)
        {
            if (GetAllToList().Count != 0)
            {
                foreach (var rr in GetAllToList())
                {
                    if (rr.RoomID == roomID)
                    {
                        return false;
                    }
                }
                return true;
            }
            else return true;
        }

        public bool IsValidDate(DateTime? date, string src, string dst)
        {
            if (GetAllToList().Count != 0)
            {
                foreach (var rr in GetAllToList())
                {
                    if (rr.RoomID == src || rr.RoomID == dst)
                    {
                        if (date >= rr.RenovationStart && date <= rr.RenovationEnd)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else return true;
        }
    }
}
