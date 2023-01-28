using Pendulum.Identity.Domain.DTO;
using Pendulum.Identity.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Interface
{
    public interface ILoginService
    {
        Task<AutoWrap> LoginAdmin(LoginAdminDTO login);
    }
}
