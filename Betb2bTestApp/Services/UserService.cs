using System;
using System.Linq;
using Betb2bTestApp.Infrastructure;
using Betb2bTestApp.Models;

namespace Betb2bTestApp.Services
{
    //this is really messy code without any validation checks
    //that didn't divide onto layers, but I thinks it's ok
    //to test app since requirements so different and I don't have a lot of time
    public class UserService : IUserService
    {
        public GetUserResponse Get(GetUserRequest request)
        {
            DbUser dbUser;
            using (var context = new Betb2bTestAppContext())
            {
                dbUser = context.Users.FirstOrDefault(x => x.Id == request.Id);
            }

            return new GetUserResponse
            {
                Name = dbUser?.Name,
                Id = request.Id,
                Status = (Status) (dbUser?.Status ?? Status.NotDefined)
            };
        }

        public CreateUserResponse Create(CreateUserRequest request)
        {
            int errorId = 0;
            string message = null;
            try
            {
                var dbUser = new DbUser
                {
                    Id = request.User.Id,
                    Name = request.User.Name,
                    Status = (Status)request.User.Status
                };
                using (var context = new Betb2bTestAppContext())
                {
                    context.Users.Add(dbUser);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) when (ex.InnerException?.Message.Contains("Duplicate entry") ?? false)
            {
                errorId = 1;
                message = $"User with id {request.User.Id} already exist";
            }
            catch (Exception ex)
            {
                errorId = ex.HResult;
                message = ex.Message;
            }

            return new CreateUserResponse
            {
                Message = message,
                ErrorId = errorId,
                User = new User
                {
                    Name = request.User.Name,
                    Id = request.User.Id,
                    Status = request.User.Status
                }
            };
        }

        public RemoveUserResponse Remove(RemoveUserRequest request)
        {
            int errorId = 0;
            string message = "User was removed";
            DbUser dbUser = null;
            try
            {
                int status = Status.Deleted;
                using (var context = new Betb2bTestAppContext())
                {
                    dbUser = context.Users.FirstOrDefault(u => u.Id == request.Id);
                    if (dbUser != null)
                    {
                        dbUser.Status = status;
                        context.Users.Update(dbUser);
                        context.SaveChanges();
                    }
                    else
                    {
                        errorId = 1;
                        message = $"User with id {request.Id} wasn't found";
                    }
                }
            }
            catch (Exception ex)
            {
                errorId = ex.HResult;
                message = ex.Message;
            }

            return new RemoveUserResponse
            {
                Message = message,
                ErrorId = errorId,
                User = new User
                {
                    Name = dbUser?.Name,
                    Id = request.Id,
                    Status = Status.Deleted
                }
            };
        }

        public SetStatusResponse SetStatus(SetStatusRequest request)
        {
            DbUser dbUser = null;
            try
            {
                int status = (Status)request.Status;
                using (var context = new Betb2bTestAppContext())
                {
                    dbUser = context.Users.FirstOrDefault(u => u.Id == request.Id);
                    if (dbUser != null)
                    {
                        dbUser.Status = status;
                        context.Users.Update(dbUser);
                        context.SaveChanges();
                    }
                }
            }
            catch { }

            return new SetStatusResponse
            {
                Name = dbUser?.Name,
                Id = dbUser?.Id,
                Status = (Status)(dbUser?.Status ?? Status.NotDefined)
            };
        }


    }
}
