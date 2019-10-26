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
            Action<bool> print = d => Console.WriteLine(d);

            Func<double, double> square = d => d * d;
            Func<double, double, double> add = (x , y) => x + y;
            Predicate<double> isLessThanTen = d => d < 10;

            print(isLessThanTen(square(add(3, 5))));
            
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

            buffer.Dump(d => Console.WriteLine(d));

            var asInts = buffer.AsEnumerableOf<double, int>();
            Console.WriteLine("Buffer's numbers as ints:");
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
