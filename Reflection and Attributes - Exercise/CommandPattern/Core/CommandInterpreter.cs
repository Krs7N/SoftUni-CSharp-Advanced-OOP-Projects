using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = cmdArgs[0];

            string[] invokeArgs = cmdArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type intendedCmdType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (intendedCmdType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            MethodInfo executeMethodInfo = intendedCmdType.GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(m => m.Name == "Execute");

            if (executeMethodInfo == null)
            {
                throw new InvalidOperationException("Command does not implement required pattern!");
            }

            object cmdInstance = Activator.CreateInstance(intendedCmdType);
            string result = (string)executeMethodInfo.Invoke(cmdInstance, new object[] { invokeArgs });

            return result;
        }
    }
}