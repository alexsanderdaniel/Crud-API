using GerandoAtivo.Data;
using Microsoft.AspNetCore.Mvc;
using GerandoAtivo.Models;
using Microsoft.EntityFrameworkCore;

namespace GerandoAtivo.Repositorios;

public class PassivoRepositorio
{
    private readonly ContextoBD _contexto;
    public PassivoRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Passivos CriarPassivos(Passivos passivos)
    {
        //Manda o contexto salvar no BD
        _contexto.Passivos.Add(passivos);
        _contexto.SaveChanges();
        //vai estar preenchido com a chave primaria
        return passivos;
    }

    public List<Passivos> ListarPassivos()
    {
        return _contexto.Passivos.AsNoTracking().ToList();
    }

    public Passivos BuscarPassivosPeloId(int id, bool tracking = true)
    {
        //Buscar pelo id no contexto
        return (tracking) ?
        _contexto.Passivos.FirstOrDefault(passivos => passivos.Id == id) :
         _contexto.Passivos.AsNoTracking().FirstOrDefault(passivos => passivos.Id == id);

    }


    public void RemoverPassivos(Passivos passivos)
    {
        //Mandar o contexto remover
        _contexto.Remove(passivos);
        _contexto.SaveChanges();
    }

    public void AtualizarPassivos()
    {
        _contexto.SaveChanges();
    }

}
