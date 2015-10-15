namespace SimpleBootstrap
{
    using System;
    using System.Collections.Generic;

    public class CommandDispatcher
    {
        private readonly Dictionary<Type, Action<Command>> registrations = new Dictionary<Type, Action<Command>>();

        public void Handles<TCommand>(Action<TCommand> handler) where TCommand : Command
        {
            registrations.Add(typeof(TCommand), x => handler((TCommand)x));
        }

        public void Dispatch(Command command)
        {
            Action<Command> handler;
            if (!registrations.TryGetValue(command.GetType(), out handler))
            {
                throw new Exception("Cannot map " + command.GetType());
            }

            handler.Invoke(command);
        }
    }
}