namespace SimpleBootstrap
{
    using System;

    public class Logging
    {
        public static void Log(Command command, Action next)
        {
            Console.WriteLine("Before command: " + command);

            next();

            Console.WriteLine("After command: " + command);
        }

        public static void Log(RegisterUser command, Action next)
        {
            Console.WriteLine("Before registering a user: " + command);

            next();

            Console.WriteLine("After registering a user: " + command);
        }
    }
}