using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("modalidades", Schema = "geral")]
    public class Modalidades
    {
        [Key]
        [Column("id_modalidade")]
        public int IdModalidade { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("valor_teto")]
        public double ValorTeto { get; set; }

        [Column("pessoa_juridica")]
        public bool PessoaJuridica { get; set; }
    }
}
