using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
namespace Customer
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return string.Format($"Name: {Name}\nAuthor: {Author}\nPrice: {Price}");
        }
    }
    class BinarySerializationDemo
    {
        static void Main(string[] args)
        {
            BinarySerialization();
        }
        private static void BinarySerialization()
        {
            Console.Write("Do you want to : Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "read")
                serialize();
            else
                deserialize();
        }

        private static void serialize()
        {
            Book b = new Book
            {
                Name = "Two States",
                Author = "Chetan Bhagat",
                Price = 200
            };
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fs, b);
            fs.Close();
        }

        private static void deserialize()
        {
            FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Book b = bf.Deserialize(fs) as Book;
            Console.WriteLine(b.Name);
            Console.WriteLine(b.Author);
            Console.WriteLine(b.Price);
            fs.Close();
        }
    }
}