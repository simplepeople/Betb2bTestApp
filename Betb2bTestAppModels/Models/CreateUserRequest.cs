using System.Xml.Serialization;

namespace Betb2bTestAppModels.Models
{
    [XmlRoot("Request")]
    public class CreateUserRequest
    {
        [XmlElement("user")]
        public User User { get; set; }
    }
}