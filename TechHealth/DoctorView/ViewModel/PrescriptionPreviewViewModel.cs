using System;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class PrescriptionPreviewViewModel:ViewModelBase
    {
        public string PatientName { get; set; }
        private readonly  MedicineController medicineController = new MedicineController();
        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly DoctorController doctorController = new DoctorController();
        private Prescription prescription;
        private Medicine medicine;
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Frequency { get; set; }
        public string MedicineName { get; set; }
        public string MedicineId { get; set; }
        public string MedicineSide { get; set; }
        public string MedicineAlg { get; set; }
        public string Usage { get; set; }
        public string DoctorName { get; set; }
        public string RoomID { get; set; }
        


        public PrescriptionPreviewViewModel(Patient selectedPatient, Prescription selectedPrescription)
        {
            PatientName ="Patient: " +   selectedPatient.FullName;
            prescription = selectedPrescription;
            var appointment = appointmentController.GetById(prescription.Appointment.IdAppointment);
            var doctor = doctorController.GetById(appointment.Doctor.Jmbg);
            DoctorName = "Doctor: " +doctor.FullSpecialization;
            RoomID = "AppointmentRoom: " + appointment.Room.RoomId;
            StartDate = prescription.StartDate;
            FinishDate = prescription.FinishDate;
            medicine = medicineController.GetById(prescription.Medicine.MedicineId);
            Frequency = prescription.Frequency;
            MedicineName = medicine.MedicineName;
            MedicineId = medicine.MedicineId;
            MedicineSide = medicine.SideEffects;
            MedicineAlg = medicine.MedicineSubstances;
            Usage = prescription.Usage;
            Frequency = prescription.Frequency;
        }
    }
}