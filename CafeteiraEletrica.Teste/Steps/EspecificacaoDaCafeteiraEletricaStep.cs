using System;
using System.Threading.Tasks;
using CafeteiraEletrica.Teste.Stubs;
using CoffeeMakerApi;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CafeteiraEletrica.Teste.Steps
{
    [Binding]
    public class EspecificacaoDaCafeteiraEletricaStep
    {
        private CoffeeMakerApiStub _coffeeMakerApi;
        private M4FonteDeAguaQuente _fonteDeAguaQuente;
        private M4RecipienteDeContencao _recipienteDeContencao;
        private M4InterfaceDoUsuario _interfaceDoUsuario;

        [BeforeScenario]
        public void InicializeAPI()
        {
            _coffeeMakerApi = new CoffeeMakerApiStub();
        }

        #region GIVEN
        [Given(@"uma fonte de água quente")]
        public void GivenUmaFonteDeAguaQuente()
        {
            _fonteDeAguaQuente = new M4FonteDeAguaQuente(_coffeeMakerApi);
        }

        [Given(@"que a fonte não contém água")]
        public void GivenQueAFonteNaoContemAgua()
        {
            _coffeeMakerApi.SetBoilerStatus(BoilerStatus.EMPTY);
        }

        [Given(@"um recipiente de contenção")]
        public void GivenUmRecipienteDeContencao()
        {
            _recipienteDeContencao = new M4RecipienteDeContencao(_coffeeMakerApi);
            _recipienteDeContencao.Inicio(_interfaceDoUsuario, _fonteDeAguaQuente);
        }

        [Given(@"que o recipiente não esteja acoplado")]
        public void GivenQueORecipienteNaoEstejaAcoplado()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.WARMER_EMPTY);
        }

        [Given(@"um interface de usuario")]
        public void GivenUmInterfaceDeUsuario()
        {
            _interfaceDoUsuario = new M4InterfaceDoUsuario(_coffeeMakerApi);
            _interfaceDoUsuario.Inicio(_fonteDeAguaQuente, _recipienteDeContencao);
        }

        [Given(@"que o preparo do café foi iniciado")]
        public void GivenQueOPreparoDoCafeFoiIniciado()
        {
            GivenUmaFonteDeAguaQuente();
            GivenQueAFonteContemAgua();
            GivenUmRecipienteDeContencao();
            GivenQueORecipienteEstejaAcoplado();
            GivenUmInterfaceDeUsuario();
            GivenPrecionadoOBotaoDeInicio();
            WhenIniciadoOPreparoDoCafe();
            ThenOPreparoDoCafeEIniciado();
        }

        [Given(@"o preparo do café e interrompido")]
        public void GivenOPreparoDoCafeEInterrompido()
        {
            GivenQueOPreparoDoCafeFoiIniciado();
            WhenORecipienteDeContecaoEExtraido();            
            ThenOPreparoDoCafeEInterrompido();
        }

        [Given(@"o café pronto para consumo")]
        public void GivenOCafeProntoParaConsumo()
        {
            throw new PendingStepException();
        }

        [Given(@"precionado o botão de inicio")]
        public void GivenPrecionadoOBotaoDeInicio()
        {
            _coffeeMakerApi.SetBrewButtonStatus(BrewButtonStatus.PUSHED);
        }

        [Given(@"que a fonte contém água")]
        public void GivenQueAFonteContemAgua()
        {
            _coffeeMakerApi.SetBoilerStatus(BoilerStatus.NOT_EMPTY);
        }

        [Given(@"que o recipiente esteja acoplado")]
        public void GivenQueORecipienteEstejaAcoplado()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
        }
        #endregion

        #region WHEN
        [When(@"iniciado o preparo do café")]
        public void WhenIniciadoOPreparoDoCafe()
        {
            _interfaceDoUsuario.Preparando();
            _recipienteDeContencao.Preparando();
            _fonteDeAguaQuente.Preparando();
        }

        [When(@"o recipiente de conteção e extraido")]
        public void WhenORecipienteDeContecaoEExtraido()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.WARMER_EMPTY);
            WhenIniciadoOPreparoDoCafe();
        }

        [When(@"o recipiente de conteção e devolvido")]
        public void WhenORecipienteDeContecaoEDevolvido()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_NOT_EMPTY);
            WhenIniciadoOPreparoDoCafe();
        }

        [When(@"comcluido o preparo do café")]
        public void WhenComcluidoOPreparoDoCafe()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_NOT_EMPTY);
            _coffeeMakerApi.SetBoilerStatus(BoilerStatus.EMPTY);
            WhenIniciadoOPreparoDoCafe();
        }

        [When(@"identificado o consumido completo")]
        public void WhenIdentificadoOConsumidoCompleto()
        {
            throw new PendingStepException();
        }

        [When(@"identificado que ainda não foi consumido por completo")]
        public void WhenIdentificadoQueAindaNaoFoiConsumidoPorCompleto()
        {
            throw new PendingStepException();
        }
        #endregion

        #region THEN
        [Then(@"o preparo do café não e iniciado")]
        public void ThenOPreparoDoCafeNaoEIniciado()
        {
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.OPEN));
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.EMPTY));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.OFF));
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.WARMER_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.OFF));
            Assert.That(_coffeeMakerApi.GetIndicatorState(), Is.EqualTo(IndicatorState.OFF));
            Assert.That(_coffeeMakerApi.GetBrewButtonStatus(), Is.EqualTo(BrewButtonStatus.PUSHED));
        }

        [Then(@"o preparo do café e iniciado")]
        public void ThenOPreparoDoCafeEIniciado()
        {
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.CLOSED));
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.ON));
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.POT_EMPTY)
                .Or.EqualTo(WarmerPlateStatus.POT_NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.ON));
            Assert.That(_coffeeMakerApi.GetIndicatorState(), Is.EqualTo(IndicatorState.OFF));
            Assert.That(_coffeeMakerApi.GetBrewButtonStatus(), Is.EqualTo(BrewButtonStatus.PUSHED));
        }

        [Then(@"o preparo do café e interrompido")]
        public void ThenOPreparoDoCafeEInterrompido()
        {
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.OPEN));
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.OFF));
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.WARMER_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.OFF));
            Assert.That(_coffeeMakerApi.GetIndicatorState(), Is.EqualTo(IndicatorState.OFF));
            Assert.That(_coffeeMakerApi.GetBrewButtonStatus(), Is.EqualTo(BrewButtonStatus.PUSHED));
        }

        [Then(@"o preparo do café e retomado")]
        public void ThenOPreparoDoCafeERetomado()
        {
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.CLOSED));
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.ON));
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.POT_EMPTY)
                .Or.EqualTo(WarmerPlateStatus.POT_NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.ON));
            Assert.That(_coffeeMakerApi.GetIndicatorState(), Is.EqualTo(IndicatorState.OFF));
            Assert.That(_coffeeMakerApi.GetBrewButtonStatus(), Is.EqualTo(BrewButtonStatus.PUSHED));
        }

        [Then(@"mantido aquecido até ser consumo por completo")]
        public void ThenMantidoAquecidoAteSerConsumoPorCompleto()
        {
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.POT_NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.ON));
            Assert.That(_coffeeMakerApi.GetIndicatorState(), Is.EqualTo(IndicatorState.ON));
            Assert.That(_coffeeMakerApi.GetBrewButtonStatus(), Is.EqualTo(BrewButtonStatus.PUSHED));
        }

        [Then(@"o café está pronto para o consumo")]
        public void ThenOCafeEstaProntoParaOConsumo()
        {
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.OPEN));
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.EMPTY));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.OFF));
        }

        [Then(@"o ciclo de preparo e finalizado")]
        public void ThenOCicloDePreparoEFinalizado()
        {
            throw new PendingStepException();
        }
        #endregion
    }
}
