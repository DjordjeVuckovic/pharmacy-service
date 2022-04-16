using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TechHealth.View.ManagerView
{
    public partial class ManagerMainWindow : Window
    {
        private ObservableCollection<Room> rooms;
        private RoomController roomController = new RoomController();
        public ManagerMainWindow()
        {
            InitializeComponent();
            rooms = new ObservableCollection<Room>(RoomRepository.Instance.GetAll().Values);
            lvUsers.ItemsSource = rooms;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            new AddForm().ShowDialog();
            UpdateView();

        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Room selected = (Room)lvUsers.SelectedItems[0];
            roomController.Delete(selected.roomId);
            rooms = new ObservableCollection<Room>(RoomRepository.Instance.GetAll().Values);
            lvUsers.ItemsSource = rooms;
        }

        private void Button_Click_View(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedIndex == -1)
            {
                MessageBox.Show("You have to select a room before viewing it!");
            }
            Room room = (Room)lvUsers.SelectedItems[0];
            new UpdateForm(room).ShowDialog();
            UpdateView();
        }

        public void UpdateView()
        {
            rooms.Clear();
            foreach (var r in RoomRepository.Instance.GetAll().Values)
            {
                rooms.Add(r);
            }
        }

        private void lvUsers_SelectionChanged()
        {

        }

        private void lvUsers_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
