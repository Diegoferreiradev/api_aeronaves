using APICiaAerea.Entities.Enums;

namespace APICiaAerea.Entities
{
    public class Manutencao
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string? Observacoes { get; set; }
        public TipoManutencao Tipo { get; set; }
        public int AeronaveId { get; set; }
        public Aeronave Aeronave { get; set; } = null!;

        public Manutencao(DateTime dataHora, TipoManutencao tipo, int aeronaveId, string? observacoes = null)
        {
            DataHora = dataHora;
            Tipo = tipo;
            AeronaveId = aeronaveId;
            Observacoes = observacoes;
        }
    }
}
