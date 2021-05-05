using Betb2bTestApp.Models;

namespace Betb2bTestApp.Services
{
    public class UserService : IUserService
    {
        public GetUserResponse Get(GetUserRequest request)
        {
            return new GetUserResponse
            {
                Id = 1,
                Name = "andrey",
                Status = Status.Deleted
            };
        }

        public CreateUserResponse Create(CreateUserRequest request)
        {
            return new CreateUserResponse
            {
                ErrorId = 0,
                User = new User
                {
                    Id = 1,
                    Name = "alex",
                    Status = Status.Active
                },
                
            };
        }

        public RemoveUserResponse Remove(RemoveUserRequest request)
        {
            return new()
            {
                ErrorId = 0,
                Message = "created",
                User = new UserInfoModel
                {
                    Id = 1,
                    Name = "alex",
                    Status = Status.Active
                }
            };
        }

        public SetStatusResponse SetStatus(SetStatusRequest request)
        {
            return new()
            {
                Id = 1,
                Name = "alex",
                Status = Status.Blocked
            };
        }

        
    }
}
