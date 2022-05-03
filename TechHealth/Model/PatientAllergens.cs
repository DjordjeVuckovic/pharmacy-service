namespace TechHealth.Model
{
    public class PatientAllergens
    {
        public string PatientJMBG { get; set; }
        public string AllergenName { get; set; }
        public string AllergenDescription { get; set; }
        public bool ShouldSerialize;
        public PatientAllergens()
        {
        }
        public PatientAllergens(string patientJMBG, string allergenName, string allergenDescription)
        {
            PatientJMBG = patientJMBG;
            AllergenName = allergenName;
            AllergenDescription = allergenDescription;
        }
    }
}
