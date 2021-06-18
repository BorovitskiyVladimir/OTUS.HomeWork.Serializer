using System;

namespace OTUS.HW5.Serializer.classes
{
    class Program
    {
        static void Main(string[] args)
        {
            F tClass = F.GetTestClass();
            int iterationCount = 1_000_000;
            TSerializer tSerializer = new TSerializer(iterationCount, new Serializer());
            Console.WriteLine(tSerializer.TestRunSerializing(tClass));
            tSerializer = new TSerializer(iterationCount, new JSerializer());
            Console.WriteLine(tSerializer.TestRunSerializing(tClass));
            Console.ReadKey();
        }
    }
}