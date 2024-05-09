using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class CreateProponenteDTO
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneOutro { get; set; }
        public string ResponsavelLegal { get; set; }
        public string CPFResponsavel { get; set; }
        public string RGResponsavel { get; set; }
        public string NomeSocial { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Cargo { get; set; }
        public string CEPResponsavel { get; set; }
        public string LogradouroResponsavel { get; set; }
        public int NumeroResponsavel { get; set; }
        public string ComplementoResponsavel { get; set; }
        public string BairroResponsavel { get; set; }
        public string CidadeResponsavel { get; set; }
        public string UFResponsavel { get; set; }
        public string CEPPJ { get; set; }
        public string LogradouroPJ { get; set; }
        public int NumeroPJ { get; set; }
        public string ComplementoPJ { get; set; }
        public string BairroPJ { get; set; }
        public string CidadePJ { get; set; }
        public string UFPJ { get; set; }
    }
}
