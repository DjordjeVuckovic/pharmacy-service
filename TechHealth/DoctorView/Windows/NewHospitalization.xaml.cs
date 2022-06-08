using System.Windows;
using TechHealth.Controller;

namespace TechHealth.DoctorView.Windows
{
    public partial class NewHospitalization : Window
    {
        private  readonly  RoomController roomController = new RoomController();
        public NewHospitalization()
        {
            InitializeComponent();
            DataContext = this;
            roomCombo.ItemsSource = roomController.GetAll();
        }

        private void Finish(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your are successfully created new hospitalization");
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}