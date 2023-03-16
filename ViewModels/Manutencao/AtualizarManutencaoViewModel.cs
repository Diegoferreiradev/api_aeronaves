﻿using APICiaAerea.Entities.Enums;

namespace APICiaAerea.ViewModels.Manutencao
{
    public class AtualizarManutencaoViewModel
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string? Observacoes { get; set; }
        public TipoManutencao Tipo { get; set; }
        public int AeronaveId { get; set; }

        public AtualizarManutencaoViewModel(int id, DateTime dataHora, string? observacoes, TipoManutencao tipo, int aeronaveId)
        {
            Id = id;
            DataHora = dataHora;
            Observacoes = observacoes;
            Tipo = tipo;
            AeronaveId = aeronaveId;
        }
    }
}
