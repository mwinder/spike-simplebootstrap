namespace SimpleBootstrap
{
    public class RegisterUser : Command
    {
        public readonly string Username;

        public readonly string Password;

        public RegisterUser(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public override string ToString()
        {
            return string.Format("RegisterUser [{0}]", Username);
        }
    }
}