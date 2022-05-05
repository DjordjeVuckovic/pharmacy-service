using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class PrescribeMedicineService
    {
        public bool Create(Prescription prescription)
        {
            return  PrescribeMedicineRepository.Instance.Create(prescription);
        }

        public List<Prescription> GetAll()
        {
            return PrescribeMedicineRepository.Instance.GetAllToList();
        }

        public List<Prescription> GetAllByPatientId(string id)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            List<Prescription> allPrescription = GetAll();
            BindDataForAppointments(allPrescription);
            BindDataForMedicine(allPrescription);
            foreach (var prescription in allPrescription)
            {
                if (prescription.Appointment != null)
                {
                    if (prescription.Appointment.Patient.Jmbg.Equals(id))
                    {
                        prescriptions.Add(prescription);
                        BindDataForAppointment(prescription.Appointment);
                    }
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
        private void BindDataForAppointment(Appointment appointment)
        {
            appointment.Doctor = DoctorRepository.Instance.GetDoctorbyId(appointment.Doctor.Jmbg);
        }
    }
}