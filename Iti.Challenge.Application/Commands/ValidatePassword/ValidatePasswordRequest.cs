using MediatR;

namespace Iti.Challenge.Application.Commands
{
    public class ValidatePasswordRequest : IRequest<ValidatePasswordResponse>
    {
        public string Password { get; set; }
    }
}
