// File:    RoomRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:14:41 PM
// Purpose: Definition of Class RoomRepository

using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class RoomRepository : GenericRepository<string, Room>
    {
        private static readonly RoomRepository instance = new RoomRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RoomRepository()
        {
        }

        private RoomRepository()
        {
        }

        public static RoomRepository Instance => instance;

        protected override string GetPath()
        {
            return @"../../Json/room.json";
        }

        protected override string GetKey(Room entity)
        {
            return entity.roomId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(Room entity)
        {
            entity.ShouldSerialize = true;
        }

        public List<String> GetRoomIDs()
        {
            List<String> roomIDs = new List<String>();

            foreach (var room in GetAllToList())
            {
                roomIDs.Add(room.roomId);
            }

            return roomIDs;
        }

        public List<String> GetRoomNames()
        {
            List<String> roomNames = new List<String>();

            foreach (var room in GetAllToList())
            {
                roomNames.Add(room.roomId);
            }

            return roomNames;
        }

        public List<String> GetRoomNames(List<Room> rooms)
        {
            List<String> roomNames = new List<String>();

            foreach (var room in rooms)
            {
                roomNames.Add(room.roomId);
            }

            return roomNames;
        }

        public bool WarehouseExists()
        {
            foreach (var room in GetAllToList())
            {
                if (room.roomTypes == RoomTypes.warehouse)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Room> UcitajProstorijeZaPreglede()
        {
            List<Room> prostorije = GetAllToList();
            for (int i = 0; i < prostorije.Count; i++)
            {
                if (prostorije[i].roomTypes != RoomTypes.examination || prostorije[i].availability == false)
                {
                    prostorije.RemoveAt(i);
                    i--;
                }
            }
            return prostorije;
        }

        public List<Room> GetAvailableRooms(DateTime appointmentTime)
        {
            List<Room> examRooms = RoomRepository.Instance.UcitajProstorijeZaPreglede();
            foreach (Appointment termin in AppointmentRepository.Instance.GetAllToList())
            {
                if (termin.EqualDate(appointmentTime))
                {
                    RemoveRoom(termin.Room.roomId, examRooms);
                }
            }
            return examRooms;
        }

        private void RemoveRoom(string number, List<Room> examRooms)
        {
            for (int i = 0; i < examRooms.Count; i++)
            {
                if (examRooms[i].roomId == number || examRooms[i].availability == false)
                {
                    examRooms.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
