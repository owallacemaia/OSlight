using System;

namespace OSlight.Business.Models
{
    public class Endereco : Entity
    {
        public Guid AbrirOSId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        /*EF Relations*/
        public AbrirOS AbrirOS { get; set; }

    }
}