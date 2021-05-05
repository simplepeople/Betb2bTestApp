using Betb2bTestApp.Models;

namespace Betb2bTestApp.Services
{
    public interface IUserService
    {
        GetUserResponse Get(GetUserRequest request);
        CreateUserResponse Create(CreateUserRequest request);
        RemoveUserResponse Remove(RemoveUserRequest request);
        SetStatusResponse SetStatus(SetStatusRequest request);
    }
}