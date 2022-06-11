using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Controller;
using TechHealth.Core;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class SurveyViewModel
    {
        public RelayCommand PdfCommand { get; set; }
        private GradeController gradeController = new GradeController();
        private List<int> staffGrades;
        private List<int> generalGrades;
        public string FiveStarStaffGrade { get; set; }
        public string FourStarStaffGrade { get; set; }
        public string ThreeStarStaffGrade { get; set; }
        public string TwoStarStaffGrade { get; set; }
        public string OneStarStaffGrade { get; set; }
        public string AverageStaffGrade { get; set; }

        public string FiveStarGeneralGrade { get; set; }
        public string FourStarGeneralGrade { get; set; }
        public string ThreeStarGeneralGrade { get; set; }
        public string TwoStarGeneralGrade { get; set; }
        public string OneStarGeneralGrade { get; set; }
        public string AverageGeneralGrade { get; set; }


        public SurveyViewModel()
        {
            PdfCommand = new RelayCommand(param => ExecutePdf());

            staffGrades = gradeController.GetStaffGrades();
            FiveStarStaffGrade = "(" + gradeController.GetGradesNum(5, staffGrades) + ")";
            FourStarStaffGrade = "(" + gradeController.GetGradesNum(4, staffGrades) + ")";
            ThreeStarStaffGrade = "(" + gradeController.GetGradesNum(3, staffGrades) + ")";
            TwoStarStaffGrade = "(" + gradeController.GetGradesNum(2, staffGrades) + ")";
            OneStarStaffGrade = "(" + gradeController.GetGradesNum(1, staffGrades) + ")";
            AverageStaffGrade = "Average: " + gradeController.GetAverageGrade(staffGrades);

            generalGrades = gradeController.GetGeneralGrades();
            FiveStarGeneralGrade = "(" + gradeController.GetGradesNum(5, generalGrades) + ")";
            FourStarGeneralGrade = "(" + gradeController.GetGradesNum(4, generalGrades) + ")";
            ThreeStarGeneralGrade = "(" + gradeController.GetGradesNum(3, generalGrades) + ")";
            TwoStarGeneralGrade = "(" + gradeController.GetGradesNum(2, generalGrades) + ")";
            OneStarGeneralGrade = "(" + gradeController.GetGradesNum(1, generalGrades) + ")";
            AverageGeneralGrade = "Average: " + gradeController.GetAverageGrade(generalGrades);
        }

        private void ExecutePdf()
        {
            PdfViewModel PdfVm = new PdfViewModel();
            MainViewModel.Instance().CurrentView = PdfVm;
        }
    }
}
