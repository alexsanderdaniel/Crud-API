using GerandoAtivo.Data;
using Microsoft.AspNetCore.Mvc;
using GerandoAtivo.Models;
using Microsoft.EntityFrameworkCore;

namespace GerandoAtivo.Repositorios;

public class MetaRepositorio
{
    private readonly ContextoBD _contexto;
    public MetaRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Meta CriarMeta(Meta meta)
    {
        //Manda o contexto salvar no BD
        _contexto.Metas.Add(meta);
        _contexto.SaveChanges();
        //vai estar preenchido com a chave primaria
        return meta;
    }

    public List<Meta> ListarMeta()
    {
        return _contexto.Metas.AsNoTracking().ToList();
    }

    public Meta BuscarMetaPeloId(int id, bool tracking = true)
    {
        //Buscar pelo id no contexto
        return (tracking) ?
        _contexto.Metas.FirstOrDefault(meta => meta.Id == id) :
         _contexto.Metas.AsNoTracking().FirstOrDefault(meta => meta.Id == id);

    }


    public void RemoverMeta(Meta meta)
    {
        //Mandar o contexto remover
        _contexto.Remove(meta);
        _contexto.SaveChanges();
    }

    public void AtualizarMeta()
    {
        _contexto.SaveChanges();
    }

}
