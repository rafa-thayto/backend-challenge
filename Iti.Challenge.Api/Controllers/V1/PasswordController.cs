using Iti.Challenge.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Iti.Challenge.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("v{version:apiVersion}/[controller]")]
    public class PasswordController : Controller
    {
        #region Properties

        private readonly IMediator Mediator;

        #endregion

        #region Constructor
        public PasswordController(IMediator mediator)
        {
            Mediator = mediator;
        }
        #endregion

        [HttpPost("validate")]
        [ProducesResponseType(typeof(ValidatePasswordResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> ValidatePassword([FromBody] ValidatePasswordRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
