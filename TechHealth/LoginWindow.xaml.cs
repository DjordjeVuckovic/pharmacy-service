using System;
using System.Linq;
using System.Windows;
using TechHealth.Model;
using TechHealth.View.DoctorView;

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
            if (password.Password.SequenceEqual("doc") && password.Password.SequenceEqual("doc"))
            {
                new DoctorMainWindow().Show();
                Close();
            }
            else if (password.Password.SequenceEqual("sec") && password.Password.SequenceEqual("sec"))
            {
                //
            }
            if (password.Password.SequenceEqual("pat") && password.Password.SequenceEqual("pat"))
            {
                //
            }
            if (password.Password.SequenceEqual("mng") && password.Password.SequenceEqual("mng"))
            {
                //
            }
            else
            {
                MessageBox.Show("User doesnt exist!");
            }
        }
    }
}