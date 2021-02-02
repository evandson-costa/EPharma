using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        [DisplayName("Nome do Usuário")]
        public string Nome { get; set; }

        [DisplayName("Tipo")]
        public int TipoCliente { get; set; }

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
        /// 
        [Required(ErrorMessage = "A {0} é obrigatório")]
        [DisplayName("Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        [Required]
        public int Telefone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        public IEnumerable<PlanoViewModel> Planos { get; set; }
    }
}
