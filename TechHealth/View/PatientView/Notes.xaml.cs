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
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Window
    {
        public string TTitle { get; set; }
        public DateTime DateReal { get; set; }
        private string Content { get; set; }
        private string Date { get; set; }
        private string Time { get; set; }
        public bool Checked { get; set; }
        public string noteId;
        public RelayCommand ConfirmCommand { get; set; }
        public RelayCommand RejectCommand { get; set; }
        NoteController noteController;
        private Visibility Vidljivost { get; set; }
        
        private string Patient { get; set; }
        private Appointment SelectedAppointment { get; set; }

        public Note Beleska { get; set; }

        public Notes(Appointment selectedApp)
        {
            InitializeComponent();
            Beleska = new Note
            {
                SelectedAppointment = selectedApp,
                Patient = PatientRepository.Instance.GetPatientbyId("2456")
            };
            DataContext = this;
            DateReal = DateTime.Now;
            DatePicker.DisplayDateStart = DateTime.Now;
            Vidljivost = Visibility.Collapsed;
            //LoadNote(id);
        }

        private void LoadNote(string id)
        {
            Note note = noteController.GetById(id);

            if (note != null)
            {
                Title = note.Label;
                Content = note.Content;
                if (note.RemindDate != DateTime.MinValue)
                {
                    Date = note.RemindDate.ToString("dd.MM.yyyy.");
                    Time = note.RemindDate.ToString("HH:mm");
                    Checked = true;
                }
                else
                {
                    Date = DateTime.Now.ToShortDateString();
                    Time = DateTime.Now.ToString("HH:mm");
                }
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (Radio.IsChecked == true)
            {
                DatePicker.Visibility = Visibility.Visible;
                TimePicker.Visibility = Visibility.Visible;
            }
            else
            {
                DatePicker.Visibility = Visibility.Collapsed;
                TimePicker.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Beleska.NoteId = Guid.NewGuid().ToString("N");
            Beleska.Label = TitleBox.Text;
            Beleska.Content = ContentBox.Text;
            //Beleska.Patient.Jmbg = patient.Jmbg;
            //Beleska.Patient.Name = patient.FullName;
            if(Radio.IsChecked == false)
            {
                Beleska.Checked = false;
                NoteRepository.Instance.Create(Beleska);
            }
            else
            {
                Beleska.Checked = true;
                string DatePlusTime = DateReal.ToString("dd.MM.yyyy.") + " " + Time;
                DateTime date = DateTime.Parse(DatePlusTime);
                Beleska.RemindDate = date;
                NoteRepository.Instance.Create(Beleska);
            }
            //NoteRepository.Instance.Create(Beleska);
            Close();
        }
    }
}
