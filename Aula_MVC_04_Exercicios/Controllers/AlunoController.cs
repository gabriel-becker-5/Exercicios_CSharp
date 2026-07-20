using Aula_MVC_04_Exercicios.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aula_MVC_04_Exercicios.Models;
using Microsoft.AspNetCore.Authorization;

namespace Aula_MVC_04_Exercicios.Controllers
{
    [Authorize]
    [Route("aluno")]
    public class AlunoController : Controller
    {
        private readonly AppDbContext _context;
        public AlunoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? nomeAluno)
        {
            List<Aluno> alunos = await _context.Alunos.Where(a => a.Nome.Contains(nomeAluno)).ToListAsync();
            if (alunos.Count() == 0)
            {
                List<Aluno> todosAlunos = await _context.Alunos.ToListAsync();
                return View(todosAlunos);
            }
            return View(alunos);
        }

        [Authorize(Roles = "Professor,Admin")]
        [HttpPost("criar")]
        public async Task<IActionResult> Criar(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return View(aluno);
            }
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Professor,Admin")]
        [HttpGet("criar")]
        public IActionResult Criar()
        {
            return View();
        }

        [Authorize(Roles = "Professor,Admin")]
        [HttpGet("editar")]
        public async Task<IActionResult> Editar(int idAluno)
        {
            Aluno aluno = await _context.Alunos.FindAsync(idAluno);
            if (aluno == null) return NotFound("Aluno não matriculado.");
            return View(aluno);
        }

        [Authorize(Roles = "Professor,Admin")]
        [HttpPost("editar")]
        public async Task<IActionResult> Editar(int idAluno, Aluno model)
        {
            Aluno aluno = await _context.Alunos.FindAsync(idAluno);
            
            if (!ModelState.IsValid) 
            {
                return View(aluno);
            }

            if (aluno == null) return NotFound("Aluno não matriculado.");
            aluno.Nome = model.Nome;
            aluno.Telefone = model.Telefone;
            aluno.Email = model.Email;
            aluno.DataNascimento = model.DataNascimento;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Professor,Admin")]
        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int idAluno)
        {
            Aluno aluno = await _context.Alunos.FindAsync(idAluno);
            if (aluno == null) return NotFound("Aluno não matriculado.");
            return View(aluno);
        }

        [Authorize(Roles = "Professor,Admin")]
        [HttpPost("excluirConfirmado")]
        public async Task<IActionResult> ExcluirConfirmado(int idAluno)
        {
            Aluno aluno = await _context.Alunos.FindAsync(idAluno);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}