using Pendulum.Identity.Domain.Enums;
using Pendulum.Identity.Domain.ViewModel;

namespace Pendulum.Identity.Data.Interface.QueryInterface
{
    public interface IUserManagementQuery
    {
        Task<string> GetUserHashedPasswordByUsername(string username, ConnectionType connectionType);

        Task<UserInfoViewModel> GetUserInfoByUsername(string username, ConnectionType connectionType);
    }
}
