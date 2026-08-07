namespace Aula_REST_API_01_Exercicios.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}