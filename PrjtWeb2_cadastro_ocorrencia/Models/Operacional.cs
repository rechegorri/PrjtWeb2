using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrjtWeb2_cadastro_ocorrencia.Models
{
    public class Operacional : Pessoa
    {
        [Required]
        public string funcao { get; set; }
        
    }
}