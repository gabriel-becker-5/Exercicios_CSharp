// Crie um sistema de Contas Bancárias
// Classe abstrata Conta com Saldo e método abstrato TipoDescricao()
// Classe ContaCorrente com TaxaManutencao (desconta do saldo)
// Classe ContaPoupanca com TaxaRendimento (adiciona ao saldo)
// Crie um objeto de cada tipo e exiba a descrição e saldo final

using Aula_13_Poo_Exercicio_5;

ContaCorrente cc1 = new ContaCorrente(1006.73m);
cc1.TipoDescricao();
cc1.DeduzirTaxa();
cc1.TipoDescricao();

ContaPoupanca cc2 = new ContaPoupanca(1006.73m);
cc2.TipoDescricao();
cc2.AplicarJuros();
cc2.TipoDescricao();