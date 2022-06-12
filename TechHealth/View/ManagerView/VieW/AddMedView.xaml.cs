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
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.Model;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for AddMedView.xaml
    /// </summary>
    public partial class AddMedView : UserControl
    {
        private MedicineController medicineController = new MedicineController();
        private SubstanceController substanceController = new SubstanceController();
        //private ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
        private ObservableCollection<Substance> substances = new ObservableCollection<Substance>();
        private List<string> substanceNames;
        private List<Substance> selectedSubstances;
        private List<string> possibleMainSubstances = new List<string>();
        public List<Substance> medSubstances { get; set; }
        public ObservableCollection<Substance> Substances
        {
            get { return substances; }
            set { substances = value; }
        }

        public AddMedView(/*ObservableCollection<Medicine> meds*/)
        {
            //medicines = meds;
            InitializeComponent();
            substances = new ObservableCollection<Substance>(substanceController.GetAllToList());
            substanceNames = substanceController.GetSubstanceNames();
            substanceList.ItemsSource = substanceNames;
            medSubstances = new List<Substance>();

            foreach (var s in substanceController.GetAllToList())
            {
                possibleMainSubstances.Add(s.SubstanceName);
            }
            CbMainSubstance.ItemsSource = possibleMainSubstances;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            var MedVm = new MedViewModel();

            Medicine med = new Medicine();
            med.MedicineId = Guid.NewGuid().ToString("N");
            med.MedicineName = TxtMedName.Text;
            try
            {
                med.Quantity = Int32.Parse(TxtQuantity.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Please enter a valid quantity!");
                return;
            }
            med.Units = TxtUnits.Text;
            med.SideEffects = TxtSideEffects.Text;
            med.MainSubstance = ManagerConversions.StringToSubstance(CbMainSubstance.Text);
            try
            {
                med.Price = Int32.Parse(TxtPrice.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Please enter a valid price!");
                return;
            }
            med.MedicineStatus = MedicineStatus.Waiting;


            var selectedItems = substanceList.SelectedItems;
            var collection = selectedItems.Cast<String>();
            var selectedCollection = collection.ToList();
            selectedSubstances = substanceController.GetSubstanceListFromNames(selectedCollection);
            substanceController.AddSubstancesToCompositionList(selectedSubstances, medSubstances);
            med.Composition = medSubstances;

            if (TxtMedName.Text == "" || CbMainSubstance.Text == "" || TxtQuantity.Text == "" || TxtPrice.Text == "" || TxtSideEffects.Text == "" || TxtUnits.Text == "")
            {
                MessageBox.Show("All fields have to be filled in order to proceed!");
                return;
            }

            if (med.Composition.Count == 0)
            {
                MessageBox.Show("You must add substances to medicine!");
                return;
            }

            medicineController.Create(med);
            //medicines.Add(med);

            MainViewModel.Instance().CurrentView = MedVm;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            var MedVm = new MedViewModel();
            MainViewModel.Instance().CurrentView = MedVm;
        }
    }
}
