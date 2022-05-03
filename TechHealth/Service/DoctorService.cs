// File:    DoctorService.cs
// Author:  djord
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class DoctorService

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class DoctorService
    {

        public Doctor GetById(string doctorId)
        {
            return DoctorRepository.Instance.GetDoctorbyId(doctorId);
        }

        public List<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorsForExamination()
        {
            List<Doctor> doctorsForExamination = GetAll();
            for (int i = 0; i < doctorsForExamination.Count; i++)
            {
                if (doctorsForExamination[i].Specialization != SpecializationRepository.Instance.GetById(0)) //da li je ovo specijalizacija = 0 odnosno general
                {
                    doctorsForExamination.RemoveAt(i);
                    i--;
                }
            }

            return doctorsForExamination;
        }

        public List<Doctor> GetAllGeneral()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllSpecialist()
        {
            throw new NotImplementedException();
        }

        public List<string> GetExaminationDoctorsID()
        {
            List<string> ids = new List<string>();
            List<Doctor> lekari = GetDoctorsForExamination();
            foreach (Doctor l in lekari)
            {
                ids.Add(l.Jmbg);
            }
            return ids;
        }

    }
}