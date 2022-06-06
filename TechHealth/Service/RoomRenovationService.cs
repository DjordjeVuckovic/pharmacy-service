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
    public class RoomRenovationService:IRoomRenovationService
    {
        public List<RoomRenovation> GetAll()
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

        public RoomRenovation GetById(string key)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string renovationId)
        {
            return RoomRenovationRepository.Instance.Delete(renovationId);
        }
        public RoomRenovation GetRrByRoomID(string roomID)
        {
            RoomRenovation r = new RoomRenovation();
            foreach (var rr in GetAll())
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
            if (GetAll().Count != 0)
            {
                foreach (var rr in GetAll())
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
            if (GetAll().Count != 0)
            {
                foreach (var rr in GetAll())
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
