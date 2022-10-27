using FluentAssertions;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Validation;

namespace PHCleanArchSample.Domain.Tests
{
    public class CategoryUnitTests
    {
        [Fact(DisplayName = "Cria categoria com parâmetros válidos")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action act = () => new Category(1, "Notebooks");

            act.Should()
               .NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateCategory_WithShortName_ResultDomainValidadeException()
        {
            Action act = () => new Category(1, "br");

            act.Should()
                .Throw<DomainValidationException>()
                .WithMessage("O nome deve ter pelo menos 3 caracteres.");
        }

        [Fact]
        public void CreateCategory_WithEmptyName_ResultDomainValidadeException()
        {
            Action act = () => new Category(1, "");

            act.Should()
                .Throw<DomainValidationException>()
                .WithMessage("O nome não pode ser vazio ou nulo");
        }

        [Fact]
        public void CreateCategory_WithNullName_ResultDomainValidadeException()
        {
            Action act = () => new Category(1, null);

            act.Should()
                .Throw<DomainValidationException>()
                .WithMessage("O nome não pode ser vazio ou nulo");
        }

        [Fact]
        public void CreateCategory_WithNegativeId_ResultDomainValidadeException()
        {
            Action act = () => new Category(-1, "Calçados");

            act.Should()
                .Throw<DomainValidationException>()
                .WithMessage("O Id não pode ser nulo ou negativo");
        }

        [Fact]
        public void CreateCategory_WithNegativeIdAndInvalidEmptyName_ResultDomainValidadeException()
        {
            Action act = () => new Category(-1, "");

            act.Should()
                .Throw<DomainValidationException>()
                .WithMessage("O Id não pode ser nulo ou negativo");
        }
    }
}