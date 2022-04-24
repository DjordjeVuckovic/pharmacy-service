// File:    RoomController.cs
// Author:  djord
// Created: Thursday, April 7, 2022 6:14:41 PM
// Purpose: Definition of Class RoomController

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
   public class RoomController
   {
        private RoomService roomService = new RoomService();
      
      public Room GetById(string roomId)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public bool Create(string roomId, int floor, bool available, RoomTypes type)
      {
            var room = new Room();
            room.roomId = roomId;
            room.floor = floor;
            room.availability = available;
            room.RoomTypes = type;

            return roomService.Create(room);
      }

        public bool Create(Room room)
        {
            return roomService.Create(room);
        }
      
      public bool Update(string roomId, int floor, bool available, RoomTypes type)
      {
            var room = new Room();
            room.roomId = roomId;
            room.floor = floor;
            room.availability = available;
            room.RoomTypes = type;

            return roomService.Update(room);
        }
      
      public bool Delete(string roomId)
      {
            return roomService.Delete(roomId);
      }
   
   }
}