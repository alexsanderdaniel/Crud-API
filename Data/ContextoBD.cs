using GerandoAtivo.Models;
using Microsoft.EntityFrameworkCore;

namespace GerandoAtivo.Data;

public class ContextoBD : DbContext
{

    //CONSTRUTOR QUI RECEBE AS CONFIG DO ACESSO AO BD
    //ESSAS CONFIG VEM DA PROGRAM.CS
    public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
    {
    }

    //TABELAS
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Meta> Metas { get; set; }
    public DbSet<Ativos> Ativos { get; set; }
    public DbSet<Passivos> Passivos { get; set; }

}
