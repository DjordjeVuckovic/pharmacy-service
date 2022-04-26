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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for EquipmentView.xaml
    /// </summary>
    public partial class EquipmentView : UserControl
    {
        private ObservableCollection<Equipment> eqlist;
        public ObservableCollection<Equipment> Equipment
        {
            get
            {
                return eqlist;
            }

            set
            {
                eqlist = value;
                //OnPropertyChanged();
            }
        }
        public EquipmentView()
        {
            InitializeComponent();
            DataContext = this;
            eqlist = new ObservableCollection<Equipment>(EquipmentRepository.Instance.DictionaryValuesToList());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Equipment eq = new Equipment
            {
                name = "jjyjyj",
                id = "4321",
                type = EquipmentType.dynamical,
                quantity = 1221,
                roomID = "gdfgdfg",
            };

            if (EquipmentRepository.Instance.Create(eq))
            {
                Equipment.Add(eq);
                MessageBox.Show("Uspesno dodata oprema!");
            }
            else MessageBox.Show("Nije uspelo dodavanje!");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataEquipment.SelectedIndex == -1)
            {
                MessageBox.Show("You have to select an item first!");
            }
            else
            {
                Equipment eq = (Equipment)dataEquipment.SelectedItem;
                EquipmentRepository.Instance.Delete(eq.id);
                Equipment.Remove(eq);
                MessageBox.Show("You have successfully deleted an equipment");
            }
        }
    }
}
