using GerandoAtivo.Services;
using Microsoft.AspNetCore.Mvc;
using GerandoAtivo.Dtos.Passivos;
using Microsoft.AspNetCore.Authorization;

namespace GerandoAtivo.Controllers;
[ApiController]
[Route("passivo")]
[Authorize]
public class PassivoCotroller : ControllerBase
{
    private readonly PassivosServico _passivoServico;
    public PassivoCotroller([FromServices] PassivosServico servico)
    {
        _passivoServico = servico;
    }

    [HttpPost]
    public ActionResult<PassivosResposta> PostPassivos([FromBody] PassivosCriarAtualizarRequisicao novoPassivos)
    {
        // Enviar para o serviço
        var passivosResposta = _passivoServico.CriarPassivos(novoPassivos);
        //retornando a resposta
        //return usuarioResposta;
        return StatusCode(201, passivosResposta);
        // return CreatedAtAction(nameof(GetAtivos), new { id = ativosResposta.Id }, ativosResposta);
    }

    [HttpGet]
    public ActionResult<List<PassivosResposta>> GetPassivos()
    {
        return Ok(_passivoServico.ListarPassivos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<PassivosResposta> GetPassivos([FromRoute] int id)
    {
        try
        {
            //Buscando e retornando usuario a partir do Serviço
            return Ok(_passivoServico.BuscarPassivosPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message); //vai ser modificado daqui a pouco.
        }


    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletePassivo([FromRoute] int id)
    {

        try
        {
            //Mando o servico remover o usuario
            _passivoServico.RemoverPassivos(id);

            return NoContent(); // 204 sucesso s/ conteudo
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }

    [HttpPut("{id:int}")]
    public ActionResult<PassivosResposta> PutPassivos
     ([FromRoute] int id, [FromBody] PassivosCriarAtualizarRequisicao passivoEditado)
    {

        try
        {
            return Ok(_passivoServico.AtualizarPassivos(id, passivoEditado));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }


    }

}
