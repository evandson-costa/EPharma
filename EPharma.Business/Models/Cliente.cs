using EPharma.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPharma.Business.Models
{
    public class Cliente : Entity
    {

        public Cliente()
        {
            Planos = new HashSet<Plano>();
        }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Nome { get; set; }       

        /// <summary>
        /// Cpf ou RG
        /// </summary>
        public string CpfCnpj { get; set; }

        /// <summary>
        /// RG
        /// </summary>
        public string RG { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Tipo cliente
        /// </summary>
        public int TipoCliente { get; set; }

        ///* EF Relations */
        public IEnumerable<Plano> Planos { get; set; }
    }
}