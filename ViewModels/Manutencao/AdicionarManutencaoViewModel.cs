using APICiaAerea.Entities.Enums;

namespace APICiaAerea.ViewModels.Manutencao
{
    public class AdicionarManutencaoViewModel
    {
        public DateTime DataHora { get; set; }
        public string? Observacoes { get; set; }
        public TipoManutencao Tipo { get; set; }
        public int AeronaveId { get; set; }

        public AdicionarManutencaoViewModel(DateTime dataHora, string? observacoes, TipoManutencao tipo, int aeronaveId)
        {
            DataHora = dataHora;
            Observacoes = observacoes;
            Tipo = tipo;
            AeronaveId = aeronaveId;
        }
    }
}
