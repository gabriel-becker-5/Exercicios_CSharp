using Aula_MVC_04_Exercicios.Interfaces;
using System.Security.Cryptography;

namespace Aula_MVC_04_Exercicios.Services
{
    public class DataHoraService : IDataHoraService
    {
        public Guid identificador {  get; }

        public DateTime ObterDataAtual()
        {
            return DateTime.Now;
        }

        public DataHoraService()
        {
            identificador = Guid.NewGuid();
        }
    }
}