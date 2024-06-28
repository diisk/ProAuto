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
        public String? Placa { get; set; }

        public int AssociadoId { get; set; }

        public Associado? Associado { get; set; }

        public Veiculo(){}

        public Veiculo(String placa){
            this.Placa = placa;
        }
    }
}