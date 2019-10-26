using System;

namespace DataStructures
{
    class Program
    {

        static void ConsoleWrite(object data)
        {
            Console.WriteLine(data);
        }

        static void Main(string[] args)
        {
            var buffer = new Buffer<double>();

            ProcessInput(buffer);

            Action<double> consoleOut = delegate (double data)
            {
                Console.WriteLine(data);
            };

            // OR

            // Action<double> consoleOut = d => Console.WriteLine(d); 

            buffer.Dump(consoleOut);

            // OR

            // Without any Action's declaring et cetera, just use lambda expression:

            Converter<double, DateTime> converter = d => new DateTime(2010, 1, 1).AddDays(d);
            var asDates = buffer.Map(converter);

            foreach (var item in asDates)
            {
                Console.WriteLine(item);
            }

            buffer.Dump(d => Console.WriteLine(d));

            ProcessBuffer(buffer);
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            Console.WriteLine("Write some doubles: ");
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                Console.WriteLine($"value {value} cannot be converted to double");
                break;
            }
        }
    }
}
