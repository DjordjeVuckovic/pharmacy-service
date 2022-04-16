// File:    AccountController.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:16:56 PM
// Purpose: Definition of Class AccountController

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
   public class PatientController
   {
        private PatientService patientService = new PatientService();
      
      public User GetByUsername(string username)
      {
         throw new NotImplementedException();
      }
      
      public List<Patient> GetAll()
      {
         throw new NotImplementedException();
      }

      public bool Create(string name, string surname, Address address, Doctor chosenDoctor, string jmbg, int lbo, bool isBanned, string username, string password, string email, bool employed, bool guest, string phone)
      {
            var patient = new Patient();

            patient.Name = name;
            patient.Surname = surname;
            patient.Address = address;
            patient.ChosenDoctor = chosenDoctor;
            patient.Jmbg = jmbg;
            patient.Lbo = lbo;
            patient.IsBanned = isBanned;
            patient.Username = username;
            patient.Password = password;
            patient.Email = email;
            patient.Employed = employed;
            patient.Guest = guest;
            patient.Phone = phone;

            return patientService.Create(patient);
      }
      
      public bool Update(string name, string surname, Address address, Doctor chosenDoctor, string jmbg, int lbo, bool isBanned, string username, string password, string email, bool employed, bool guest, string phone)
      {
            var patient = new Patient();

            patient.Name = name;
            patient.Surname = surname;
            patient.Address = address;
            patient.ChosenDoctor = chosenDoctor;
            patient.Jmbg = jmbg;
            patient.Lbo = lbo;
            patient.IsBanned = isBanned;
            patient.Username = username;
            patient.Password = password;
            patient.Email = email;
            patient.Employed = employed;
            patient.Guest = guest;
            patient.Phone = phone;

            return patientService.Update(patient);
        }
      
      public bool Delete(string personId)
      {
            return patientService.Delete(personId);
      }
      
      public bool CreateGuest(string userId, string password)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteGuest(string userId)
      {
         throw new NotImplementedException();
      }
      
      public int UpdateGuest(string userId, string password)
      {
         throw new NotImplementedException();
      }
   
   }
}