using System.Windows;
using System.Windows.Controls;

namespace TechHealth.DoctorView.View
{
    public partial class TutorialView : UserControl
    {
        public TutorialView()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            MediaElement.Play();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
           MediaElement.Stop();
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            MediaElement.Pause();
        }
    }
}