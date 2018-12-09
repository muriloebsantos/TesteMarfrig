using System;

namespace Marfrig.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string mensagem) : base (mensagem)
        {

        }
    }
}
