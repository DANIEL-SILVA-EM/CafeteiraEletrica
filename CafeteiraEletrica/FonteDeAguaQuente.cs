using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    public abstract class FonteDeAguaQuente
    {
        private RecipienteDeContencao _recipienteDeContencao;
        private InterfaceDoUsuario _interfaceDoUsuario;

        public void Inicio(M4InterfaceDoUsuario interfaceDoUsuario, M4RecipienteDeContencao recipienteDeContencao)
        {
            _interfaceDoUsuario = interfaceDoUsuario;
            _recipienteDeContencao = recipienteDeContencao;
        }

        protected internal abstract bool EstaPronto { get; }
        internal abstract void Prepare();
        internal abstract void InterrompaProducao();
        internal abstract void RetorneProducao();
        private protected void Pronto()
        {
            _recipienteDeContencao.Pronto();           
        }
    }
}
