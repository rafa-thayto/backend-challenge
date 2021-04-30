using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Iti.Challenge.Application.Commands
{
    public class ValidatePasswordHandler : IRequestHandler<ValidatePasswordRequest, ValidatePasswordResponse>
    {
        public Task<ValidatePasswordResponse> Handle(ValidatePasswordRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                new ValidatePasswordResponse()
                {
                    Response = "Ok!"
                });
        }
    }
}
