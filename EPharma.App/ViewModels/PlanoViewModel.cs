using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPharma.App.ViewModels
{
    public class PlanoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Descrição do plano
        /// </summary>
        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Plano")]
        public string NomePlano { get; set; }

        /// <summary>
        /// Data inicio da vigência
        /// </summary>
        [Required(ErrorMessage = "A Data Início da Vigência é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Data Início da vigência")]
        public DateTime DataInicioVigencia { get; set; }

        /// <summary>
        /// Data fim da vigência
        /// </summary>
        [Required(ErrorMessage = "A Data Fim da vigência é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Data Início da vigência")]
        public DateTime DataFimVigencia { get; set; }

        /// <summary>
        /// Permite pessoa jurídica
        /// </summary>
        [Display(Name = "Permite Pessoa Jurídica")]
        public bool IsPJ { get; set; }   

    }
}
