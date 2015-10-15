namespace SimpleBootstrap
{
    using System;

    public class UserRepository
    {
        public UserRepository()
        {
            Console.WriteLine("User repository created");
            Console.WriteLine();
        }

        public void Save(User user)
        {
            Console.WriteLine("User {0} saved", user.Name);
        }
    }
}