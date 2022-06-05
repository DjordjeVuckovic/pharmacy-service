using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class PatientNotificationRepository : GenericRepository<string, PatientNotification>
    {
        static PatientNotificationRepository()
        {
        }
        private PatientNotificationRepository()
        {
        }
        public static PatientNotificationRepository Instance { get; } = new PatientNotificationRepository();
        protected override string GetKey(PatientNotification entity)
        {
            return entity.Id;
        }

        protected override string GetPath()
        {
            return @"../../Json/patientNotification.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(PatientNotification entity)
        {
            entity.Person.ShouldSerialize = false;
        }
    }
}
