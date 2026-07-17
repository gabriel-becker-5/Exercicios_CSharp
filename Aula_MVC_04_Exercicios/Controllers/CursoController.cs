using Aula_MVC_04_Exercicios.Data;
using Aula_MVC_04_Exercicios.Interfaces;
using Aula_MVC_04_Exercicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula_MVC_04_Exercicios.Controllers
{
    [Route("curso")]
    public class CursoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICalculadoraCargaHorariaService _calculadoraCargaHoraria;

        public CursoController(AppDbContext context, ICalculadoraCargaHorariaService calculadoracargahoraria)
        {
            _context = context;
            _calculadoraCargaHoraria = calculadoracargahoraria;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? nomeCurso)
        {
            List<Curso> cursos = await _context.Cursos.Where(c => c.Nome.Contains(nomeCurso)).ToListAsync();
            if (cursos.Count() == 0)
            {
                List<Curso> todosCursos = await _context.Cursos.ToListAsync();
                return View(todosCursos);
            }
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
            if (!ModelState.IsValid)
            {
                return View(curso);
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

            int diasDeCurso = _calculadoraCargaHoraria.ConverterHorasEmDias(curso.CargaHoraria);
            ViewBag.diasDeCurso = diasDeCurso;
            return View(curso);
        }

        [HttpPost("editar")]
        public async Task<IActionResult> EditarCurso(int idCurso, Curso dados)
        {
            Curso curso = await _context.Cursos.FindAsync(idCurso);
            
            if (!ModelState.IsValid)
            {
                return View(curso);
            }

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