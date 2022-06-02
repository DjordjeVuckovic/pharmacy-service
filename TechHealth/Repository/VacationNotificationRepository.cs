using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class VacationNotificationRepository : GenericRepository<string, VacationNotification>
    {
        private static readonly VacationNotificationRepository instance = new VacationNotificationRepository();
        static VacationNotificationRepository()
        {
        }
        private VacationNotificationRepository()
        {
        }
        public static VacationNotificationRepository Instance => instance;
        protected override string GetKey(VacationNotification entity)
        {
            return entity.Id;
        }

        protected override string GetPath()
        {
            return @"../../Json/vacationNotification.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(VacationNotification entity)
        {
            entity.Doctor.ShouldSerialize = false;
        }
    }
}
