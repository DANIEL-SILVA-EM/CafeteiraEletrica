using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4FonteDeAguaQuente : FonteDeAguaQuente, IPrepararCafe
    {
        private readonly ICoffeeMakerApi _api;

        public M4FonteDeAguaQuente(ICoffeeMakerApi api)
        {
            _api = api;
        }

        protected internal override bool EstaPronto
        {
            get {
                return _api.GetBoilerStatus() == BoilerStatus.NOT_EMPTY;
            }
        }


        internal override void InterrompaProducao()
        {
            _api.SetBoilerState(BoilerState.OFF);
            _api.SetReliefValveState(ReliefValveState.OPEN);
        }

        internal override void Prepare()
        {
            _api.SetBoilerState(BoilerState.ON);
            _api.SetReliefValveState(ReliefValveState.CLOSED);
        }

        internal override void RetorneProducao()
        {
            _api.SetBoilerState(BoilerState.ON);
            _api.SetReliefValveState(ReliefValveState.CLOSED);
        }

        public void Preparando()
        {
            CafeEstaPronto();            
        }

        private void CafeEstaPronto()
        {
            if (_api.GetBoilerStatus() != BoilerStatus.EMPTY || _api.GetWarmerPlateStatus() != WarmerPlateStatus.POT_NOT_EMPTY) return;
            
            _api.SetBoilerState(BoilerState.OFF);
            _api.SetReliefValveState(ReliefValveState.OPEN);
            Pronto();
        }
    }
}
