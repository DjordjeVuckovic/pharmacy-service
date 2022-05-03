using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TechHealth.Model;

namespace TechHealth.JsonIgnore
{
    public class ShouldSerializeAppointment:DefaultContractResolver
    {
        

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(Appointment) && property.PropertyName == "Doctor")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        Doctor doc = (Doctor)instance;
                        return false;
                    };
                
            }

            return property;
        } 
    }
}