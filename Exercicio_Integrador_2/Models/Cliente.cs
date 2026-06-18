using Exercicio_Integrador_2.Models;

namespace Exercicio_Integrador_2.Pessoas
{
    public class Cliente : Pessoa
    {
        public DateTime DataCadastro { get; private set; }
        public decimal TotalGasto {  get; private set; }
        public TipoDeCliente TipoCliente { get; private set; }
        public string NomeEmpresa { get; private set; }
        public int QuantidadeVeiculos { get; private set; }

        // Construtor Cliente Padrão e VIP
        public Cliente(int id, string nome, string telefone, string email, TipoDeCliente tipocliente) 
            : base(id, nome, telefone, email)
        {
            DataCadastro = DateTime.UtcNow;
            TotalGasto = 0;
            TipoCliente = tipocliente;
        }

        // Construtor Cliente Frotista - campos adicionais Nome Empresa e Qtd. Veículos
        public Cliente(int id, string nome, string telefone, string email, TipoDeCliente tipocliente, string nomeempresa, int qtdveiculos) 
            : base(id, nome, telefone, email)
        {
            DataCadastro = DateTime.UtcNow;
            TotalGasto = 0;
            TipoCliente = tipocliente;
            NomeEmpresa = nomeempresa;
            QuantidadeVeiculos = qtdveiculos;
        }

        public void AtualizarTotalGasto() // PENDENTE, FALTA OS OBJETOS NECESSÁRIOS
        {
        }

        public override string ExibirDados()
        {
            if (TipoCliente == TipoDeCliente.Frotista)
                return $"{base.ExibirDados()} | Tipo Cliente: {TipoCliente} | Empresa: {NomeEmpresa} | Frota: {QuantidadeVeiculos} veículos";
            else
                return $"{base.ExibirDados()} | Tipo Cliente: {TipoCliente}";
        }
    }
}