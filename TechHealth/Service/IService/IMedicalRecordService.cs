using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IMedicalRecordService:IService<MedicalRecord,string>

    {
        MedicalRecord GetByPatientId(string patientId);

    }
}