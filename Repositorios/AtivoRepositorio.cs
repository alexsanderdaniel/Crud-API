using GerandoAtivo.Data;
using GerandoAtivo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerandoAtivo.Repositorios;

public class AtivoRepositorio
{
    private readonly ContextoBD _contexto;

    public AtivoRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }


    public Ativos CriarAtivos(Ativos ativos)
    {
        //Manda o contexto salvar no BD
        _contexto.Ativos.Add(ativos);
        _contexto.SaveChanges();
        //vai estar preenchido com a chave primaria
        return ativos;
    }

    public List<Ativos> ListarAtivos()
    {
        return _contexto.Ativos.AsNoTracking().ToList();
    }

    public Ativos BuscarAtivosPeloId(int id, bool tracking = true)
    {
        //Buscar pelo id no contexto
        return (tracking) ?
        _contexto.Ativos.FirstOrDefault(ativos => ativos.Id == id) :
         _contexto.Ativos.AsNoTracking().FirstOrDefault(ativos => ativos.Id == id);

    }


    public void RemoverAtivos(Ativos ativos)
    {
        //Mandar o contexto remover
        _contexto.Remove(ativos);
        _contexto.SaveChanges();
    }

    public void AtualizarAtivos()
    {
        _contexto.SaveChanges();
    }


}
