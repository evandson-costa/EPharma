using EPharma.Business.Models;
using System;

namespace EPharma.Business.Models
{
    public class Plano : Entity
    {        
       
        /// <summary>
        /// Descrição do plano
        /// </summary>
        public string NomePlano { get; set; }

        /// <summary>
        /// Data inicio da vigência
        /// </summary>
        public DateTime DataInicioVigencia { get; set; }

        /// <summary>
        /// Data fim da vigência
        /// </summary>
        public DateTime DataFimVigencia { get; set; }

        /// <summary>
        /// Permite pessoa jurídica
        /// </summary>
        public bool IsPJ { get; set; }

        /* EF Relations */
        public Guid? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}