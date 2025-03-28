using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerandoAtivo.Dtos.Meta
{
    public class MetaResposta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Prazo { get; set; }
        public int UsuarioId { get; set; }
    }
}