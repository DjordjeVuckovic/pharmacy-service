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
            return doctorService.GetAll();
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
        public bool Delete(string key)
        {
            return doctorService.Delete(key);
        }

        public  List<Doctor> GetAllBySpecializationId(int id) => doctorService.GetAllBySpecializationId(id);

        void IController<Doctor, string>.Delete(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}