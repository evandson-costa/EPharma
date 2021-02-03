using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace EPharma.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, int tipoPessoa, string documento)
        {
            return tipoPessoa == 1 ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string MarcarOpcao(this RazorPage page, int tipoPessoa, int valor)
        {
            return tipoPessoa == valor ? "checked" : "";
        }

        public static string FormataData(this RazorPage page, DateTime? dataNascimento)
        {
            var data = (DateTime)dataNascimento;
            return data == DateTime.MinValue? "" : data.ToString("dd'/'MM'/'yyyy");
        }

        public static string FormataTelefone(this RazorPage page, string telefone)
        {
            return Convert.ToUInt64(telefone).ToString(@"(00)\00000\-0000");
        }
    }
}