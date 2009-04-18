using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excecoes
{
    public class ErroBanco : Exception
    {
        public ErroBanco()
        {

        }

        /**
         * construtor passando mensagem de erro
         * @param arg0 mensagem de erro
         */
        public ErroBanco(String arg0) :
            base(arg0)
        {

        }
    }
}
