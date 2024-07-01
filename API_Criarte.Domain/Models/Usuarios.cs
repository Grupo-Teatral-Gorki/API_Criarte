using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("usuarios", Schema = "seguranca")]
    public class Usuarios
    {
        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("email")]
        public string Usuario { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("token")]
        public string? Token { get; set; }
        [Column("expiration_token")]
        public DateTime? ExpirationToken { get; set; }
        [Column("tipo_usuario")]
        public int TipoUsuario { get; set; }
    }
}
