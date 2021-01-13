using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OSlight.App.ViewModels
{
    public class FecharOSViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("NumeroOS")]
        public Guid AbrirOSId { get; set; }

        [DisplayName("O que foi feito para resolver o problema?")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de finalização de chamado")]
        public DateTime DataFechamento { get; set; }

        public AbrirOSViewModel AbrirOS { get; set; }
    }
}
