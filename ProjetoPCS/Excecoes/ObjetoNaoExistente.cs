using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excecoes
{
    public class ObjetoNaoExistente : Exception
    {
        public ObjetoNaoExistente()
        {

        }

        /**
         * construtor passando mensagem de erro
         * @param arg0 mensagem de erro
         */
        public ObjetoNaoExistente(String arg0) :
            base(arg0)
        {

        }
    }
}