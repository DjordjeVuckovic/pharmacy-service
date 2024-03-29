﻿using System;
using TechHealth.Model;
using TechHealth.Repository.IRepository;
using TechHealth.Service.IService;

namespace TechHealth.Repository
{
    public class TherapyRepository : GenericRepository<string, Therapy>,ITherapyRepository
    {
        private static readonly TherapyRepository instance = new TherapyRepository();

        static TherapyRepository()
        {
        }

        private TherapyRepository()
        {
        }

        public static TherapyRepository Instance => instance;



        protected override string GetPath()
        {
            return @"../../Json/therapy.json";
        }

        protected override string GetKey(Therapy entity)
        {
            return entity.TherapyId;
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(Therapy entity)
        {
            entity.ShouldSerialize = true;
            entity.Appointment.ShouldSerialize = false;
        }
    }
}