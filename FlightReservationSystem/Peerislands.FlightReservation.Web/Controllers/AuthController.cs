using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peerislands.FlightReservation.Contract.Interfaces;
using Peerislands.FlightReservation.DataContract.Models;

namespace Peerislands.FlightReservation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthInteractor _authInteractor;

        public AuthController(IAuthInteractor authInteractor)
        {
            this._authInteractor = authInteractor;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth([FromBody] User user)
        {
            return Ok(_authInteractor.ExecuteAsync(user));
        }
    }
}