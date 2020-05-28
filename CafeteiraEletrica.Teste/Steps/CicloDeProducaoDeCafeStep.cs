using CafeteiraEletrica.Teste.Steps;
using CafeteiraEletrica.Teste.Stubs;
using CoffeeMakerApi;
using System;
using TechTalk.SpecFlow;

namespace CafeteiraEletrica.Teste
{
    [Binding]
    public class CicloDeProducaoDeCafeStep
    {
        private CoffeeMakerApiStub _coffeeMakerApi;
        private EspecificacaoDaCafeteiraEletricaStep _cafeteiraEletrica;

        [BeforeScenario]
        public void InicializeAPI()
        {
            _coffeeMakerApi = new CoffeeMakerApiStub();
        }

        [Given(@"uma cafeteira elétrica em perfeito funcionamento")]
        public void GivenUmaCafeteiraEletricaEmPerfeitoFuncionamento()
        {
            _cafeteiraEletrica = new EspecificacaoDaCafeteiraEletricaStep();

            _cafeteiraEletrica.InicializeAPI();
            _cafeteiraEletrica.GivenUmaFonteDeAguaQuente();
            _cafeteiraEletrica.GivenUmRecipienteDeContencao();
            _cafeteiraEletrica.GivenUmInterfaceDeUsuario();
            _cafeteiraEletrica.GivenQueOPreparoDoCafeFoiIniciado();
            _cafeteiraEletrica.GivenOPreparoDoCafeEInterrompido();
            _cafeteiraEletrica.GivenOCafeProntoParaConsumo();
        }

        [Given(@"abastecido com água o respectivo receptáculo")]
        public void GivenAbastecidoComAguaORespectivoReceptaculo()
        {
            _coffeeMakerApi.SetBoilerStatus(BoilerStatus.NOT_EMPTY);
        }

        [Given(@"uma jarra vazia acoplada para coleta do café")]
        public void GivenUmaJarraVaziaAcopladaParaColetaDoCafe()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
        }

        [Given(@"o café pronto para o consumo")]
        public void GivenOCafeProntoParaOConsumo()
        {
            throw new PendingStepException();
        }

        [When(@"pressionada a opção preparar")]
        public void WhenPressionadaAOpcaoPreparar()
        {
            _cafeteiraEletrica.WhenIniciadoOPreparoDoCafe();
        }

        [When(@"identificado que foi servido por completo")]
        public void WhenIdentificadoQueFoiServidoPorCompleto()
        {
            throw new PendingStepException();
        }

        [Then(@"o café está pronto e mantido aquecido")]
        public void ThenOCafeEstaProntoEMantidoAquecido()
        {
            _cafeteiraEletrica.ThenMantidoAquecidoAteSerConsumoPorCompleto();
            _cafeteiraEletrica.ThenOCafeEstaProntoParaOConsumo();
        }

        [Then(@"o cliclo de confecção do café e finalizado")]
        public void ThenOClicloDeConfeccaoDoCafeEFinalizado()
        {
            throw new PendingStepException();
        }
    }
}