using Microsoft.AspNetCore.Mvc;
using ProAuto.DTOs;
using ProAuto.Helpers;
using ProAuto.Interfaces.Services;
using ProAuto.Models;

namespace ProAuto.Controllers
{
    public class EnderecosController : Controller
    {
        private IEnderecoService _enderecoService;

        public EnderecosController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(EditarAssociadoDTO dto)
        {
            String tipoAlerta = Enum.GetName(TipoAlerta.SUCESSO)!;
            String mensagem = Mensagens.SUCESSO_ENDERECO;
            if (ModelState.IsValid)
            {
                await _enderecoService.Salvar(dto.NovoEndereco!);
            }
            return RedirectToAction("editar", "associados", new
            {
                id = dto.NovoEndereco!.AssociadoId,
                tipoAlerta,
                mensagem
            });
        }
    }
}
