using EPharma.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPharma.Business.Models
{
    public class Cliente : Entity
    {
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Tipo cliente 1- pessoa fisica 2 - pessoa Juridica
        /// </summary>
        public TipoCliente TipoCliente { get; set; }

        /// <summary>
        /// Cpf ou RG
        /// </summary>
        public int CpfCnpj { get; set; }

        /// <summary>
        /// RG
        /// </summary>
        public int RG { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public int Telefone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }        

        /* EF Relations */
        public IEnumerable<Plano> Planos { get; set; }
    }
}