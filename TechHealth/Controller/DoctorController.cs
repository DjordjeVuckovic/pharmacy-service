using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class DoctorController
    {
        private readonly IDoctorService doctorService = new DoctorService();

        public Doctor GetById(string doctorId)
        {
            return doctorService.GetById(doctorId);
        }

        public List<Doctor> GetAllBySpecializationId(int id)
        {
            return doctorService.GetAllBySpecializationId(id);
        }
    }
}