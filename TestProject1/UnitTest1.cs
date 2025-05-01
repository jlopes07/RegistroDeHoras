using RegistroDeHoras.Components.Pages;
using RegistroDeHoras.Service;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task Deve_Criar_Atividade()
        {
            // Arrange
            var service = new AtividadeService();
            var atividade = new Atividade("Teste", "Descrição");

            // Act
            await service.CriarAsync(atividade.Titulo, atividade.Descricao);
            var atividades = await service.ListarAsync();

            // Assert
            Assert.Single(atividades);
            Assert.Equal("Teste", atividades[0].Titulo);
        }

        [Fact]
        public async Task Deve_Iniciar_Atividade()
        {
            var service = new AtividadeService();
            var atividade = new Atividade("Atividade", null);

            await service.CriarAsync(atividade.Titulo, atividade.Descricao);
            await service.IniciarAsync(atividade.Id);
            var obtida = await service.ObterPorIdAsync(atividade.Id);

            Assert.NotNull(obtida?.Inicio);
            Assert.True(obtida.EmAndamento);
        }

        [Fact]
        public async Task Deve_Terminar_Atividade()
        {
            var service = new AtividadeService();
            var atividade = new Atividade("Atividade", null);

            await service.CriarAsync(atividade.Titulo, atividade.Descricao);
            await service.IniciarAsync(atividade.Id);
            await Task.Delay(100); // Simula tempo
            await service.TerminarAsync(atividade.Id);

            var obtida = await service.ObterPorIdAsync(atividade.Id);

            Assert.NotNull(obtida?.Fim);
            Assert.False(obtida.EmAndamento);
            Assert.NotNull(obtida?.TempoTotal);
            Assert.True(obtida.TempoTotal?.TotalMilliseconds > 0);
        }

    }
}
