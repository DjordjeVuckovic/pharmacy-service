using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class SecretaryNotification
    {
        public string Id { get; set; }
        public Person Person { get; set; }
        public string NotificationText { get; set; }
        public SecretaryNotification()
        {

        }
    }
}
