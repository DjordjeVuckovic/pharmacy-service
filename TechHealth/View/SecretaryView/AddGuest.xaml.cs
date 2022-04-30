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
using TechHealth.Controller;
using TechHealth.Repository;

namespace TechHealth.View.SecretaryView
{
    public partial class AddGuest : Window
    {
        private PatientController patientController = new PatientController();
        public AddGuest()
        {
            InitializeComponent();
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            int guestId = 1;
            foreach (var p in PatientRepository.Instance.GetAll().Values)
            {
                if (p.Guest)
                {
                    string str = p.Jmbg.Remove(0, 5);
                    if (guestId != Int32.Parse(str))
                    {
                        break;
                    }
                    else
                    {
                        guestId++;
                    }
                }
            }
            patientController.Create("", "", null, null, "guest" + guestId.ToString(), 0, false, guestUsername.Text, guestPassword.Text, "", false, true, "");
            guestId++;
            this.Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
