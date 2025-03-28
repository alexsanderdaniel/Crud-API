using System.ComponentModel.DataAnnotations;

namespace GerandoAtivo.Dtos.Usuario
{
    public class UsuarioLoginRequisicao
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}