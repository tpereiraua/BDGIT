namespace WebApplication2.Models
{
    public class PremioNobelDTO
    {
        public int PremioNobelId { get; set; }
        public int Ano { get; set; }
        public virtual CategoriaDTO Categoria { get; set; }
        public string Titulo { get; set; }
        public string Motivacao { get; set; }

    }
}