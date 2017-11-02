namespace WebApplication2.Models
{
    public class FiliacaoDTO
    {
        public int FiliacaoId { get; set; }
        public string Nome { get; set; }
       
        public virtual Cidade Cidade { get; set; }

    }
}