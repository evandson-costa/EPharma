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

        /// <summary>
        /// Deletado
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Deletado
        /// </summary>
        public DateTime DataAlteracao { get; set; }
    }
}