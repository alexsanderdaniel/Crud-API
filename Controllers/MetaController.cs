using GerandoAtivo.Services;
using Microsoft.AspNetCore.Mvc;
using GerandoAtivo.Dtos.Meta;
using Microsoft.AspNetCore.Authorization;

namespace GerandoAtivo.Controllers;
[ApiController]
[Route("meta")]
[Authorize]
public class MetaController : ControllerBase
{
    private readonly MetaServico _metaServico;
    public MetaController([FromServices] MetaServico servico)
    {
        _metaServico = servico;
    }

    [HttpPost]
    public ActionResult<MetaResposta> PostMeta([FromBody] MetaCriarAtualizarRequisicao novoMeta)
    {
        // Enviar para o serviço
        var ativoResposta = _metaServico.CriarMeta(novoMeta);
        //retornando a resposta
        //return usuarioResposta;
        return StatusCode(201, ativoResposta);
        // return CreatedAtAction(nameof(GetMeta), new { id = ativosResposta.Id }, ativosResposta);
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult<List<MetaResposta>> GetMeta()
    {
        return Ok(_metaServico.ListarMeta());
    }

    [HttpGet("{id:int}")]
    public ActionResult<MetaResposta> GetMeta([FromRoute] int id)
    {
        try
        {
            //Buscando e retornando usuario a partir do Serviço
            return Ok(_metaServico.BuscarMetaPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message); //vai ser modificado daqui a pouco.
        }


    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteMeta([FromRoute] int id)
    {

        try
        {
            _metaServico.RemoverMeta(id);

            return NoContent(); // 204 sucesso s/ conteudo
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }

    [HttpPut("{id:int}")]
    public ActionResult<MetaResposta> PutMeta
     ([FromRoute] int id, [FromBody] MetaCriarAtualizarRequisicao MetaEditado)
    {

        try
        {
            return Ok(_metaServico.AtualizarMeta(id, MetaEditado));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

}
