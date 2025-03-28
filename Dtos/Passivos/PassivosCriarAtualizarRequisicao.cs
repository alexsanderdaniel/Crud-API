using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace GerandoAtivo.Dtos.Passivos
{
    public class PassivosCriarAtualizarRequisicao
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100,
         MinimumLength = 3,
         ErrorMessage = "{0} deve ter entre {2} e {1} caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Valor { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int UsuarioId { get; set; }
    }
}