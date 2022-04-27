using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TechHealth.Annotations;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for RoomInventory.xaml
    /// </summary>
    public partial class RoomInventory : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Equipment> eqList;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Equipment> EqList
        {
            get 
            {
                return eqList;
            }

            set
            {
                eqList = value;
                OnPropertyChanged(nameof(EqList));
            }
        }
        public RoomInventory(Room room)
        {
            InitializeComponent();
            DataContext = this;
            eqList = new ObservableCollection<Equipment>(EquipmentRepository.Instance.GetEqListByRoomID(room.roomId));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
