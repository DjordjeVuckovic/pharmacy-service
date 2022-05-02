using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class Notification
    {
        public string Author { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
        public string ID { get; set; }
        public List<string> Target { get; set; }
        public bool CheckStatus { get; set; }
        public NotifType NotificationType { get; set; }

        public Notification()
        {

        }

        public Notification(string author, DateTime time, string content, List<string> target)
        {
            Author = author;
            Time = time;
            Content = content;
            ID = author + time.ToString("yyMMddHHmmssffffff");
            Target = target;
        }
        public Notification(string author, DateTime time, string content, List<string> target, bool checkStatus, NotifType notificationType)
        {
            Author = author;
            Time = time;
            Content = content;
            ID = author + time.ToString("yyMMddHHmmssffffff");
            Target = target;
            CheckStatus = checkStatus;
            NotificationType = notificationType;
        }

        [JsonIgnore]
        public string DateAndTimeString => Time.ToString("dd.MM.yyyy. HH:mm");

        [JsonIgnore]
        public string AuthorUppercase => Author.ToUpper();

        [JsonIgnore]
        public string VaryingTimeString
        {
            get
            {
                return Time.Date == (DateTime.Today) ? Time.ToString("HH:mm") : Time.ToString("dd.MM.yyyy.");
            }
        }

        public bool ContainsTarget(string target)
        {
            foreach (string s in Target)
            {
                if (s.Equals(target))
                {
                    return true;
                }
            }
            return false;
        }

        public bool GetIfPast()
        {
            DateTime currentTime = DateTime.Now;
            return currentTime >= Time;
        }

    }
}