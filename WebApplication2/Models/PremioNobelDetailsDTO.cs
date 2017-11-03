using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
   public class PremioNobelDetailsDTO
    {
        public int PremioNobelId { get; set; }
        public int Ano { get; set; }
        public int CategoriaId { get; set; }
        public string Titulo { get; set; }
        public string Motivacao { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        public virtual ICollection<LaureadoOrganizacaoDTO> Organizacao { get; set; }
    }
}
