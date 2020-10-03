using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Assessment
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone{ get; set; }

        public override string ToString()
        {
            return string.Format($"The name is: {Name} from {Address} is using this number: {Phone}");
        }
    }
    class Serialization
    {
        static void Main(string[] args)
        {
            binaryExample();
            Console.ReadKey();
        }

        private static void binaryExample()
        {
            Console.WriteLine("Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "Read")
                deserializing();
            else
                serializing();
        }

        private static void deserializing()
        {
            FileStream fs = new FileStream("Check.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            Student s = fm.Deserialize(fs) as Student;
            Console.WriteLine(s.Name);
            fs.Close();
        }

        private static void serializing()
        {

            Student s = new Student { Address = "Bangalore", Name = "Sachin", Phone = 83328392332 };
            BinaryFormatter fm = new BinaryFormatter();
            FileStream fs = new FileStream("Check.bin", FileMode.OpenOrCreate, FileAccess.Write);
            fm.Serialize(fs, s);
            fs.Close();
        }
    }
}
