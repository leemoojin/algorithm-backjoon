using System;

namespace _1202
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //보석 갯수 N, 가방 갯수 K 입력
            //보석의 무게 M, 가격 V 입력 (갯수 만큼 반복 N)
            //가방에 넣을 수 있는 무게 C 입력 (갯수만큼 반복 K)

            //가방 한개에는 하나의 보석만 
            //훔칠수있는 최대 가격은?

            var NK = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = NK[0];
            int K = NK[1];




        }

        public class Jewel
        {
            public int weight;
            public int price;

            public Jewel(int weight, int price) 
            {
                this.weight = weight;
                this.price = price;
            }
        }

        public class Bag
        {
            public int weight;

            public Bag(int weight) 
            {
                this.weight= weight;
            }
        }
    }
}