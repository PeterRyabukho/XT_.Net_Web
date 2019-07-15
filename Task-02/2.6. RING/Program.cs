using System;

namespace _2._6._RING
{
    class Program
    {
        static void Main(string[] args)
        {
            RoundShape roundShape = new RoundShape(4, 4, 5);
            Console.WriteLine(roundShape);

            Ring ring = new Ring(4,4,4,-1);
            Console.WriteLine(ring);

            Console.ReadLine();
        }
    }
}
