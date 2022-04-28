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

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for ReallocateForm.xaml
    /// </summary>
    public partial class ReallocateForm : Window
    {
        public ReallocateForm()
        {
            InitializeComponent();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
