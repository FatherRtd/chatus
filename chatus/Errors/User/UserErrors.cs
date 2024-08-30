namespace chatus.API.Errors.User
{
    public static class UserErrors
    {
        public static Error MissingId(Guid id)
        {
            return new Error($"{nameof(UserErrors)}.{nameof(MissingId)}", $"Пользователь с id = {id} не найден");
        }
        public static readonly Error LoginExists = new Error($"{nameof(UserErrors)}.{nameof(LoginExists)}", "Пользователь с таким логином уже существует");
        public static readonly Error WrongLoginOrPassword = new Error($"{nameof(UserErrors)}.{nameof(WrongLoginOrPassword)}", "Неверный логин или пароль");
    }
}
