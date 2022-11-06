using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PHCleanArchSample.Application.Dtos
{
    public class CategoryDto
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "O nome não pode ser vazio ou nulo")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        [DisplayName("Nome")]
        public string Name {get; set;}
    }
}