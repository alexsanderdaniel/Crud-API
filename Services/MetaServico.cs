using GerandoAtivo.Repositorios;
using Microsoft.AspNetCore.Mvc;
using GerandoAtivo.Dtos.Meta;
using GerandoAtivo.Models;
using Mapster;

namespace GerandoAtivo.Services;

public class MetaServico
{
    private readonly MetaRepositorio _metaRepositorio;

    public MetaServico([FromServices] MetaRepositorio repositorio)
    {
        _metaRepositorio = repositorio;
    }
    public MetaResposta CriarMeta(MetaCriarAtualizarRequisicao novoMeta)
    {
        //copiar os dados da requisicao para o Modelo

        //----------------------------
        //var usuario = new Usuario();
        //ConverterRequisicaoParaModelo(novoUsuario, usuario);
        //-----------------------------
        var meta = novoMeta.Adapt<Meta>();


        //Regras de negócio especificas para criar um procedimento

        //Enviar Procedimento para o Repositorio salvar no BD
        meta = _metaRepositorio.CriarMeta(meta);

        //Copiar do Modelo p/ a  resposta
        //-----------------------
        //var metaResposta = ConverterModeloParaResposta(meta);
        //---------------
        var metaResposta = meta.Adapt<MetaResposta>();

        //retornar a resposta
        return metaResposta;

    }

    public List<MetaResposta> ListarMeta()
    {
        //Pedir a Lista de ativo do repositorio
        var meta = _metaRepositorio.ListarMeta();
        //COPIAR DA LISTA DE MODELO P/ LISTA DE RESPOSTA
        var metaRespostas = meta.Adapt<List<MetaResposta>>();

        //Criar a lista de respostas
        //----------------------------------
        //List<metaResposta> metaRespostas = new();

        //Copiar os dados do Modelo (meta) p/ a Resposta (metaResposta)
        //foreach (var meta in meta)
        // {
        //Copiar de Modelo p/ Resposta
        //   var metaResposta = ConverterModeloParaResposta(meta);

        //Adicionar a resposta na Lista
        //   metaRespostas.Add(metaResposta);
        // }
        //------------------------------------   

        //Retornar a Lista de Respostas
        return metaRespostas;

    }

    public MetaResposta BuscarMetaPeloId(int id)
    {
        //pedir ativo do repositorio
        var ativo = BuscarPeloId(id, false);

        //Copiar do Modelo (Meta) para Resposta (MetaResposta)
        //--- var metaResposta = ConverterModeloParaResposta(ativos);
        return ativo.Adapt<MetaResposta>();

        //retornando a Resposta
        //-- return usuarioResposta;

    }

    public void RemoverMeta(int id)
    {
        //Buscar o meta (modelo) pelo id

        var meta = BuscarPeloId(id);

        //Mandar o repositorio remover o modelo
        _metaRepositorio.RemoverMeta(meta);
    }

    public MetaResposta AtualizarMeta
     (int id, MetaCriarAtualizarRequisicao metaEditado)
    {
        // Buscar o modelo mo repositorio
        var meta = BuscarPeloId(id);

        //Copiar a Requisição para o Modelo
        //--ConverterRequisicaoParaModelo(metaEditado, meta);
        metaEditado.Adapt(meta);


        //Mandar o repositorio Salvar
        _metaRepositorio.AtualizarMeta();

        //Copiar do Modelo p/ a Resposta
        //--return ConverterModeloParaResposta(meta);
        return meta.Adapt<MetaResposta>();
    }

    private Meta BuscarPeloId(int id, bool tracking = true)
    {
        var met = _metaRepositorio.BuscarMetaPeloId(id, tracking);

        if (met is null)
        {
            throw new Exception("Meta não encontrada!");
        }
        return met;
    }
}
