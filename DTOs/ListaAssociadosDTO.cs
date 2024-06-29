using ProAuto.Models;

namespace ProAuto.DTOs
{
    public record ListaAssociadosDTO
    {
        public List<Associado>? Associados {get;set;}
        
    }
}