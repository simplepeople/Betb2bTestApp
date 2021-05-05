using System.Xml.Serialization;

namespace Betb2bTestAppModels.Models
{
    public class UserInfoModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Status { get; set; }
    }

    public class User
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("Status")]
        public string Status { get; set; }
    }

    public class UserOperationResponse
    {
        [XmlAttribute("ErrorId")]
        public int ErrorId { get; set; }

        [XmlAttribute("Message")]
        public string Message { get; set; }

        //todo add field to xml response
        [XmlAttribute("Success")]
        public bool Success => ErrorId == 0;
        [XmlAttribute("user")]
        public User User { get; set; }
    }
}