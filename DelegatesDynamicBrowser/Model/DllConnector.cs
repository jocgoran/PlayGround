using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProcessReflection.Model
{
    static class DllConnector
    {

        public static void Connect(string OpenFile)
        {

            Assembly SampleAssembly = Assembly.LoadFrom(OpenFile);

            Type[] types = null;
            try
            {
                types = SampleAssembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                ThrowReflectionTypeLoadException(SampleAssembly, e);
            }

            foreach (Type type in types)
            {
                if (!type.IsPublic)
                {
                    continue;
                }

                MemberInfo[] members = type.GetMembers();
                foreach (MemberInfo member in members)
                {
                    App.mw.BrowseDll.OutputConsole.Text += $"{type.Name}.{member.Name}\n";
                }

                MethodInfo Method = type.GetMethod("get_Instance");

                if (Method != null)
                {
                    // Obtain a reference to the parameters collection of the MethodInfo instance.
                    ParameterInfo[] Params = Method.GetParameters();
                    // Display information about method parameters.
                    //Param = sParam1
                    //Type = System.String
                    //Position = 0
                    //Optional = False
                    foreach (ParameterInfo Param in Params)
                    {
                        App.mw.BrowseDll.OutputConsole.Text += "    Param=" + Param.Name.ToString();
                        App.mw.BrowseDll.OutputConsole.Text += "       Type=" + Param.ParameterType.ToString();
                        App.mw.BrowseDll.OutputConsole.Text += "       Position=" + Param.Position.ToString();
                        App.mw.BrowseDll.OutputConsole.Text += "       Optional=" + Param.IsOptional.ToString();
                    }
                }

                var delegateMethod = type.GetMethod("Invoke");

                var @params = delegateMethod.GetParameters();
                var returnType = delegateMethod.ReturnType;

                var matchingMethods = type
                    .Assembly
                    .GetTypes()
                    .SelectMany(t => t.GetMethods())
                    .Where(m =>
                    {
                        if (m.ReturnType != returnType)
                            return false;
                        var currParams = m.GetParameters();
                        if (currParams.Length != @params.Length)
                            return false;
                        for (var i = 0; i < currParams.Length; i++)
                            if (currParams[i] != @params[i])
                                return false;

                        return true;
                    });
            } // loop over types

            //Type type = Type.GetType(className, true);
            //dynamic instance = Activator.CreateInstance(type);
            //var response = instance.YourMethod();


        } // end of method

        public static void ThrowReflectionTypeLoadException(Assembly assembly, ReflectionTypeLoadException ex)
        {
            var loaderMessages = new StringBuilder();
            loaderMessages.AppendLine("While trying to load composable parts the following loader exceptions were found: ");
            loaderMessages.AppendFormat("Failed to load {0}.", assembly.FullName).Append(Environment.NewLine);
            loaderMessages.AppendFormat("Unable to load types from assembly {0}:", assembly.GetName()).Append(Environment.NewLine);
            loaderMessages.AppendFormat("Failed to load {0} of the {1} types defined in the assembly.", ex.LoaderExceptions.Length, ex.Types.Length).Append(Environment.NewLine);
            loaderMessages.Append("Exceptions: ").Append(Environment.NewLine);
            foreach (Exception exception in ex.LoaderExceptions)
            {
                loaderMessages.AppendLine(exception.Message);
                TypeLoadException loaderException = exception as TypeLoadException;
                if (loaderException != null)
                {
                    loaderMessages.AppendFormat("- Unable to load type: {0}", loaderException.TypeName).Append(Environment.NewLine); ;
                }

            }

            throw new Exception(loaderMessages.ToString(), ex);
        } // end if ThrowReflectionTypeLoadException

    }  // end of class
}
