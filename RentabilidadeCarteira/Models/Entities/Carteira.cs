namespace RentabilidadeCarteira.Models.Entities
{
    public class Carteira
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
