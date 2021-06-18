using System;
using System.Diagnostics;
using System.Linq;

namespace OTUS.HW5.Serializer.classes
{
    class TSerializer
    {
        private readonly int iterations;
        private readonly ISerializer serializer;

        public TSerializer(int iterations, ISerializer serializer)
        {
            this.iterations = iterations;
            this.serializer = serializer;
        }
        public string TestRunSerializing<MyObj>(MyObj obj) where MyObj : new()
        {
            string outinfo = $"Кол-во итераций сериализации: {iterations}\r\n";
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                stopwatch.Start();
                string strProperties = string.Empty;
                for (int i = 0; i < iterations; i++)
                {
                    strProperties = serializer.Serialize(obj);
                }
                stopwatch.Stop();
                outinfo += $"Сериализатор: {serializer.GetType().Name}{Environment.NewLine} Строка свойств класса: {strProperties}\r\n";
                outinfo += $"{serializer.GetType().Name}.{serializer.GetType().GetMethods().FirstOrDefault().Name}:\t{stopwatch.Elapsed.Seconds}сек.{stopwatch.Elapsed.Milliseconds}мсек.\r\n";
                stopwatch.Start();
                for (int i = 0; i < iterations; i++)
                {
                    MyObj objF = serializer.Deserialize<MyObj>(strProperties);
                }
                stopwatch.Stop();
                outinfo += $"{serializer.GetType().Name}.{serializer.GetType().GetMethods().ElementAt(1).Name}:\t{stopwatch.Elapsed.Seconds}сек.{stopwatch.Elapsed.Milliseconds}мсек.{Environment.NewLine}";
            }
            catch (Exception e)
            {
                throw new FormatException($"Неверный формат данных! \r\n{e.Message}");
            }
            return outinfo;
        }
    }
}
