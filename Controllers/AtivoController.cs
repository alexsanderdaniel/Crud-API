using GerandoAtivo.Dtos.Ativos;
using GerandoAtivo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerandoAtivo.Controllers;
[ApiController]
[Route("ativo")]
[Authorize]
public class AtivoController : ControllerBase
{
    private readonly AtivoServico _ativoServico;
    public AtivoController([FromServices] AtivoServico servico)
    {
        _ativoServico = servico;
    }

    [HttpPost]
    public ActionResult<AtivosResposta> PostAtivos([FromBody] AtivosCriarAtualizarRequisicao novoAtivos)
    {
        // Enviar para o serviço
        var ativoResposta = _ativoServico.CriarAtivos(novoAtivos);
        //retornando a resposta
        //return usuarioResposta;
        return StatusCode(201, ativoResposta);
        // return CreatedAtAction(nameof(GetAtivos), new { id = ativosResposta.Id }, ativosResposta);
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult<List<AtivosResposta>> GetAtivos()
    {
        return Ok(_ativoServico.ListarAtivos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<AtivosResposta> GetAtivos([FromRoute] int id)
    {
        try
        {
            return Ok(_ativoServico.BuscarAtivosPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteAtivo([FromRoute] int id)
    {
        try
        {
            //Mando o servico remover o usuario
            _ativoServico.RemoverAtivos(id);

            return NoContent(); // 204 sucesso s/ conteudo
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<AtivosResposta> PutAtivos
     ([FromRoute] int id, [FromBody] AtivosCriarAtualizarRequisicao ativoEditado)
    {

        try
        {
            return Ok(_ativoServico.AtualizarAtivo(id, ativoEditado));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

}
