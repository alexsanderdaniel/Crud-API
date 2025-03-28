using GerandoAtivo.Dtos.Usuario;
using GerandoAtivo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerandoAtivo.Controllers;
[ApiController]
[Route("usuario")]
public class UsuarioController : ControllerBase
{
    //Injetado no construtor
    private readonly UsuarioServico _usuarioServico;
    //Construtor com injeção de Dependencia
    public UsuarioController([FromServices] UsuarioServico servico)
    {
        _usuarioServico = servico;
    }

    [HttpPost]
    public ActionResult<UsuarioResposta> PostUsuario([FromBody] UsuarioCriarAtualizarRequisicao novoUsuario)
    {
        // Enviar para o serviço
        var usuarioResposta = _usuarioServico.CriarUsuario(novoUsuario);
        //retornando a resposta
        //return usuarioResposta;
        //return StatusCode(201, usuarioResposta);
        return CreatedAtAction(nameof(GetUsuarios), new { id = usuarioResposta.Id }, usuarioResposta);
    }

    [HttpGet]
    public ActionResult<List<UsuarioResposta>> GetUsuarios()
    {
        //Pedir e retorna a Lista que vem do servico
        return Ok(_usuarioServico.ListarUsuarios());
    }

    [HttpGet("{id:int}")]
    public ActionResult<UsuarioResposta> GetUsuario([FromRoute] int id)
    {
        try
        {
            //Buscando e retornando usuario a partir do Serviço
            return Ok(_usuarioServico.BuscarUsuarioPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message); //vai ser modificado daqui a pouco.
        }


    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public ActionResult DeleteUsuario([FromRoute] int id)
    {

        try
        {
            //Mando o servico remover o usuario
            _usuarioServico.RemoverUsuario(id);

            return NoContent(); // 204 sucesso s/ conteudo
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }

    [HttpPut("{id:int}")]
    public ActionResult<UsuarioResposta> PutUsuario
     ([FromRoute] int id, [FromBody] UsuarioCriarAtualizarRequisicao usuarioEditado)
    {

        try
        {
            return Ok(_usuarioServico.AtualizarUsuario(id, usuarioEditado));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }


}
