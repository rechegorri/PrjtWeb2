using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrjtWeb2_cadastro_ocorrencia.Models
{
    public class Pessoa
    {
        public int id { get; set; }
        [Required]
        public String nome { get; set; }
        public String endereco { get; set; }
        public String cidade { get; set; }
        [Required]
        public String telefone { get; set; }
    }
}
