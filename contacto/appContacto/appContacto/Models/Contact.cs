using Newtonsoft.Json;

namespace appContacto.Models
{
    public enum TypeContact
    {
        telephone,
        email,
        facebook
    }

    public class Contact
    {
        [JsonProperty(PropertyName = "ContactID")]
        public int ContactID { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public TypeContact Type { get; set; }
        [JsonProperty(PropertyName = "ContactValue")]
        public string ContactValue { get; set; }
    }

}
