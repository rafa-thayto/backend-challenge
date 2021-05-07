using MediatR;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Iti.Challenge.Application.Commands
{
    public class ValidatePasswordHandler : IRequestHandler<ValidatePasswordRequest, ValidatePasswordResponse>
    {
        #region IRequestHandler implementation

        public Task<ValidatePasswordResponse> Handle(ValidatePasswordRequest request, CancellationToken cancellationToken)
        {
            var res = new ValidatePasswordResponse();

            if (request.Password.Length < 9)
            {
                res.Message = "Sua senha precisa ter nove ou mais caracteres.";
            }
            else if (!(Regex.Match(request.Password, @"[A-Za-z\d]").Success))
            {
                res.Message = "Sua senha precisa ter letras e números.";
            }
            else if (!(Regex.Match(request.Password, @"[A-Z]").Success && Regex.Match(request.Password, @"[a-z]").Success))
            {
                res.Message = "Sua senha precisa ter pelo menos uma letra minúscula e maiúscula.";
            }
            else if (!Regex.Match(request.Password, @"[!,@,#,$,%,^,&,*,(,),-,+]").Success)
            {
                res.Message = "Sua senha precisa ter ao menos um caractere especial.";
            }
            else if (request.Password.ToCharArray().GroupBy(x => x).Where(y => y.Count() > 1).Select(z => z.Key).Any())
            {
                res.Message = "Sua senha não pode ter caracteres repetidos.";
            } 
            else
            {
                res.IsValid = true;
                res.Message = "Senha válida!";
            }

            return Task.FromResult(res);
        }

        #endregion
    }
}
