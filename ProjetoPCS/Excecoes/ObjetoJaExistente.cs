﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excecoes
{
    public class ObjetoJaExistente : Exception
    {
        public ObjetoJaExistente()
        {

        }

        /**
         * construtor passando mensagem de erro
         * @param arg0 mensagem de erro
         */
        public ObjetoJaExistente(String arg0) :
            base(arg0)
        {

        }
    }
}