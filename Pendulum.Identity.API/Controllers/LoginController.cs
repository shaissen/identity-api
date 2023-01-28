using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pendulum.Identity.Domain.DTO;
using Pendulum.Identity.Domain.Response;

namespace Pendulum.Identity.API.Controllers
{
    [ApiController]
    [Route("pendulum/login")]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("admin")]
        public Task<AutoWrap> LoginAdmin(LoginAdminDTO login)
        {
            return _mediator.Send(login);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
