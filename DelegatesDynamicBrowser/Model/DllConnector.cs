using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDynamicBrowser.Model
{
    static class DllConnector
    {

        public static void Connect()
        {

            Assembly SampleAssembly = Assembly.LoadFrom(@"C:\GFMS\UNIQUA\TECNOLOGY\1.0.1\Form\GF.MS.TecForm.Engine.dll");

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
                    App.mw.Delegates.OutputConsole.Text += $"{type.Name}.{member.Name}\n";
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
                        App.mw.Delegates.OutputConsole.Text += "    Param=" + Param.Name.ToString();
                        App.mw.Delegates.OutputConsole.Text += "       Type=" + Param.ParameterType.ToString();
                        App.mw.Delegates.OutputConsole.Text += "       Position=" + Param.Position.ToString();
                        App.mw.Delegates.OutputConsole.Text += "       Optional=" + Param.IsOptional.ToString();
                    }
                }
            }
            //Type type = Type.GetType(className, true);
            //dynamic instance = Activator.CreateInstance(type);
            //var response = instance.YourMethod();
        }

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
        }
    }
}
