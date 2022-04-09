// File:    AccountRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:16:56 PM
// Purpose: Definition of Class AccountRepository

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;
using System.Windows.Documents;
using TechHealth.Model;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TechHealth.Repository
{
   public class AccountRepository
   {
      private List<User> users;
      
      public User GetByUsername(string username)
      {
         throw new NotImplementedException();
      }
      
      public List<User> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public void Create()
      {
         Address address1 = new Address
         {
            City = "Novi Sad",
            StreetNumber = "21",
            Country = "Srbija",
            Street = "Puse Pusica",
            Postcode = 21000
         };
         Doctor doctor = new Doctor()
         {
            Username = "doc",
            Password = "doc",
            Email = "doctor@doctor",
            Name = "Jack",
            Surname = "White",
            Jmbg = "1312",
            Employed = true,
            Phone = "061341",
            Address = address1
         };
         Doctor doctor1 = new Doctor()
         {
            Username = "doctor",
            Password = "doctor",
            Email = "doctor@doctor11",
            Name = "Slavica",
            Surname = "Cukteras",
            Jmbg = "1315",
            Employed = true,
            Phone = "061341",
            Address = address1
         };
         List<Doctor> doctors = new List<Doctor>();
         doctors.Add(doctor);
         doctors.Add(doctor1);
         string path = @"../../Json/doctor.json";
         string path1 = @"../../Json/sec.json";
         string jsonToWrite = System.Text.Json.JsonSerializer.Serialize(doctors);
         if (!File.Exists(path1))
         {
            File.Create(path1);
         }
         File.WriteAllText(path1,jsonToWrite);
         // using (StreamWriter writer = new StreamWriter(@".\..\..\..\JsonData\doctor.json"))
         //    
         // {
         //    writer.Write(jsonToWrite);
         // }
      }
      
      public bool Update(Person person)
      {
         throw new NotImplementedException();
      }
      
      public bool Delete(string username)
      {
         throw new NotImplementedException();
      }
      
      public bool CreateGuest(User user)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteGuest(string userId)
      {
         throw new NotImplementedException();
      }
      
      public int UpdateGuest(User user)
      {
         throw new NotImplementedException();
      }
      
      public FileHandler fileHandler;
   
   }
}