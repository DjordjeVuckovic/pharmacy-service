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
      //private RoomRepository roomRepository;
      
      public Room GetById(string roomId)
      {
         throw new NotImplementedException();
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
   
   }
}