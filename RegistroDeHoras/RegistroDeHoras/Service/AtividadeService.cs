using RegistroDeHoras.Components.Pages;

public class AtividadeService
{
    private readonly List<Atividade> _atividades = new();

    public Task CriarAsync(string titulo, string? descricao)
    {
        var atividade = new Atividade(titulo, descricao);
        _atividades.Add(atividade);
        return Task.CompletedTask;
    }

    public Task IniciarAsync(Guid id)
    {
        var atividade = _atividades.FirstOrDefault(a => a.Id == id)
            ?? throw new InvalidOperationException("Atividade não encontrada.");

        atividade.Iniciar();
        return Task.CompletedTask;
    }

    public Task TerminarAsync(Guid id)
    {
        var atividade = _atividades.FirstOrDefault(a => a.Id == id)
            ?? throw new InvalidOperationException("Atividade não encontrada.");

        atividade.Terminar();
        return Task.CompletedTask;
    }

    public Task<List<Atividade>> ListarAsync()
    {
        return Task.FromResult(_atividades.ToList());
    }

    public Task<Atividade?> ObterPorIdAsync(Guid id)
    {
        var atividade = _atividades.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(atividade);
    }
}
