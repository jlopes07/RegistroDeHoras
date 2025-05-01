public class Atividade
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public string? Descricao { get; private set; }
    public DateTime? Inicio { get; private set; }
    public DateTime? Fim { get; private set; }
    public TimeSpan? TempoTotal =>
        Inicio.HasValue && Fim.HasValue ? Fim - Inicio : null;

    public bool EmAndamento => Inicio.HasValue && !Fim.HasValue;

    public Atividade(string titulo, string? descricao)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Descricao = descricao;
    }

    public void Iniciar()
    {
        if (Inicio != null)
            throw new InvalidOperationException("Atividade já iniciada.");

        Inicio = DateTime.UtcNow;
    }

    public void Terminar()
    {
        if (!Inicio.HasValue)
            throw new InvalidOperationException("Atividade não iniciada.");

        if (Fim.HasValue)
            throw new InvalidOperationException("Atividade já finalizada.");

        Fim = DateTime.UtcNow;
    }
}
