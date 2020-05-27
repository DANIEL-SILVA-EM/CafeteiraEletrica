using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4InterfaceDoUsuario : InterfaceDoUsuario, IPrepararCafe
    {
        private ICoffeeMakerApi _api;

        public M4InterfaceDoUsuario(ICoffeeMakerApi api)
        {
            _api = api;
        }

        public void Preparando()
        {
            if (_api.GetBrewButtonStatus() == BrewButtonStatus.PUSHED)
            {
                Iniciar();
            }
        }

        internal override void Pronto()
        {
            if (_api.GetBoilerStatus() == BoilerStatus.EMPTY)
            {
                _api.SetIndicatorState(IndicatorState.ON);
            }
        }
    }
}
