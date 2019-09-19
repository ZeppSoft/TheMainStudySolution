using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib
{
    [AttributeUsage (AttributeTargets.All, AllowMultiple =false)]
    public class MyAttribute : System.Attribute
    {
        private readonly string date;

        public string Date
        {
            get { return date; }
        }
        public MyAttribute(string date)
        {
            this.date = date;
        }

        public int Number { get; set; }
    }

    [My ("19.09.2019",Number = 10)]
    public class MyClass
    {

    }
    public static class Attribute
    {
        public static void TryAttribute()
        {
            var ac = new MyClass();

            var type = ac.GetType();

            var attrs = type.GetCustomAttributes(false);
        }

    }
}
