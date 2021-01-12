using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        [Editable(false)]
        [ReadOnly(true)]
        [DataType(DataType.Date)]
        [DisplayName("Data de finalização de chamado")]
        public DateTime DataFechamento { get; set; }

        public AbrirOSViewModel AbrirOS { get; set; }
    }
}
