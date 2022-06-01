using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class RoomRenovationService
    {
        public List<RoomRenovation> GetAllToList()
        {
            return RoomRenovationRepository.Instance.GetAllToList();
        }
        public bool Create(RoomRenovation rr)
        {
            return RoomRenovationRepository.Instance.Create(rr);
        }

        public bool Update(RoomRenovation rr)
        {
            return RoomRenovationRepository.Instance.Update(rr);
        }

        public bool Delete(string renovationId)
        {
            return RoomRenovationRepository.Instance.Delete(renovationId);
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

        public bool IsValidDate(DateTime date, string src, string dst)
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
