using BotInterface.Bot;
using System;
using System.Reflection;

namespace Dynamite_CS_Runner
{
    class BotLoader
    {
        public static IBot InstantiateBot(byte[] botData)
        {
            try
            {
                var assemblyTypes = Assembly.Load(botData).GetTypes();

                foreach (var type in assemblyTypes)
                {
                    if (type.GetInterface("IBot") != null)
                    {
                        return Activator.CreateInstance(type) as IBot;
                    }
                }
            }
            catch (BadImageFormatException e)
            {
                throw new DllNotFoundException("DLL image is not valid.", e);
            }
            throw new DllNotFoundException("Could not find type implementing IBot");
        }
    }
}
