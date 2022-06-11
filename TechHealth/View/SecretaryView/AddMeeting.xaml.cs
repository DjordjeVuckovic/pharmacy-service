using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Controller;
using System.Collections.ObjectModel;

namespace TechHealth.View.SecretaryView
{
    public partial class AddMeeting : Window
    {
        private MeetingController meetingController = new MeetingController();
        private List<Room> rooms = new List<Room>();
        private DateTime d;
        private Meeting meeting = new Meeting();
        private SecretaryNotification secretaryNotification = new SecretaryNotification();
        private SecretaryNotificationController secretaryNotificationController = new SecretaryNotificationController();
        public AddMeeting(DateTime date)
        {
            InitializeComponent();
            d = date;
            foreach (var r in RoomRepository.Instance.GetAll().Values)
            {
                if (!r.RoomId.Equals("Warehouse"))
                {
                    rooms.Add(r);
                }
            }
            List<String> roomsForCombo = new List<String>();
            foreach (var r in rooms)
            {
                roomsForCombo.Add(r.RoomId);
            }
            roomCombo.ItemsSource = roomsForCombo;

            List<String> attendantsNames = new List<String>();
            foreach (var s in SecretaryRepository.Instance.GetAll().Values)
            {
                attendantsNames.Add(s.FullName);
            }
            foreach (var d in DoctorRepository.Instance.GetAll().Values)
            {
                attendantsNames.Add(d.FullSpecialization);
            }
            foreach (var m in ManagerRepository.Instance.GetAll().Values)
            {
                attendantsNames.Add(m.FullName);
            }
            attendantsList.ItemsSource = attendantsNames;
        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            List<Person> lista = new List<Person>();
            foreach (var s in attendantsList.SelectedItems)
            {
                foreach (var d in DoctorRepository.Instance.GetAll().Values)
                {
                    if (s.Equals(d.FullSpecialization))
                    {
                        lista.Add(d);
                        break;
                    }
                }
                foreach (var sec in SecretaryRepository.Instance.GetAll().Values)
                {
                    if (s.Equals(sec.FullName))
                    {
                        lista.Add(sec);
                        break;
                    }
                }
                foreach (var m in ManagerRepository.Instance.GetAll().Values)
                {
                    if (s.Equals(m.FullName))
                    {
                        lista.Add(m);
                        break;
                    }
                }
            }
            if (lista.Count == 0 || roomCombo.SelectedItem == null || datePick.SelectedDate == null || timePickerStart.SelectedTime == null || timePickerEnd.SelectedTime == null)
            {
                MessageBox.Show("Fill out all the fields.");
                return;
            }
            if (lista.Count < 2)
            {
                MessageBox.Show("Meeting has to have more than one person.");
                return;
            }

            GenerateMeeting(lista);

            if (DateTime.Compare(meeting.FinishTime, meeting.StartTime) == 0)
            {
                MessageBox.Show("Start time and finish time cannot be equal.");
                return;
            }
            if (DateTime.Compare(meeting.StartTime, meeting.FinishTime) > 0)
            {
                MessageBox.Show("Finish time cannot be before start time.");
                return;
            }

            if (!meetingController.CheckAttendants(meeting) || !meetingController.CheckRoom(meeting)){ return; }

            meetingController.Create(meeting);
            SendNotifications(lista);
            new MeetingsView(d).Show();
            Close();
        }
        private void SendNotifications(List<Person> attendants)
        {
            foreach (var a in attendants)
            {
                GenerateNotification(a);
                secretaryNotificationController.Create(secretaryNotification);
            }
        }
        private void GenerateNotification(Person p)
        {
            secretaryNotification.Id = Guid.NewGuid().ToString("N");
            secretaryNotification.Person = p;
            secretaryNotification.NotificationText = "Meeting scheduled: " + DateTime.Parse(datePick.Text).ToString("dd.MM.yyyy") + ", from " + DateTime.Parse(timePickerStart.Text.ToString()).ToString("HH:mm") + " to " + DateTime.Parse(timePickerEnd.Text).ToString("HH:mm") + ".";
        }
        private void GenerateMeeting(List<Person> attendants)
        {
            meeting.Id = Guid.NewGuid().ToString("N");
            meeting.Attendants = attendants;
            meeting.Date = DateTime.Parse(datePick.Text);
            meeting.StartTime = DateTime.Parse(timePickerStart.Text);
            meeting.FinishTime = DateTime.Parse(timePickerEnd.Text);
            meeting.Room = rooms[roomCombo.SelectedIndex];
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            new MeetingsView(d).Show();
            Close();
        }
        private void Button_Meetings(object sender, RoutedEventArgs e)
        {
            new MeetingsPickDate().Show();
            Close();
        }
        private void Button_Accounts(object sender, RoutedEventArgs e)
        {
            new AccountsView().Show();
            Close();
        }
        private void Button_Appointments(object sender, RoutedEventArgs e)
        {
            new AppointmentsPickDate().Show();
            Close();
        }
        private void Button_Equipment(object sender, RoutedEventArgs e)
        {
            new EquipmentRequestsView().Show();
            Close();
        }
        private void Button_EmergencyExamination(object sender, RoutedEventArgs e)
        {
            new EmergencyExamination().Show();
            Close();
        }
    }
}
