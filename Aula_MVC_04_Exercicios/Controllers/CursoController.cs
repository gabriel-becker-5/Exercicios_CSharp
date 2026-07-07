using Aula_MVC_04_Exercicios.Data;
using Aula_MVC_04_Exercicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula_MVC_04_Exercicios.Controllers
{
    [Route("curso")]
    public class CursoController : Controller
    {
        private readonly AppDbContext _context;
        public CursoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cursos = await _context.Cursos.OrderByDescending(c => c.CargaHoraria).ToListAsync();
            return View(cursos);
        }

        [HttpGet("cadastrar")]
        public IActionResult CriarCurso()
        {
            return View();
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CriarCurso(Curso curso)
        {
            if (curso.CargaHoraria <= 0)
            {
                return NotFound("Informe uma carga horária válida.");
            }           
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            TempData["msg_Create_Sucess"] = $"Curso '{curso.Nome}' cadastrado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet("editar")]
        public async Task<IActionResult> EditarCurso(int idCurso)
        {
            var curso = await _context.Cursos.FindAsync(idCurso);
            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return View(curso);
        }

        [HttpPost("editar")]
        public async Task<IActionResult> EditarCurso(int idCurso, Curso dados)
        {
            if (dados.CargaHoraria <= 0)
            {
                return NotFound("Informe uma carga horária válida.");
            }

            Curso curso = await _context.Cursos.FindAsync(idCurso);

            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }

            curso.Nome = dados.Nome;
            curso.CargaHoraria = dados.CargaHoraria;
            await _context.SaveChangesAsync();
            TempData["msg_Edit_Sucess"] = "Alterações salvas com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet("excluir")]
        public async Task<IActionResult> ExcluirCurso(int idCurso)
        {
            var curso = await _context.Cursos.FindAsync(idCurso);
            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return View(curso);
        }

        [HttpPost("excluir")]
        public async Task<IActionResult> ExcluirConfirmado(int idCurso)
        {
            var curso = await _context.Cursos.FindAsync(idCurso);
            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            TempData["msg_Delete"] = $"Curso '{curso.Nome}' deletado da base de dados.";
            return RedirectToAction("Index");
        }
    }
}