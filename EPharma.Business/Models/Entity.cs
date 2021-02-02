using System;

namespace EPharma.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        /// <summary>
        /// Data do cadastro
        /// </summary>
        public DateTime DataCadastro { get; set; }
    }
}