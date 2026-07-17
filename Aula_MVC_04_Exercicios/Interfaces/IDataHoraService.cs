namespace Aula_MVC_04_Exercicios.Interfaces
{
    public interface IDataHoraService
    {
        Guid identificador {  get; }
        public DateTime ObterDataAtual();
    }
}