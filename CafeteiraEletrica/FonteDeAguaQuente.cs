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

        protected internal abstract bool EstaPronto { get; }

        internal abstract void Prepare();
        internal abstract void InterrompaProducao();
        internal abstract void RetorneProducao();
    }
}
