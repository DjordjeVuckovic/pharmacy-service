// File:    DoctorService.cs
// Author:  djord
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class DoctorService

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
   public class DoctorService:IDoctorService
   {
      public bool Update(Doctor entity)
      {
         throw new NotImplementedException();
      }

      public Doctor GetById(string doctorId)
      {
         return  DoctorRepository.Instance.GetDoctorbyId(doctorId);
         
      }

      public bool Delete(string key)
      {
         throw new NotImplementedException();
      }

      public List<Doctor> GetAllBySpecializationId(int id)
      {
         List<Doctor> returnList = new List<Doctor>();
         foreach (var doctor in GetAll())
         {
            if (doctor.Specialization.IdSpecialization == id)
            {
               returnList.Add(doctor);
            }  
         }

         return returnList;
      }
      
      public List<Doctor> GetAll()
      {
        return DoctorRepository.Instance.GetAllToList();
      }

      public bool Create(Doctor entity)
      {
         throw new NotImplementedException();
      }
   }
}