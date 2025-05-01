namespace RegistroDeHoras.ValueObject
{
    public class Periodo
    {
        public DateTime Inicio { get; private set; }
        public DateTime? Fim { get; private set; }

        public Periodo(DateTime inicio)
        {
            Inicio = inicio;
        }

        public void Finalizar()
        {
            Fim = DateTime.UtcNow;
        }

        public TimeSpan? Duracao => Fim.HasValue ? Fim - Inicio : null;
    }
}

