using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerandoAtivo.Models;

public class Ativos
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Descricao { get; set; }
    [Required]

    public int Valor { get; set; }

    //PROPIEDADE DE NAVEGAÇÃO
    public Usuario Usuario { get; set; }


    //CHAVE ESTRANGEIRA
    public int UsuarioId { get; set; }




}
