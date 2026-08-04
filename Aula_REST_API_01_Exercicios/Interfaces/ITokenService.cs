namespace Aula_REST_API_01_Exercicios.Interfaces
{
    public interface ITokenService
    {
        public string GerarToken(string usuario, string role);
    }
}