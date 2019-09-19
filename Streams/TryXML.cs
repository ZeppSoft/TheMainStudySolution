using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace CommonLib
{
    #region XML
    public static class TryXML
    {
        public static void ReadXML()
        {
            var document = new XmlDocument();
            document.Load("books.xml");

            Console.WriteLine(document.InnerText);

            Console.WriteLine(document.InnerXml);
        }

        public static void ReadXMLNode()
        {
            var document = new XmlDocument();
            document.Load("books.xml");

            XmlNode root = document.DocumentElement;

            Console.WriteLine(root.LocalName);

            foreach (XmlNode books in root.ChildNodes)
            {
                Console.WriteLine("Found book:");
                foreach (XmlNode book in books.ChildNodes)
                {
                    Console.WriteLine($"{book.Name} : {book.InnerText} ");
                }
                Console.WriteLine(new string('-',40));
            }
        }
        public static void ReadXPath()
        {
            var document = new XPathDocument("books.xml");
            XPathNavigator navigator = document.CreateNavigator();

            XPathNodeIterator iterator1 = navigator.Select("ListOfBooks/Book/Title");

            foreach (var item in iterator1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 40));

            XPathExpression expr = navigator.Compile("ListOfBooks/Book[2]/Price");
            XPathNodeIterator iterator2 = navigator.Select(expr);

            foreach (var item in iterator2)
            {
                Console.WriteLine(item);
            }
        }
    }
    #endregion
}
