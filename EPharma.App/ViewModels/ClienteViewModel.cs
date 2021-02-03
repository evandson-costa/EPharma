using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EPharma.App.ViewModels
{
    public class ClienteViewModel
    {

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [DisplayName("Cliente")]
        public string Nome { get; set; }

        [DisplayName("Tipo")]
        public int TipoCliente { get; set; }

        /// <summary>
        /// Cpf ou RG
        /// </summary>
        [DisplayName("CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        /// <summary>
        /// RG
        /// </summary>
        public string RG { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        /// 
        [DisplayName("Dt de Nascimento")]
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>     
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Telefone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Informe o seu Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [DisplayName("Plano de Saúde")]
        public Guid PlanoId { get; set; }
        public PlanoViewModel Plano { get; set; }

        public IEnumerable<PlanoViewModel> Planos { get; set; }
    }
}
