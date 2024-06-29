using Microsoft.AspNetCore.Mvc;
using ProAuto.DTOs;
using ProAuto.Helpers;
using ProAuto.Interfaces.Services;
using ProAuto.Models;

namespace ProAuto.Controllers
{
    public class VeiculosController : Controller
    {
        private IVeiculoService _veiculoService;

        public VeiculosController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(EditarAssociadoDTO dto)
        {
            Veiculo veiculo = dto.NovoVeiculo!;
            String tipoAlerta = Enum.GetName(TipoAlerta.SUCESSO)!;
            String mensagem = Mensagens.SUCESSO_VEICULO;
            if (ModelState.IsValid)
            {
                if (await _veiculoService.PesquisarVeiculo(veiculo.Placa!) == null)
                {
                    await _veiculoService.Salvar(veiculo);
                }
                else
                {
                    tipoAlerta = Enum.GetName(TipoAlerta.ERRO)!;
                    mensagem = Mensagens.ERRO_VEICULO_CADASTRADO;
                }


            }
            return RedirectToAction("editar", "associados", new
            {
                id = veiculo.AssociadoId,
                tipoAlerta,
                mensagem
            });
        }
    }
}
