using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProAuto.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        [Required]
        public String? Placa { get; set; }
    }
}