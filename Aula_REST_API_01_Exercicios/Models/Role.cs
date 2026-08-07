namespace Aula_REST_API_01_Exercicios.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Cargo { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}