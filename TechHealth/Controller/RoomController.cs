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
      private RoomService roomService;
      
      public Room GetById(string roomId)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public bool Create(string roomId, string name, bool available, RoomTypes type)
      {
         throw new NotImplementedException();
      }
      
      public bool Update(string roomId, string name, bool available, RoomTypes type)
      {
         throw new NotImplementedException();
      }
      
      public bool Delete(string roomId)
      {
         throw new NotImplementedException();
      }
   
   }
}