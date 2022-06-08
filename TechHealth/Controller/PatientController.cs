using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class PatientController
    {
        private readonly PatientService patientService = new PatientService();
        public List<Patient> GetAll()
        {
            return PatientRepository.Instance.GetAllToList();
        }
        public bool CheckAvailability(string jmbg, string username)
        {
            return patientService.CheckAvailability(jmbg, username);
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

        public Patient GetByPatientId(string patientId)
        {
            return patientService.GetById(patientId);
        }

    }
}