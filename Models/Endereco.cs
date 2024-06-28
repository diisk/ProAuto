using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProAuto.DTOs;

namespace ProAuto.Models
{
    public class Endereco
    {
        public int Id { get; set;}
        public String? Complemento { get; set;}
        public String? Estado { get; set;}
        public String? Cidade { get; set;}
        public String? Bairro { get; set;}
        public String? Rua { get; set;}
        public int Numero { get; set;}
        public int AssociadoId { get; set; }
        public Associado? Associado { get; set; }

        public Endereco(){}

        public Endereco(CreateAssociadoDTO dto){
            this.Bairro = dto.Bairro;
            this.Cidade = dto.Cidade;
            this.Estado = dto.Estado;
            this.Complemento = dto.Complemento;
            this.Rua = dto.Rua;
            this.Numero = dto.Numero;
        }

        public Endereco(Endereco endereco){
            this.Bairro = endereco.Bairro;
            this.Cidade = endereco.Cidade;
            this.Estado = endereco.Estado;
            this.Complemento = endereco.Complemento;
            this.Rua = endereco.Rua;
            this.Numero = endereco.Numero;
        }
    }
}