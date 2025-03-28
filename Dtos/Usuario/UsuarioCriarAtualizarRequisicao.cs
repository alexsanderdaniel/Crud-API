using System.ComponentModel.DataAnnotations;

namespace GerandoAtivo.Dtos.Usuario;

public class UsuarioCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100,
     MinimumLength = 3,
     ErrorMessage = "{0} deve ter entre {2} e {1} caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
    [StringLength(100,
     MinimumLength = 3,
     ErrorMessage = "{0} deve ter entre {2} e {1} caracteres.")]

    public string Email { get; set; }
    [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
    [StringLength(100,
    MinimumLength = 3,
    ErrorMessage = "{0} deve ter entre {2} e {1} caracteres.")]
    public string Senha { get; set; }
}
