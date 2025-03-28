using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerandoAtivo.Models;

public class Usuario
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Nome { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; }

    [Required]
    [Column(TypeName = "varchar(60)")]
    public string Senha { get; set; }

    //PROPIEDADE DE NAVEGACAO

    public List<Ativos> Ativos { get; set; }
    public List<Passivos> Passivos { get; set; }
    public List<Meta> Meta { get; set; }



}
