using System;
using System.Collections.Generic;
using System.Text;

namespace OSlight.Business.Models
{
    public class AbrirOS : Entity
    {
        public string Titulo { get; set; }
        public string NomeReclamante { get; set; }
        public DateTime DataAbertura { get; set; }
        public string NumeroPoste { get; set; }
        public Endereco Endereco { get; set; }
        public Status Status { get; set; }
        public string Descricao { get; set; }
        public FecharOS FecharOS { get; set; }
    }
}
