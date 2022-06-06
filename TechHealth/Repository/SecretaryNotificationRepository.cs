using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class SecretaryNotificationRepository : GenericRepository<string, SecretaryNotification>
    {
        private static readonly SecretaryNotificationRepository instance = new SecretaryNotificationRepository();
        static SecretaryNotificationRepository()
        {
        }
        private SecretaryNotificationRepository()
        {
        }
        public static SecretaryNotificationRepository Instance => instance;
        protected override string GetKey(SecretaryNotification entity)
        {
            return entity.Id;
        }
        


        protected override string GetPath()
        {
            return @"../../Json/secretaryNotification.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(SecretaryNotification entity)
        {
            entity.Person.ShouldSerialize = false;
        }
    }
}
