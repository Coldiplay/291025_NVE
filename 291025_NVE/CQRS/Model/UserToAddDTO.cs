using _291025_NVE.DB;

namespace _291025_NVE.CQRS.Model
{
    public partial class UserToAddDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Phone { get; set; } = null!;

        public string? Info { get; set; }

        public int? Id { get; set; }

        public static explicit operator User(UserToAddDTO user) =>
            new User
            {
                Info = user.Info,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = string.IsNullOrEmpty(user.Password) ? throw new Exception("Не задан пароль для пользователя") : user.Password
            };
        public static explicit operator UserToAddDTO(User user) =>
            new UserToAddDTO
            {
                Id = user.Id,
                Info = user.Info,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
    }
}
