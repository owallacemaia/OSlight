using System;
using System.Collections.Generic;
using System.Text;

namespace OSlight.Business.Models
{
    public class FecharOS : Entity
    {
        public Guid AbrirOSId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFechamento { get; set; }

        /*EF Relations*/
        public AbrirOS AbrirOS { get; set; }
    }
}
