using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("grupo_despesas", Schema = "geral")]
    public class GrupoDespesas
    {
        [Key]
        [Column("id_grupo_despesa")]
        public int IdGrupoDespesa { get; set; }

        [Column("nome_grupo")]
        public string NomeGrupo { get; set; }
    }
}
