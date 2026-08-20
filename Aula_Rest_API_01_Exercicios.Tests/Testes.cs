using Aula_REST_API_01_Exercicios.Controllers;
using Aula_REST_API_01_Exercicios.Data;
using Aula_REST_API_01_Exercicios.Models;
using Aula_REST_API_01_Exercicios.Repositories;
using Aula_REST_API_01_Exercicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Aula_REST_API_01_Exercicios.Tests
{
    public class Testes
    {
        private AppDbContext CriarContextoDeTeste()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetTodos_RetornaProdutosCadastrados()
        {
            // Arrange
            var context = CriarContextoDeTeste();

            Produto novoProduto1 = new Produto
            {
                Nome = "Produto de Teste I",
                EmailFornecedor = "teste1@fornecedor.com",
                Preco = 999.99
            };

            Produto novoProduto2 = new Produto
            {
                Nome = "Produto de Teste II",
                EmailFornecedor = "teste2@fornecedor.com",
                Preco = 9999.99
            };

            await context.Produtos.AddAsync(novoProduto1);
            await context.Produtos.AddAsync(novoProduto2);
            await context.SaveChangesAsync();
            ProdutoRepository produtoRepository = new ProdutoRepository(context);

            // Act
            List<Produto> resultado = await produtoRepository.GetTodosAsync();

            // Assert
            Assert.Equal(2, resultado.Count);
        }


        [Fact]
        public async Task GetPorId_ProdutoNaoEncontrado_RetornaNull()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            ProdutoRepository produtoRepository = new ProdutoRepository(context);

            // Act
            Produto? resultado = await produtoRepository.GetPorIdAsync(999);

            // Assert
            Assert.True(resultado == null);
        }

        [Fact]
        public async Task GetPorId_ProdutoEncontrado_RetornaProduto()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            ProdutoRepository produtoRepository = new ProdutoRepository(context);

            Produto novoProduto1 = new Produto
            {
                Nome = "Produto de Teste I",
                EmailFornecedor = "teste1@fornecedor.com",
                Preco = 999.99
            };

            await context.Produtos.AddAsync(novoProduto1);
            await context.SaveChangesAsync();

            // Act
            Produto? resultado = await produtoRepository.GetPorIdAsync(1);

            // Assert
            Assert.IsType<Produto>(resultado);
            Assert.Equal(1, resultado.Id);
        }

        [Fact]
        public async Task CriarProduto_Retorna_CreatedAtAction()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            ProdutoRepository produtoRepository = new ProdutoRepository(context);
            ProdutoService produtoService = new ProdutoService(produtoRepository);
            ProdutosController produtosController = new ProdutosController(produtoService);

            ProdutoDto novoProduto = new ProdutoDto
            {
                Nome = "Produto de Teste I",
                EmailFornecedor = "teste1@fornecedor.com",
                Preco = 999.99
            };

            // Act
            var resultado = await produtosController.CriarAsync(novoProduto);

            // Assert
            Assert.IsType<CreatedAtActionResult>(resultado);
        }

        [Theory]
        [InlineData(-1d, false)]
        [InlineData(0d, false)]
        [InlineData(999999d, false)]
        [InlineData(1000, true)]
        public async Task CriarProduto_PrecosInvalidos_e_PrecosValidos(double preco, bool ehValido)
        {
            // Arrange
            var context = CriarContextoDeTeste();
            ProdutoRepository produtoRepository = new ProdutoRepository(context);
            ProdutoService produtoService = new ProdutoService(produtoRepository);
            ProdutosController produtosController = new ProdutosController(produtoService);

            ProdutoDto novoProduto = new ProdutoDto
            {
                Nome = "Produto de Teste I",
                EmailFornecedor = "teste1@fornecedor.com",
                Preco = preco
            };

            ValidarModelState(produtosController, novoProduto);

            // Act
            var resultado = await produtosController.CriarAsync(novoProduto);

            // Assert
            if (ehValido)
                Assert.IsNotType<BadRequestResult>(resultado);
            else
                Assert.IsType<BadRequestResult>(resultado);
        }

        private static void ValidarModelState(ControllerBase controller, object model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(model, context, results, true))
            {
                foreach (var erro in results)
                    controller.ModelState.AddModelError(erro.MemberNames.FirstOrDefault() ?? "", erro.ErrorMessage ?? "");
            }
        }
    }
}