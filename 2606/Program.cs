using System;

namespace _2606
{
    internal class Program
    {   
        static Array connections;
        static void Main(string[] args)
        {   
            //enter the number of computers
            int input1 = int.Parse(Console.ReadLine());

            //직접 연결되어 있는 컴퓨터 쌍의 수
            int input2 = int.Parse(Console.ReadLine());

            

            //연결되어 있는 컴퓨터의 번호 쌍이 주어진다.
            for (int i = 0; i < input2; i++)
            {
                var input3 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                (int c, int c2) connections;
            }



            Console.WriteLine("Hello, World!");
        }
    }
}