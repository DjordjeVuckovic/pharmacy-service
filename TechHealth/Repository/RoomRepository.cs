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

            foreach (var room in DictionaryValuesToList())
            {
                roomIDs.Add(room.roomId);
            }
            return roomIDs;
        }

        public List<String> GetRoomNames()
        {
            List<String> roomNames = new List<String>();

            foreach (var room in DictionaryValuesToList())
            {
                roomNames.Add(room.roomId);
            }
            return roomNames;
        }
    }
}