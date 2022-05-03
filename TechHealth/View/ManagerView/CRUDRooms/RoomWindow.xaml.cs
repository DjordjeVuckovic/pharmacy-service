using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Controller;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    public partial class RoomWindow : Window
    {
        private ObservableCollection<Room> rooms;

        private RoomController roomController = new RoomController();

        public ObservableCollection<Room> Rooms { get => rooms; set => rooms = value; }

        public RoomWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            rooms = new ObservableCollection<Room>(RoomRepository.Instance.GetAll().Values);
            //lvUsers.ItemsSource = rooms;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            new AddForm(rooms).ShowDialog();
            UpdateView();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedIndex == -1)
            {
                MessageBox.Show("You have to select a room before viewing it!");
            }
            else
            {
                Room selected = (Room)lvUsers.SelectedItems[0];
                roomController.Delete(selected.roomId);
                rooms = new ObservableCollection<Room>(RoomRepository.Instance.GetAll().Values);
                lvUsers.ItemsSource = rooms;
            }
        }

        private void Button_Click_View(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedIndex == -1)
            {
                MessageBox.Show("You have to select a room before viewing it!");
            }
            else
            {
                Room room = (Room)lvUsers.SelectedItems[0];
                new UpdateForm(room).ShowDialog();
                UpdateView();
            }

        }

        public void UpdateView()
        {
            rooms.Clear();
            foreach (var r in RoomRepository.Instance.GetAll().Values)
            {
                rooms.Add(r);
            }
        }
    }
}
