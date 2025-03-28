using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerandoAtivo.Dtos.Passivos
{
    public class PassivosResposta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Valor { get; set; }
        public int UsuarioId { get; set; }
    }
}