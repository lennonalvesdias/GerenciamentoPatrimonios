using GP.Aplicacao.Atributos;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GP.Aplicacao.ViewModels
{
    public class PatrimonioViewModel
    {
        [SwaggerExclude]
        [Key]
        public Guid Id { get; internal set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(2, ErrorMessage = "O nome deve conter ao menos 2 letras.")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo 100 letras.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O ID da marca é obrigatório.")]
        [StringLength(36, ErrorMessage = "O ID da marca deve conter 36 letras.")]
        [DisplayName("Marca")]
        public string MarcaId { get; set; }
        
        [MaxLength(300, ErrorMessage = "A descrição deve conter no máximo 300 letras.")]
        [DisplayName("Descricao")]
        public string Descricao { get; set; }
        
        [DisplayName("Número do Tombo")]
        public string NumeroTombo { get; private set; }
    }
}
