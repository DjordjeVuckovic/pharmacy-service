using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class MeetingController
    {
        private readonly MeetingService meetingService = new MeetingService();
        public bool Create(Meeting meeting)
        {
            return meetingService.Create(meeting);
        }
        public bool Delete(string id)
        {
            return meetingService.Delete(id);
        }
        public bool CheckAttendants(Meeting meeting)
        {
            return meetingService.CheckAttendants(meeting);
        }
    }
}
