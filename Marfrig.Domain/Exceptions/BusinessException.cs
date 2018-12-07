using System;

namespace Marfrig.Domain.Exceptions
{
    public class BusinessException : ApplicationException
    {
        public BusinessException(string mensagem) : base(mensagem)
        {

        }
    }
}
