using GP.Aplicacao.Atributos;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GP.Aplicacao.ViewModels
{
    public class MarcaViewModel
    {
        [SwaggerExclude]
        [Key]
        public Guid Id { get; internal set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(2, ErrorMessage = "O nome deve conter ao menos 2 letras.")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo 100 letras.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}
