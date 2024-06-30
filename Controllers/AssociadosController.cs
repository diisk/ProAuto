using Microsoft.AspNetCore.Mvc;
using ProAuto.DTOs;
using ProAuto.Exceptions;
using ProAuto.Helpers;
using ProAuto.Interfaces.Services;
using ProAuto.Models;

namespace ProAuto.Controllers
{
    public class AssociadosController : Controller
    {
        private IAssociadoService _associadoService;
        private IVeiculoService _veiculoService;

        public AssociadosController(IAssociadoService associadoService, IVeiculoService veiculoService)
        {
            _associadoService = associadoService;
            _veiculoService = veiculoService;
        }

        public async Task<IActionResult> Listar()
        {
            ListaAssociadosDTO dto = new ListaAssociadosDTO();
            dto.Associados = await _associadoService.FindAll();
            dto.Associados = dto.Associados.OrderBy(ass => ass.Nome).ToList();
            return View(dto);
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(CreateAssociadoDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _associadoService.Create(dto);
                    return RedirectToAction(nameof(Listar), new
                    {
                        tipoAlerta = Enum.GetName(TipoAlerta.SUCESSO),
                        mensagem = Mensagens.SUCESSO_ASSOCIADO
                    });
                }
                catch (RegistrarAssociadoException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(dto);
        }

        public IActionResult Pesquisar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pesquisar(PesquisarDTO dto)
        {

            if (ModelState.IsValid)
            {

                Associado? associado = await _associadoService.PesquisarAssociado(dto);
                if (associado != null)
                    return RedirectToAction(nameof(Editar), new { id = associado.Id });

                ModelState.AddModelError(String.Empty, Mensagens.ERRO_DADOS_INVALIDOS);


            }
            return View(dto);
        }


        public async Task<IActionResult> Editar(int id)
        {

            Associado? associado = await _associadoService.FindById(id);
            if (associado == null)
                return NotFound();

            EditarAssociadoDTO dto = new EditarAssociadoDTO();
            dto.Associado = associado;
            dto.NovoEndereco = associado.Endereco;
            dto.NovoVeiculo = new Veiculo(associado.Id);


            return View(dto);
        }
    }
}
