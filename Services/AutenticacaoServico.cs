using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GerandoAtivo.Dtos.Usuario;
using GerandoAtivo.Models;
using GerandoAtivo.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GerandoAtivo.Services
{
    public class AutenticacaoServico
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly IConfiguration _configuration;
        public AutenticacaoServico([FromServices] UsuarioRepositorio repositorio,
        [FromServices] IConfiguration configuration)
        {
            _usuarioRepositorio = repositorio;
            _configuration = configuration;
        }
        public string Login(UsuarioLoginRequisicao usuarioLogin)
        {
            var usuario = _usuarioRepositorio.BuscarUsuarioPeloEmail(usuarioLogin.Email);

            if (usuario is null)
            {
                throw new Exception("Usuario ou senha não encontrado");
            }

            var tokenJWT = GerarJWT(usuario);
            return "token";
        }

        private string GerarJWT(Usuario usuario)
        {
            var JWTChave = Encoding.ASCII.GetBytes(_configuration["JWTChave"]);

            var credenciais = new SigningCredentials(
                    new SymmetricSecurityKey(JWTChave),
                    SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, usuario.Nome));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));

            claims.Add(new Claim(ClaimTypes.Role, usuario.Nome));

            var tokenJWT = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credenciais,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenJWT);
        }

    }
}