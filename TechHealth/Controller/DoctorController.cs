using System.Collections.Generic;
using TechHealth.Controller.IController;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class DoctorController:IDoctorController
    {
        private readonly IDoctorService doctorService = new DoctorService();

        public List<Doctor> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Create(Doctor entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Doctor entity)
        {
            throw new System.NotImplementedException();
        }

        public Doctor GetById(string doctorId) => doctorService.GetById(doctorId);
        public void Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public  List<Doctor> GetAllBySpecializationId(int id) => doctorService.GetAllBySpecializationId(id);
    }
}