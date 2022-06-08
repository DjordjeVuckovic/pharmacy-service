using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class MeetingService
    {
        public bool Create(Meeting meeting)
        {
            return MeetingRepository.Instance.Create(meeting);
        }
        public bool Delete(string id)
        {
            return MeetingRepository.Instance.Delete(id);
        }
        public bool CheckAttendants(Meeting meeting)
        {
            return MeetingRepository.Instance.CheckAttendants(meeting);
        }
    }
}
