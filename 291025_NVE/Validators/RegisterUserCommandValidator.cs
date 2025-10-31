using _291025_NVE.CQRS.Users;
using _291025_NVE.Validators.Behavior;
using System.Text.RegularExpressions;

namespace _291025_NVE.Validators
{
    public class RegisterUserCommandValidator : IValidator<RegisterUserCommand>
    {
        private readonly static string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        private readonly static string phonePattern = @"^+\d{11}";
        public async Task<IEnumerable<string>> ValidateAsync(RegisterUserCommand request, CancellationToken ct)
        {
            List<string> errors = [];
            if (string.IsNullOrEmpty(request.user.Password?.Trim()))
                errors.Add("Некорректный пароль");

            var now = DateTime.UtcNow;
            var date = request.user.DateOfBirth;
            if ((date.Year - now.Year) + (date.Month - now.Month) - (date.Day < now.Day ? 1 : 0) < 18)
                errors.Add("Вам меньше 18");

            if (string.IsNullOrEmpty(request.user.Email?.Trim()) || !Regex.Match(request.user.Email ?? "", emailPattern, RegexOptions.IgnoreCase).Success)
            if (string.IsNullOrEmpty(request.user.Phone.Trim()) || !Regex.Match(request.user.Phone, phonePattern, RegexOptions.IgnoreCase).Success)
                errors.Add("Телефон неправильно указан");
            if (string.IsNullOrEmpty(request.user.FirstName.Trim()) || string.IsNullOrEmpty(request.user.LastName.Trim()))
                errors.Add("Неправильно указано имя");
            if (string.IsNullOrEmpty(request.user.Info?.Trim()))
                errors.Add("Не указана информация о себе");

            return errors;
        }
    }
}
