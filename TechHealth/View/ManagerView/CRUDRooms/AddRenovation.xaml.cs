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

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for AddRenovation.xaml
    /// </summary>
    public partial class AddRenovation : Window
    {
        private List<String> rooms;
        private Room selected;
        public AddRenovation(Room rm)
        {
            InitializeComponent();
            selected = rm;
            rooms = RoomRepository.Instance.GetRoomIDs();
            TxtRoomID.Text = selected.roomId;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            RoomRenovation rr = new RoomRenovation();
            rr.RoomID = selected.roomId;
            rr.RenovationStart = RStart.SelectedDate;
            rr.RenovationEnd = REnd.SelectedDate;
            rr.RenovationID = Guid.NewGuid().ToString("N");

            if (RoomRenovationRepository.Instance.ExistsInRenovations(selected.roomId))
            {
                if (AppointmentRepository.Instance.CanSetRenovation(rr.RenovationStart, rr.RenovationEnd, rr.RoomID))
                {
                    RoomRenovationRepository.Instance.Create(rr);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is an appointment scheduled in that period!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("This room already has scheduled renovation!");
                return;
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
