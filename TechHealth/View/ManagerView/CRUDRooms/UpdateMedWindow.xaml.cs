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
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for UpdateMedWindow.xaml
    /// </summary>
    public partial class UpdateMedWindow : Window
    {
        private Medicine selected = new Medicine();
        private MedicineController medicineController = new MedicineController();
        public UpdateMedWindow(Medicine med)
        {
            selected = med;
            InitializeComponent();
            TxtMedName.Text = selected.MedicineName;
            TxtMainSubstance.Text = selected.MainSubstance.SubstanceName.ToString();
            TxtQuantity.Text = selected.Quantity.ToString();
            TxtUnits.Text = selected.Units;
            TxtSideEffects.Text = selected.SideEffects;

        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            Medicine medicine = new Medicine();
            medicine.MedicineId = selected.MedicineId;
            medicine.MedicineName = TxtMedName.Text;
            medicine.MainSubstance = ManagerConversions.StringToSubstance(TxtMainSubstance.Text);
            medicine.Quantity = Int32.Parse(TxtQuantity.Text);
            medicine.Units = TxtUnits.Text;
            medicine.SideEffects = TxtSideEffects.Text;
            medicine.MedicineStatus = MedicineStatus.Waiting;
            medicine.Composition = selected.Composition;
            medicine.Price = selected.Price;

            medicineController.Update(medicine);

            this.Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
