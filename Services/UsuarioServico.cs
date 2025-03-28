using GerandoAtivo.Dtos.Usuario;
using GerandoAtivo.Models;
using GerandoAtivo.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace GerandoAtivo.Services;

public class UsuarioServico
{

    //Campo que é injetado no construtor
    private readonly UsuarioRepositorio _usuarioRepositorio;

    //Construtor com injecao de dependencia
    public UsuarioServico([FromServices] UsuarioRepositorio repositorio)
    {
        _usuarioRepositorio = repositorio;
    }

    public UsuarioResposta CriarUsuario(UsuarioCriarAtualizarRequisicao novoUsuario)
    {
        //copiar os dados da requisicao para o Modelo

        //----------------------------
        //var usuario = new Usuario();
        //ConverterRequisicaoParaModelo(novoUsuario, usuario);
        //-----------------------------
        var usuario = novoUsuario.Adapt<Usuario>();


        //Regras de negócio especificas para criar um procedimento

        //Enviar Procedimento para o Repositorio salvar no BD
        usuario = _usuarioRepositorio.CriarUsuario(usuario);

        //Copiar do Modelo p/ a  resposta
        //-----------------------
        //var usuarioResposta = ConverterModeloParaResposta(usuario);
        //---------------
        var usuarioResposta = usuario.Adapt<UsuarioResposta>();

        //retornar a resposta
        return usuarioResposta;

    }

    public List<UsuarioResposta> ListarUsuarios()
    {
        //Pedir a Lista de usuarios do repositorio
        var usuarios = _usuarioRepositorio.ListarUsuarios();
        //COPIAR DA LISTA DE MODELO P/ LISTA DE RESPOSTA
        var usuarioRespostas = usuarios.Adapt<List<UsuarioResposta>>();

        //Criar a lista de respostas
        //----------------------------------
        //List<UsuarioResposta> usuarioRespostas = new();

        //Copiar os dados do Modelo (Usuario) p/ a Resposta (UsuarioResposta)
        //foreach (var usuario in usuarios)
        // {
        //Copiar de Modelo p/ Resposta
        //   var usuarioResposta = ConverterModeloParaResposta(usuario);

        //Adicionar a resposta na Lista
        //   usuarioRespostas.Add(usuarioResposta);
        // }
        //------------------------------------   

        //Retornar a Lista de Respostas
        return usuarioRespostas;

    }
    // //---pode apagar
    //     private UsuarioResposta ConverterModeloParaResposta(Usuario modelo)
    //     {
    //         var usuarioResposta = new UsuarioResposta();
    //         usuarioResposta.Id = modelo.Id;
    //         usuarioResposta.Nome = modelo.Nome;

    //         return usuarioResposta;
    //     }
    //--ate aqui

    public UsuarioResposta BuscarUsuarioPeloId(int id)
    {
        //pedir usuario do repositorio
        var usuario = BuscarPeloId(id, false);

        //Copiar do Modelo (Usuario) para Resposta (UsuarioResposta)
        //--- var usuarioResposta = ConverterModeloParaResposta(usuario);
        return usuario.Adapt<UsuarioResposta>();

        //retornando a Resposta
        //-- return usuarioResposta;

    }

    public void RemoverUsuario(int id)
    {
        //Buscar o usuario (modelo) pelo id

        var usuario = BuscarPeloId(id);

        //Mandar o repositorio remover o modelo
        _usuarioRepositorio.RemoverUsuario(usuario);
    }

    public UsuarioResposta AtualizarUsuario
     (int id, UsuarioCriarAtualizarRequisicao usuarioEditado)
    {
        // Buscar o modelo mo repositorio
        var usuario = BuscarPeloId(id);

        //Copiar a Requisição para o Modelo
        //--ConverterRequisicaoParaModelo(usuarioEditado, usuario);
        usuarioEditado.Adapt(usuario);


        //Mandar o repositorio Salvar
        _usuarioRepositorio.AtualizarUsuario();

        //Copiar do Modelo p/ a Resposta
        //--return ConverterModeloParaResposta(usuario);
        return usuario.Adapt<UsuarioResposta>();

    }
    //--Pode apagar
    // private void ConverterRequisicaoParaModelo
    //   (UsuarioCriarAtualizarRequisicao requisicao, Usuario modelo)
    // {
    //     modelo.Nome = requisicao.Nome;
    //     modelo.Email = requisicao.Email;
    // }
    //--Ate aqui

    private Usuario BuscarPeloId(int id, bool tracking = true)
    {
        var usuario = _usuarioRepositorio.BuscarUsuarioPeloId(id, tracking);

        if (usuario is null)
        {
            throw new Exception("Usuario não encontrado!");
        }
        return usuario;
    }

}


