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

        public static void TryHashTable()
        {
            var hash = new Hashtable();

            hash.Add("Hello", "world");
            //hash.Add("Hello", "Zepp");

            hash["New"] = "world";
            hash["New"] = "---";


            foreach (DictionaryEntry el in hash)
            {
                Console.WriteLine(el.Key);
                Console.WriteLine(el.Value);

            }

            foreach (var el in hash.Values)
            {
                Console.WriteLine(el);

            }
        }

        public static void TryDuplicateHashTable()
        {
            var duplicates = new Hashtable();

            var key1 = new Fish("Herring");
            var key2 = new Fish("Herring");
            var key3 = new Fish("Herring3");

            //var hash1 = key1.GetHashCode();
            //var hash2 = key2.GetHashCode();


            duplicates[key1] = "Hello";
            duplicates[key2] = "Hello2";
            duplicates[key3] = "Hello3";



            Console.WriteLine(duplicates.Count);
        }

        public static void TryIEqualityComparerHashTable()
        {
            var duplicates = new Hashtable(new InsensitiveComparer());

            var key1 = new Fish("Herring");
            var key2 = new Fish("Herring");
            var key3 = new Fish("Herring3");

            //var hash1 = key1.GetHashCode();
            //var hash2 = key2.GetHashCode();


            duplicates[key1] = "Hello";
            duplicates[key2] = "Hello2";
            duplicates[key3] = "Hello3";



            Console.WriteLine(duplicates.Count);
        }
        
    }

    public class InsensitiveComparer : IEqualityComparer
    {
        readonly CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();
        public new bool Equals(object x, object y)
        {
            var first = x as Fish;
            var second = y as Fish;

            if (first == null || second == null )
               return false;

            //return first.FishName.GetHashCode() - second.FishName.GetHashCode() == 0; 

            return comparer.Compare(first.FishName, second.FishName) == 0;
        }

        public int GetHashCode(object obj)
        {
            var fish = obj as Fish;

            if (fish == null)
                return 0;

            //return obj.ToString().ToLowerInvariant().GetHashCode();
            return fish.FishName.ToLowerInvariant().GetHashCode();

        }
    }

    public class Fish //: IComparable
    {
        public string FishName { get; set; }
        public Fish(string name)
        {
            FishName = name;
        }

        //public int CompareTo(object obj)
        //{
        //    var other = obj as Fish;

        //    if (other == null)
        //        return -1;
        //    return this.FishName.GetHashCode() - other.FishName.GetHashCode();
        //}

        //public override int GetHashCode()
        //{
        //    return FishName.GetHashCode();
        //   // return 1;
        //}

        //public override bool Equals(object obj)
        //{
        //    var otherFish = obj as Fish;

        //    if (otherFish.FishName == null)
        //        return false;
        //    return otherFish.FishName.Equals(this.FishName);
        //}
    }
}
