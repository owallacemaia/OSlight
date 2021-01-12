using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OSlight.App.ViewModels
{
    public class AbrirOSViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome do Reclamante")]
        public string NomeReclamante { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [DisplayName("Data da Abertura")]
        public DateTime DataAbertura { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Numero do Poste")]
        public string NumeroPoste { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        [DisplayName("Status")]
        public int Status { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Qual(is) é(são) o(s) problema(s) apresentados?")]
        public string Descricao { get; set; }

        public FecharOSViewModel FecharOS { get; set; }
    }
}
