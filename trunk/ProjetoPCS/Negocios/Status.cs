using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class Status
    {
        private bool inativa;
        private bool inclusao;
        private bool navegacao;
        private bool alteracao;

        public void Incluindo()
        {
            this.inclusao = true;
            this.alteracao = false;
            this.navegacao = false;
            this.inativa = false;
        }

        public void Alterando()
        {
            this.inclusao = false;
            this.alteracao = true;
            this.navegacao = false;
            this.inativa = false;
        }

        public void Inativa()
        {
            this.inclusao = false;
            this.alteracao = false;
            this.navegacao = false;
            this.inativa = true;
        }

        public void Navegando()
        {
            this.inclusao = false;
            this.alteracao = false;
            this.navegacao = true;
            this.inativa = false;
        }

        public String StatusAtual()
        {
            String resultado = "Inativa";

            if (this.inclusao == true)
            {
                resultado = "Inclusão";
            }

            if (this.alteracao == true)
            {
                resultado = "Alteração";
            }

            if (this.navegacao == true)
            {
                resultado = "Navegação";
            }

            return resultado;

        }

        public Status()
        {
            this.Inativa();
        }



    }
}
