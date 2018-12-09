using System.Collections.Generic;

namespace Marfrig.Domain.Exceptions
{
    public class EntityValidationException : BusinessException
    {
        public EntityValidationException(IReadOnlyList<string> validacoes)
            : base("A operação não pode ser finalizada pelos seguintes motivos: " + string.Join(" / ", validacoes))
        {

        }
    }
}
