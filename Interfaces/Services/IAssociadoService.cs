using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAuto.DTOs;
using ProAuto.Models;

namespace ProAuto.Interfaces.Services
{
    public interface IAssociadoService
    {
        public Task<Associado> Create(CreateAssociadoDTO dto);

        public Task<List<Associado>> FindAll();
        public Task<Associado?> FindById(int id);
        public Task<Associado?> PesquisarAssociado(PesquisarDTO dto);


    }
}