using System;
using System.Collections;

namespace Collections
{
    class CollectionsStudy
    {
       public static void Main()
        {

        }
    }

    public class Element
    {
        public int FieldA { get; set; }
        public int FieldB { get; set; }

        public Element(int a, int b)
        {
            FieldA = a;
            FieldB = b;
        }
    }
    public class UserCollection : IEnumerable, IEnumerator
    {
        readonly Element[] elements = new Element[4];

        public Element this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

       // public Element Current => elements[position];

       // object IEnumerator.Current => elements[position];
        object IEnumerator.Current => elements[position];


        public IEnumerator GetEnumerator() => this as IEnumerator;

        public bool MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                ((IEnumerator)this).Reset();
                return false;
            }
        }
        public void Reset()
        {
            position = -1;
        }
    }

    public class UserCollectionMod 
    {
        readonly Element[] elements = new Element[4];

        public Element this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

        
        public object Current => elements[position];


        public UserCollectionMod GetEnumerator() => this ;

        public bool MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
