using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApplication1.Models
{
    [MetadataType(typeof(PremioNobelMetaData))]
   public partial class PremioNobel { }
    [MetadataType(typeof(CategoriaMetaData))]
    public partial class Categoria { }
}
