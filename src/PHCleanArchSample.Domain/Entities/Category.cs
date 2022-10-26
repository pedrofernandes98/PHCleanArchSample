using PHCleanArchSample.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHCleanArchSample.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidadeDomain(name);
        }

        public Category(int id, string name)
        {
            DomainValidationException.When(id <= 0, "O Id não pode ser nulo ou negativo");
            ValidadeDomain(name);
            Id = id;
        }

        public void Update(string name)
        {
            ValidadeDomain(name);
        }

        private void ValidadeDomain(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome não pode ser vazio ou nulo");

            DomainValidationException.When(name?.Length < 3, "O nome deve ter pelo menos 3 caracteres.");

            Name = name;
        }
    }
}
