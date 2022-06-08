using System.Collections.Generic;
using TechHealth.Exceptions;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class PrescribeMedicineService:IPrescribeMedicineService
    {
        public bool Create(Prescription prescription)
        {
            return  PrescribeMedicineRepository.Instance.Create(prescription);
        }

        public bool Update(Prescription entity)
        {
            throw new System.NotImplementedException();
        }

        public Prescription GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckAllergens(Medicine medicine, Patient patient)
        {
            bool isAllergic = false;
            foreach (var substance in medicine.Composition)
            {
                if (CompareAllergens(substance.SubstanceName, patient))
                {
                    isAllergic = true;
                }
            }

            return isAllergic;
        }

        private bool CompareAllergens(string allergen,Patient patient)
        {
            bool isAllergic = false;
            foreach (var allergenCompare in PatientAllergensRepository.Instance.PatientAllergensList(patient.Jmbg))
            {
                if (allergenCompare.Equals(allergen))
                {
                    isAllergic = true;
                    break;
                }
            }

            return isAllergic;
        }

        public List<Prescription> GetAll()
        {
            List<Prescription> allPrescriptions =  PrescribeMedicineRepository.Instance.GetAllToList();
            BindDataForAppointments(allPrescriptions);
            BindDataForMedicine(allPrescriptions);
            return allPrescriptions;
        }

        public List<Prescription> GetAllByPatientId(string id)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (var prescription in GetAll())
            {
                
                    if (prescription.Appointment != null && prescription.Appointment.Patient.Jmbg.Equals(id))
                    {
                        prescriptions.Add(prescription);
                        BindDataForAppointment(prescription.Appointment);
                    }
            }
            return prescriptions;
        }
        private void BindDataForAppointments(List<Prescription> prescriptions)
        {
            foreach (var prescription1 in prescriptions)
            {
                prescription1.Appointment = AppointmentRepository.Instance.GetById(prescription1.Appointment.IdAppointment);   
            }
        }
        private void BindDataForMedicine(List<Prescription> prescriptions)
        {
            foreach (var prescription1 in prescriptions)
            {
                prescription1.Medicine = MedicineRepository.Instance.GetById(prescription1.Medicine.MedicineId);   
            }
        }
        private void BindDataForAppointment(Appointment appointment) => appointment.Doctor = DoctorRepository.Instance.GetDoctorById(appointment.Doctor.Jmbg);
    }
}