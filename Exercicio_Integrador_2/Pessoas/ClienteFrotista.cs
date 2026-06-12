/* Classe ClienteFrotista - Herda de Cliente.
Regras: Possui desconto diferente do ClienteVip.
Atributos: NomeEmpresa, QuantidadeVeiculos */

namespace Exercicio_Integrador_2.Pessoas
{
    public class ClienteFrotista : Cliente
    {
        public const decimal DESCONTO_EXTRA = 0.1m;
        public string NomeEmpresa {  get; private set; }
        public int QuantidadeVeiculos { get; private set; }

        public ClienteFrotista(int id, string nome, string telefone, string email, DateTime datacadastro, decimal totalgasto, string nomeempresa, int quantidadeveiculos) : 
            base(id, nome, telefone, email, datacadastro, totalgasto)
        {
            NomeEmpresa = nomeempresa;
            QuantidadeVeiculos = quantidadeveiculos;
        }
        public override string ExibirDados()
        {
            return $"{base.ExibirDados()} | Empresa: {NomeEmpresa} | Qtd. Veículos: {QuantidadeVeiculos}";
        }
    }
}