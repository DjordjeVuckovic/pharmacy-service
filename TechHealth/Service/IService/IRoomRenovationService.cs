using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IRoomRenovationService:IService<RoomRenovation,string>
    {
        List<RoomRenovation> GetAll();
        RoomRenovation GetRrByRoomID(string roomID);
        bool ExistsInRenovations(string roomID);
        bool IsValidDate(DateTime date, string src, string dst);
    }
}