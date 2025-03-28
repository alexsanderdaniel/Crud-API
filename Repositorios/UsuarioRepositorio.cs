using GerandoAtivo.Data;
using GerandoAtivo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerandoAtivo.Repositorios;

public class UsuarioRepositorio
{

    //Campo que vai ser injetado no construtor
    private readonly ContextoBD _contexto;

    //Construtor que injeta a dependencia
    public UsuarioRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Usuario CriarUsuario(Usuario usuario)
    {
        //Manda o contexto salvar no BD
        _contexto.Usuarios.Add(usuario);
        _contexto.SaveChanges();
        //vai estar preenchido com a chave primaria
        return usuario;
    }

    public List<Usuario> ListarUsuarios()
    {
        return _contexto.Usuarios.AsNoTracking().ToList();
    }

    public Usuario BuscarUsuarioPeloId(int id, bool tracking = true)
    {
        //Buscar pelo id no contexto
        return (tracking) ?
        _contexto.Usuarios.FirstOrDefault(usuario => usuario.Id == id) :
         _contexto.Usuarios.AsNoTracking().FirstOrDefault(usuario => usuario.Id == id);



        //-- Pode apagar return _contexto.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

    }

    public Usuario BuscarUsuarioPeloEmail(string email, bool tracking = true)
    {
        //Buscar pelo id no contexto
        return (tracking) ?
        _contexto.Usuarios.FirstOrDefault(usuario => usuario.Email == email) :
         _contexto.Usuarios.AsNoTracking().FirstOrDefault(usuario => usuario.Email == email);



        //-- Pode apagar return _contexto.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

    }

    public void RemoverUsuario(Usuario usuario)
    {
        //Mandar o contexto remover
        _contexto.Remove(usuario);
        _contexto.SaveChanges();
    }

    public void AtualizarUsuario()
    {
        _contexto.SaveChanges();
    }
}
