namespace APICiaAerea.ViewModels.Piloto
{
    public class ListarPilotoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ListarPilotoViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
