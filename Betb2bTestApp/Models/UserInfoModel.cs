using System.Xml.Serialization;

namespace Betb2bTestApp.Models
{
    public class UserInfoModel
    {
        public int? Id { get; set; }
        
        public string Name { get; set; }
        
        public string Status { get; set; }
    }

    [XmlRoot("Request")]
    public class CreateUserRequest
    {
        [XmlElement("user")]
        public User User { get; set; }
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

    public class RemoveUserRequest
    {
        public int Id { get; set; }
    }

    public class UserOperationResponse
    {
        [XmlAttribute("ErrorId")]
        public int ErrorId { get; set; }

        [XmlAttribute("Message")]
        public string Message { get; set; }

        //todo add field to response
        [XmlAttribute("Success")]
        public bool Success => ErrorId == 0;
        [XmlAttribute("user")]
        public User User { get; set; }
    }

    public class GetUserRequest
    {
        public int Id { get; set; }
    }

    public class GetUserResponse : UserInfoModel
    {

    }

    [XmlRoot("Response")]
    public class CreateUserResponse : UserOperationResponse
    {

    }

    [XmlRoot("Response")]
    public class RemoveUserResponse : UserOperationResponse
    {

    }

    public class SetStatusRequest
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

    public class SetStatusResponse : UserInfoModel
    {

    }
}