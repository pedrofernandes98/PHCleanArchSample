using FluentAssertions;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHCleanArchSample.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Cria Produto com parâmetros válidos")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action act = () => new Product(1, "Ideapad", "Notebook bom", 3500, 23, "ideapad.jpg");

            act.Should()
               .NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_WithInvalidId_ResultDomainValidadeException()
        {
            Action act = () => new Product(-1, "Ideapad", "Notebook bom", 3500, 23, "ideapad.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("O Id não pode ser nulo ou negativo");
        }

        //DomainValidationException.When(string.IsNullOrEmpty(name), "O nome não pode ser vazio ou nulo");
        [Fact]
        public void CreateProduct_WithEmptyName_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, "", "Notebook bom", 3500, 23, "ideapad.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("O nome não pode ser vazio ou nulo");
        }

        [Fact]
        public void CreateProduct_WithNullName_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, null, "Notebook bom", 3500, 23, "ideapad.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("O nome não pode ser vazio ou nulo");
        }


        //    DomainValidationException.When(name?.Length< 3, "O nome deve ter pelo menos 3 caracteres.");

        [Fact]
        public void CreateProduct_WithShortName_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, "br", "Notebook bom", 3500, 23, "ideapad.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("O nome deve ter pelo menos 3 caracteres.");
        }

        //    DomainValidationException.When(string.IsNullOrEmpty(description), "A descrição não pode ser vazia ou nula");

        [Fact]
        public void CreateProduct_WithEmptyDescription_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, "Ideapad", "", 3500, 23, "ideapad.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("A descrição não pode ser vazia ou nula");
        }

        [Fact]
        public void CreateProduct_WithNullDescription_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, "Ideapad", null, 3500, 23, "ideapad.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("A descrição não pode ser vazia ou nula");
        }

        //    DomainValidationException.When(description?.Length< 5, "A descrição deve ter pelo menos 5 caracteres.");

        [Fact]
        public void CreateProduct_WithShortDescription_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, "Ideapad", "Note", 3500, 23, "ideapad.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("A descrição deve ter pelo menos 5 caracteres.");
        }

        //    DomainValidationException.When(price< 0, "O preço não pode ter valor negativo.");

        [Fact]
        public void CreateProduct_WithInvalidPrice_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, "Ideapad", "Notebook bom", -3500, 23, "ideapad.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("O preço não pode ter valor negativo.");
        }

        //    DomainValidationException.When(stock< 0, "O estoque não pode ter valor negativo.");

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_WithInvalidStock_ResultDomainValidadeException(int stock)
        {
            Action act = () => new Product(1, "bras", "Notebook bom", 3500, stock, "ideapad.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("O estoque não pode ter valor negativo.");
        }

        //    DomainValidationException.When(image?.Length > 250, "A imagem poderá ter no máximo 250 caracteres");

        [Fact]
        public void CreateProduct_LongImage_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, "Ideapad", "Notebook bom", 3500, 23, "ideapadaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.jpg");

            act.Should()
               .Throw<DomainValidationException>()
                .WithMessage("A imagem poderá ter no máximo 250 caracteres");
        }

        [Fact]
        public void CreateProduct_WithEmptyImage_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, "Ideapad", "Notebook bom", 3500, 23, "");

            act.Should()
               .NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_WithNullImage_ResultDomainValidadeException()
        {
            Action act = () => new Product(1, "Ideapad", "Notebook bom", 3500, 23, null);

            act.Should()
               .NotThrow<DomainValidationException>();
        }

    }
}
