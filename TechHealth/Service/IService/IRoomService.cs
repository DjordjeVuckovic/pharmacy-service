using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IRoomService:IService<Room,string>
    {
        List<String> GetRoomIDs();
        List<String> GetRoomNames();
        bool WarehouseExists();
        Room GetRoombyId(string idr);

    }
}