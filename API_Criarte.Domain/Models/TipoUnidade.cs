using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("tipo_unidade", Schema = "geral")]
    public class TipoUnidade
    {
        [Key]
        [Column("id_tipo_unidade")]
        public int IdTipoUnidade { get; set; }

        [Column("nome_unidade")]
        public string NomeUnidade { get; set; }
    }
}
