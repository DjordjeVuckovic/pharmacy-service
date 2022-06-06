using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Controller;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class SurveyViewModel
    {
        private GradeController gradeController = new GradeController();
        private List<int> staffGrades;
        public string FiveStarStaffGrade { get; set; }
        public string FourStarStaffGrade { get; set; }
        public string ThreeStarStaffGrade { get; set; }
        public string TwoStarStaffGrade { get; set; }
        public string OneStarStaffGrade { get; set; }


        public SurveyViewModel()
        {
            staffGrades = gradeController.GetStaffGrades();
            FiveStarStaffGrade = "(" + gradeController.GetGradesNum(5) + ")";
            FourStarStaffGrade = "(" + gradeController.GetGradesNum(4) + ")";
            ThreeStarStaffGrade = "(" + gradeController.GetGradesNum(3) + ")";
            TwoStarStaffGrade = "(" + gradeController.GetGradesNum(2) + ")";
            OneStarStaffGrade = "(" + gradeController.GetGradesNum(1) + ")";
        }
    }
}
