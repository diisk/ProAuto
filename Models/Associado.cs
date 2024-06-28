using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProAuto.DTOs;
using ProAuto.Helpers;

namespace ProAuto.Models
{
    public class Associado
    {
        public int Id { get; set; }
        public String? Nome { get; set; }
        public String? CPF { get; set; }
        public String? Telefone { get; set; }
        public List<Veiculo>? Veiculos { get; set; }
        public Endereco? Endereco { get; set; }

        public Associado() { }

        public Associado(CreateAssociadoDTO dto, Endereco endereco, List<Veiculo> veiculos)
        {
            this.Nome = dto.Nome;
            this.CPF = Utils.ApenasNumeros(dto.CPF!);
            this.Telefone = Utils.ApenasNumeros(dto.Telefone!);
            this.Endereco = endereco;
            this.Veiculos = veiculos;
        }


    }
}