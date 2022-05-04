// File:    PatientRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class PatientRepository

using System;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class PatientRepository : GenericRepository<string, Patient>
    {
        private static readonly PatientRepository instance = new PatientRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static PatientRepository()
        {
        }

        private PatientRepository()
        {
        }

        public static PatientRepository Instance => instance;

        protected override string GetPath()
        {
            return @"../../Json/patient.json";
        }

        protected override string GetKey(Patient entity)
        {
            return entity.Jmbg;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(Patient entity)
        {
            entity.ShouldSerialize = true;
        }

        public Patient GetPatientById(string id)
        {
            foreach (var pat in GetAllToList())
            {
                if (pat.Jmbg.Equals(id))
                {
                    return pat;
                }
            }
            return null;
        }

        public Patient GetPatientByUser(string user)
        {
            foreach (var pat in GetAllToList())
            {
                if (pat.Username.Equals(user))
                {
                    return pat;
                }
            }
            return null;
        }

    }
}