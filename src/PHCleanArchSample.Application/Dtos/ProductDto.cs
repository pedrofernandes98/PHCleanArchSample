using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PHCleanArchSample.Domain.Entities;

namespace PHCleanArchSample.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio ou nulo")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição não pode ser vazia ou nula")]
        [MinLength(3, ErrorMessage = "A descrição deve ter pelo menos 5 caracteres.")]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O preço não pode ter valor negativo.")]
        [Column(TypeName= "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O estoque não pode ter valor negativo.")]
        [Range(1, 99999999)]
        [DisplayName("Estoque")]
        public int Stock { get; set; }

        [MaxLength(250, ErrorMessage = "A imagem poderá ter no máximo 250 caracteres")]
        [DisplayName("Imagem")]
        public string Image { get; set; }

        [DisplayName("Categorias")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}