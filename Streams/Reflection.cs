using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommonLib
{
    class PrivateClass
    {
        private int result;
        public PrivateClass(int x)
        {
            result = x + 10;
        }

        private int GetResult()
        {
            return result - 10;
        }
    }
    public static class Reflection
    {
        public static void GetPrivateField()
        {
            var pc = new PrivateClass(5);

            var type = pc.GetType();

            var methods = type.GetMethods(BindingFlags.Instance
                                        | BindingFlags.Static
                                        | BindingFlags.Public
                                        | BindingFlags.NonPublic
                                        | BindingFlags.DeclaredOnly);
            var fields = type.GetFields(BindingFlags.Instance
                                        | BindingFlags.Static
                                        | BindingFlags.Public
                                        | BindingFlags.NonPublic
                                        | BindingFlags.DeclaredOnly);


            var method = methods[0];
           var res1 = method.Invoke(pc,null);

            var field = fields[0];
            var res2 = field.GetValue(pc);

        }
    }
}
