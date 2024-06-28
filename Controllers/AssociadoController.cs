using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProAuto.Data;
using ProAuto.DTOs;
using ProAuto.Exceptions;
using ProAuto.Helpers;
using ProAuto.Interfaces.Services;
using ProAuto.Models;

namespace ProAuto.Controllers
{
    public class AssociadoController : Controller
    {
        private IAssociadoService _associadoService;

        public AssociadoController(IAssociadoService associadoService)
        {
            _associadoService = associadoService;
        }

        public async Task<IActionResult> Listar()
        {
            ListaAssociadosDTO associadoViewModel = new ListaAssociadosDTO();
            associadoViewModel.Associados = await _associadoService.FindAll();
            return View(associadoViewModel);
        }

        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var associado = await _context.Associado
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (associado == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(associado);
        // }

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
                    return RedirectToAction(nameof(Listar));
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
            dto.NovoEndereco = new Endereco(associado.Endereco!);


            return View(dto);
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Editar(EditarAssociadoDTO dto)
        // {
        //     if (dto.Associado == null)
        //         return NotFound();

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(associado);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!AssociadoExists(associado.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(associado);
        // }

        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var associado = await _context.Associado
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (associado == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(associado);
        // }

        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var associado = await _context.Associado.FindAsync(id);
        //     if (associado != null)
        //     {
        //         _context.Associado.Remove(associado);
        //     }

        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool AssociadoExists(int id)
        // {
        //     return _context.Associado.Any(e => e.Id == id);
        // }
    }
}
