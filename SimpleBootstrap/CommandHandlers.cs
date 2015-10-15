namespace SimpleBootstrap
{
    using System;

    public static class CommandHandlers
    {
        public static void Handle(RegisterUser command, UserRepository repository)
        {
            Console.WriteLine("Called with repository #{0}", repository.GetHashCode());

            repository.Save(new User
                {
                    Name = command.Username,
                    Password = command.Password,
                });
        }
    }
}