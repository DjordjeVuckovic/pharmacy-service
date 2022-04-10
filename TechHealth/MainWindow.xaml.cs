using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TechHealth.View.ManagerView;

namespace TechHealth
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Equipment eq = new Equipment()
            //{
            //    name = "bandazeri",
            //    id = "101",
            //    quantity = 30,
            //    type = "staticka"
            //};

            //Equipment eq1 = new Equipment()
            //{
            //    name = "gaze",
            //    id = "200",
            //    quantity = 30,
            //    type = "staticka"
            //};

            //List<Equipment> equip = new List<Equipment>();
            //equip.Add(eq);         
            //Room room = new Room()
            //{
            //    roomId = "soba1",
            //    floor = 1,
            //    availability = true,
            //    roomTypes = RoomTypes.rest,
                
            //};

            //Room room1 = new Room()
            //{
            //    roomId = "soba2",
            //    floor = 1,
            //    availability = true,
            //    roomTypes = RoomTypes.operation

            //};
            //room1.Add(eq);
            //room1.Add(eq1);
            //RoomRepository.Instance.Create(room);
            //RoomRepository.Instance.Create(room1);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
            
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new ManagerMainWindow().Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            new LoginWindow().Show();
            this.Close();

        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            

            InitializeComponent();
        }
    }
}
