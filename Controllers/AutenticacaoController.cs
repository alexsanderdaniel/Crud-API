using GerandoAtivo.Dtos.Usuario;
using GerandoAtivo.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerandoAtivo.Controllers
{
    [ApiController]
    [Route("autenticacao")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AutenticacaoServico _autenticacaoServico;

        public AutenticacaoController([FromServices] AutenticacaoServico servico)
        {
            _autenticacaoServico = servico;
        }

        [HttpPost]
        public ActionResult<string> Login([FromBody] UsuarioLoginRequisicao usuarioLogin)
        {
            try
            {
                var tokenJWT = _autenticacaoServico.Login(usuarioLogin);
                return Ok(tokenJWT);
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}