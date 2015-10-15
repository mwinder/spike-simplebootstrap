namespace SimpleBootstrap
{
    using System;

    public class Configuration : Bootstrapper
    {
        public CommandDispatcher Initialize(params string[] args)
        {
            var dispatcher = new CommandDispatcher();

            var repository = new UserRepository();

            dispatcher.Handles<RegisterUser>(
                command => Logging.Log(command, () => CommandHandlers.Handle(command, repository)));

            return dispatcher;
        }
    }
}
