using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer<double>();

            
            ProcessInput(buffer);

            var asInts = buffer.AsEnumerableOf<int>();

            foreach (var item in asInts)
            {
                Console.WriteLine(item);
            }

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
