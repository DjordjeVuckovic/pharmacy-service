using System.Linq;
using System.Windows;

namespace TechHealth
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           if(password.Password.SequenceEqual("doctor") && password.Password.SequenceEqual("doctor")){}
           
        }
    }
}