// File:    RoomService.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:14:41 PM
// Purpose: Definition of Class RoomService

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
   public class RoomService
   {
        private RoomEquipmentService roomEquipmentService = new RoomEquipmentService();
      public Room GetById(string roomId)
      {
          return RoomRepository.Instance.GetById(roomId);
      }
      
      public List<Room> GetAll()
      {
          return RoomRepository.Instance.GetAllToList();
      }
      
      public bool Create(Room room)
      {
            return RoomRepository.Instance.Create(room);
      }
      
      public bool Update(Room room)
      {
            return RoomRepository.Instance.Update(room);
      }
      
      public bool Delete(string roomId)
      {
            return RoomRepository.Instance.Delete(roomId);
      }

       public Room GetRoombyId(string idr)
       {
            Room r = new Room();
           foreach (var room in GetAll())
           {
               if (room.roomId.Equals(idr))
               {
                    r = room;
               }
           }
           return r;
       }

        public List<String> GetRoomIDs()
        {
            List<String> roomIDs = new List<String>();

            foreach (var room in GetAll())
            {
                roomIDs.Add(room.roomId);
            }

            return roomIDs;
        }

        public List<String> GetRoomNames()
        {
            List<String> roomNames = new List<String>();

            foreach (var room in GetAll())
            {
                roomNames.Add(room.roomId);
            }

            return roomNames;
        }

        public bool WarehouseExists()
        {
            bool exists = false;
            foreach (var room in GetAll())
            {
                if (room.roomTypes == RoomTypes.warehouse)
                {
                    exists = true;
                    break;
                }
            }
            return exists;
        }
    }
}