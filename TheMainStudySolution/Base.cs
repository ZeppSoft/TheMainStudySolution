using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainStudySolution
{
    public class Base2Nested
    {
        int x = 10;
        public int w = 20;
        public void ExtMethod(int num)
        {
            Nested n = new Nested();
            n.Method(num);
        }

        class Nested
        {
            Base2Nested instance = new Base2Nested();
            public void Method(int y)
            {
                int z = instance.w;
                Console.WriteLine($"{instance.x} + {y} = {instance.x+y}");
            }
        }
    }
}
