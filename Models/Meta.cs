using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerandoAtivo.Models;

public class Meta
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "text")]
    public string Descricao { get; set; }

    public DateTime Prazo { get; set; }

    //PROPIEDADE DE NAVEGAÇAO


    //CHAVE ESTRANGEIRA
    public int UsuarioId { get; set; }


}
