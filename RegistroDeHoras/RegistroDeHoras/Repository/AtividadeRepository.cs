using RegistroDeHoras.Components.Pages;

using RegistroDeHoras.Repository;
using System.Xml.Linq;

public class AtividadeRepository : IatividadeRepository
{
    private readonly List<Atividade> _atividades = new();

    public void Adicionar(Atividade atividade) => _atividades.Add(atividade);

    public IEnumerable<Atividade> ObterTodas() => _atividades;

    public Atividade? ObterPorId(Guid id) => _atividades.FirstOrDefault(a => a.Id == id);

    public void Atualizar(Atividade atividade)
    {
        var existente = ObterPorId(atividade.Id);
        if (existente is not null)
        {
            _atividades.Remove(existente);
            _atividades.Add(atividade);
        }
    }
}
