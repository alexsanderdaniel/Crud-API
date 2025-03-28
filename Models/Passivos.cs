using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerandoAtivo.Models;

public class Passivos
{
    [Required]
    public int Id { get; set; }

    [Column(TypeName = "text")]
    public string Descricao { get; set; }
    [Required]
    public int Valor { get; set; }


    //CHAVE ESTRANGEIRA
    public int UsuarioId { get; set; }

}
