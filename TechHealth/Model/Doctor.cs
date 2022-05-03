

using Newtonsoft.Json;

namespace TechHealth.Model
{

    public class Doctor : Person
    {
        public Specialization Specialization { get; set; }
        [JsonIgnore]
        public string FullSpecialization => $"{Name} {Surname} - {Specialization.NameSpecialization} ";

        public bool ShouldSerializeSpecialization()
        {
            return ShouldSerialize;
        }


    }
}