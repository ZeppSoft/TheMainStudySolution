using System;
using System.Collections.Generic;
using System.Text;

namespace TheMainStudySolution
{
    public  class SingleTon
    {
        private static SingleTon instance = null;

        protected SingleTon()
        {

        }

        public static SingleTon GetInstance()
        {
            if (instance == null)
            {
                instance = new SingleTon();
                return instance;
            }
            else
                return instance;
        }
    }
}
