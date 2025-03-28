using GerandoAtivo.Dtos.Ativos;
using GerandoAtivo.Models;
using GerandoAtivo.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace GerandoAtivo.Services;

public class AtivoServico
{
    private readonly AtivoRepositorio _ativosRepositorio;
    public AtivoServico([FromServices] AtivoRepositorio repositorio)
    {
        _ativosRepositorio = repositorio;
    }


    public AtivosResposta CriarAtivos(AtivosCriarAtualizarRequisicao novoAtivos)
    {
        //copiar os dados da requisicao para o Modelo

        //----------------------------
        //var ativos = new Ativos();
        //ConverterRequisicaoParaModelo(novoAtivos, ativos);
        //-----------------------------
        var ativos = novoAtivos.Adapt<Ativos>();


        //Regras de negócio especificas para criar um procedimento

        //Enviar Procedimento para o Repositorio salvar no BD
        ativos = _ativosRepositorio.CriarAtivos(ativos);

        //Copiar do Modelo p/ a  resposta
        //-----------------------
        //var ativosResposta = ConverterModeloParaResposta(ativos);
        //---------------
        var ativosResposta = ativos.Adapt<AtivosResposta>();

        //retornar a resposta
        return ativosResposta;

    }

    public List<AtivosResposta> ListarAtivos()
    {
        //Pedir a Lista de ativo do repositorio
        var ativos = _ativosRepositorio.ListarAtivos();
        //COPIAR DA LISTA DE MODELO P/ LISTA DE RESPOSTA
        var ativosRespostas = ativos.Adapt<List<AtivosResposta>>();

        //Criar a lista de respostas
        //----------------------------------
        //List<ativosResposta> ativosRespostas = new();

        //Copiar os dados do Modelo (ativos) p/ a Resposta (ativosResposta)
        //foreach (var ativos in ativos)
        // {
        //Copiar de Modelo p/ Resposta
        //   var ativosResposta = ConverterModeloParaResposta(ativos);

        //Adicionar a resposta na Lista
        //   ativosRespostas.Add(ativosResposta);
        // }
        //------------------------------------   

        //Retornar a Lista de Respostas
        return ativosRespostas;

    }

    public AtivosResposta BuscarAtivosPeloId(int id)
    {
        //pedir ativo do repositorio
        var ativo = BuscarPeloId(id, false);

        //Copiar do Modelo (Ativos) para Resposta (AtivosResposta)
        //--- var ativosResposta = ConverterModeloParaResposta(ativos);
        return ativo.Adapt<AtivosResposta>();

        //retornando a Resposta
        //-- return ativosResposta;

    }

    //----------------------------------



    public void RemoverAtivos(int id)
    {
        //Buscar o ativo (modelo) pelo id

        var ativo = BuscarPeloId(id);

        //Mandar o repositorio remover o modelo
        _ativosRepositorio.RemoverAtivos(ativo);
    }

    public AtivosResposta AtualizarAtivo
     (int id, AtivosCriarAtualizarRequisicao AtivosEditado)
    {
        // Buscar o modelo mo repositorio
        var ativos = BuscarPeloId(id);

        //Copiar a Requisição para o Modelo
        //--ConverterRequisicaoParaModelo(AtivosEditado, Ativos);
        AtivosEditado.Adapt(ativos);

        //Mandar o repositorio Salvar
        _ativosRepositorio.AtualizarAtivos();

        //Copiar do Modelo p/ a Resposta
        //--return ConverterModeloParaResposta(Ativo);
        return ativos.Adapt<AtivosResposta>();

    }

    private Ativos BuscarPeloId(int id, bool tracking = true)
    {
        var ativo = _ativosRepositorio.BuscarAtivosPeloId(id, tracking);

        if (ativo is null)
        {
            throw new Exception("Ativo não encontrado!");
        }
        return ativo;
    }
}
