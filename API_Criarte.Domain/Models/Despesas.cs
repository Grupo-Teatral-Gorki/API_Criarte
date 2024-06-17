using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("despesas", Schema = "projeto")]
    public class Despesas
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        [Column("id_grupo_despesa")]
        public int IdGrupoDespesa { get; set; }

        [Column("id_rubrica")]
        public int IdRubrica { get; set; }

        [Column("id_tipo_unidade")]
        public int IdTipoUnidade { get; set; }

        [Column("data_inicio")]
        public DateTime? DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime? DataFim { get; set; }

        [Column("quantidade")]
        public decimal? Quantidade { get; set; }

        [Column("valor_unitario")]
        public decimal? ValorUnitario { get; set; }

        [Column("observacao")]
        public string Observacao { get; set; }
    }
}
