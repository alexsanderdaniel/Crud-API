using GerandoAtivo.Repositorios;
using Microsoft.AspNetCore.Mvc;
using GerandoAtivo.Dtos.Passivos;
using GerandoAtivo.Models;
using Mapster;

namespace GerandoAtivo.Services;

public class PassivosServico
{
    private readonly PassivoRepositorio _passivoRepositorio;
    public PassivosServico([FromServices] PassivoRepositorio repositorio)
    {
        _passivoRepositorio = repositorio;
    }

    public PassivosResposta CriarPassivos(PassivosCriarAtualizarRequisicao novoPassivos)
    {
        var passivos = novoPassivos.Adapt<Passivos>();

        passivos = _passivoRepositorio.CriarPassivos(passivos);

        var passivosResposta = passivos.Adapt<PassivosResposta>();

        return passivosResposta;
    }

    public List<PassivosResposta> ListarPassivos()
    {
        var passivos = _passivoRepositorio.ListarPassivos();

        var passivosRespostas = passivos.Adapt<List<PassivosResposta>>();

        return passivosRespostas;
    }

    public PassivosResposta BuscarPassivosPeloId(int id)
    {
        var passivo = BuscarPeloId(id, false);

        return passivo.Adapt<PassivosResposta>();
    }


    public void RemoverPassivos(int id)
    {
        var passivo = BuscarPeloId(id);

        _passivoRepositorio.RemoverPassivos(passivo);

    }

    public PassivosResposta AtualizarPassivos
     (int id, PassivosCriarAtualizarRequisicao passivosEditado)
    {
        var passivos = BuscarPeloId(id);

        passivosEditado.Adapt(passivos);

        _passivoRepositorio.AtualizarPassivos();

        return passivos.Adapt<PassivosResposta>();
    }

    private Passivos BuscarPeloId(int id, bool tracking = true)
    {
        var passivo = _passivoRepositorio.BuscarPassivosPeloId(id, tracking);

        if (passivo is null)
        {
            throw new Exception("Passivo não encontrado!");
        }
        return passivo;
    }
}
