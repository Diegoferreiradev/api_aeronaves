namespace APICiaAerea.ViewModels.Cancelamento
{
    public class CancelarVooViewModel
    {
        public string Motivo { get; set; }
        public DateTime DataHoraNotificacao { get; set; }
        public int VooId { get; set; }

        public CancelarVooViewModel(string motivo, DateTime dataHoraNotificacao, int vooId)
        {
            Motivo = motivo;
            DataHoraNotificacao = dataHoraNotificacao;
            VooId = vooId;
        }
    }
}
