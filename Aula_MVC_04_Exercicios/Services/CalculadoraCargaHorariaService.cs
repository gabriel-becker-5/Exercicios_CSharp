using Aula_MVC_04_Exercicios.Interfaces;

namespace Aula_MVC_04_Exercicios.Services
{
    public class CalculadoraCargaHorariaService : ICalculadoraCargaHorariaService
    {
        public int ConverterHorasEmDias(int horas)
        {
            int dias = horas / 24;
            return dias;
        }
    }
}