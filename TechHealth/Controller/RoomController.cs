// File:    RoomController.cs
// Author:  djord
// Created: Thursday, April 7, 2022 6:14:41 PM
// Purpose: Definition of Class RoomController

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
   public class RoomController
   {
        private readonly IRoomService roomService = new RoomService();

        public Room GetById(string roomId) => roomService.GetById(roomId);

        public List<Room> GetAll() => roomService.GetAll();

        public bool Create(string roomId, int floor, bool available, RoomTypes type)
        {
            var room = new Room();
            room.RoomId = roomId;
            room.Floor = floor;
            room.Availability = available;
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
            room.RoomId = roomId;
            room.Floor = floor;
            room.Availability = available;
            room.RoomTypes = type;

            return roomService.Update(room);
        }
        public bool Update(Room room)
        {
            return roomService.Update(room);
        }

        public bool Delete(string roomId)
        {
            return roomService.Delete(roomId);
        }

        public Room GetRoombyId(string idr)
        {
            return roomService.GetRoombyId(idr);
        }

        public List<String> GetRoomIDs()
        {
            return roomService.GetRoomIDs();
        }

        public List<String> GetRoomNames()
        {
            return roomService.GetRoomNames();
        }

        public bool WarehouseExists()
        {
            return roomService.WarehouseExists();
        }
    }
}