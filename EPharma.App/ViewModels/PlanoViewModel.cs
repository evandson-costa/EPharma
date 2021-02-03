using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EPharma.App.ViewModels
{
    public class PlanoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Descrição do plano
        /// </summary>
        [Required(ErrorMessage = "O Nome do Plano de Saúde é obrigatório")]
        [Display(Name = "Nome do Plano de Saúde")]
        public string NomePlano { get; set; }

        /// <summary>
        /// Data inicio da vigência
        /// </summary>
        [Required(ErrorMessage = "A Data Início da Vigência é obrigatória")]
        [Display(Name = "Data Início da vigência")]
        public DateTime DataInicioVigencia { get; set; }

        /// <summary>
        /// Data fim da vigência
        /// </summary>
        [Required(ErrorMessage = "A Data Fim da vigência é obrigatória")]
        [Display(Name = "Data Fim da vigência")]
        public DateTime DataFimVigencia { get; set; }

        /// <summary>
        /// Permite pessoa jurídica
        /// </summary>
        [Display(Name = "Permite Pessoa Jurídica")]
        public bool IsPJ { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>     
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

    }
}
