// File:    SecretaryRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class SecretaryRepository

using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
   public class SecretaryRepository
   {
      private List<Secretary> secretaries;
      
      public Secretary GetById(string secretaryId)
      {
         throw new NotImplementedException();
      }
      
      public List<Secretary> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public FileHandler fileHandler;
   
   }
}