using PHCleanArchSample.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHCleanArchSample.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }


        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainValidationException.When(id <= 0, "O Id não pode ser nulo ou negativo");
            ValidateDomain(name, description, price, stock, image);
            Id = id;
        }

        public void Update(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome não pode ser vazio ou nulo");

            DomainValidationException.When(name?.Length < 3, "O nome deve ter pelo menos 3 caracteres.");

            DomainValidationException.When(string.IsNullOrEmpty(description), "A descrição não pode ser vazia ou nula");

            DomainValidationException.When(description?.Length < 5, "A descrição deve ter pelo menos 5 caracteres.");

            DomainValidationException.When(price < 0, "O preço não pode ter valor negativo.");

            DomainValidationException.When(stock < 0, "O estoque não pode ter valor negativo.");

            DomainValidationException.When(image?.Length > 250, "A imagem poderá ter no máximo 250 caracteres");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
