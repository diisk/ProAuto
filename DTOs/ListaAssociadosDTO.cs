using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAuto.Models;

namespace ProAuto.DTOs
{
    public record ListaAssociadosDTO
    {
        public List<Associado>? Associados {get;set;}
        
    }
}