using System;
using System.Collections.Generic;
using static _1202.Program;

namespace _1202
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 보석 갯수 N, 가방 갯수 K 입력
            // 보석의 무게 M, 가격 V 입력 (갯수 만큼 반복 N)
            // 가방에 넣을 수 있는 무게 C 입력 (갯수만큼 반복 K)

            // 가방 한개에는 하나의 보석만 
            // 훔칠수있는 최대 가격은?


            // 첫째 줄에 N과 K가 주어진다. (1 ≤ N, K ≤ 300,000)
            // 보석 갯수 N, 가방 갯수 K 입력
            var NK = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = NK[0];
            int K = NK[1];

            // 다음 N개 줄에는 각 보석의 정보 Mi와 Vi가 주어진다. (0 ≤ Mi, Vi ≤ 1, 000, 000)
            // 보석의 무게 M, 가격 V 입력 (갯수 만큼 반복 N)
            int M = 0;
            int V = 0;
            //Jewel[] jewels = new Jewel[N];
            List<Jewel> jewels = new List<Jewel>();

            for (int i = 0; i < N; i++)
            {
                var MV = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                M = MV[0];
                V = MV[1];

                Jewel jewel = new Jewel(M, V);
                jewels.Add(jewel);
            }

            //Console.WriteLine("보석들");
            //for (int i = 0; i < N; i++)
            //{
            //    //Console.Write($"{jewels[i].weight}, ");
            //    int temp = priorityQueue.Dequeue().weight;
            //    Console.Write($"{temp}, ");

            //}
            //Console.WriteLine();


            // 다음 K개 줄에는 가방에 담을 수 있는 최대 무게 Ci가 주어진다. (1 ≤ Ci ≤ 100, 000, 000)
            // 가방에 넣을 수 있는 무게 C 입력 (갯수만큼 반복 K)
            int C = 0;
            int[] bagWeights = new int[K];

            for (int i = 0; i < K; i++)
            {
                C = int.Parse(Console.ReadLine());
                bagWeights[i] = C;
            }

            Array.Sort(bagWeights);// 오름차순

            // bagWeights의 요소들이 가방 무게인데 보석 무게와 비교하고 가방 무게보다 작으면 해당 보석 가격을 합친다
            int price = 0;
            //int jewelIndex = 0;

            PriorityQueue<Jewel, int> priorityQueue = new PriorityQueue<Jewel, int>();
            Jewel temp;

            for (int i = 0; i < K; i++)
            {
                // 가장 가벼운 가방에 가장 가벼운 보석이 안들어가면 이 가방에는 아무것도 담을수 없다

                // 가방에 들어갈수 있는 보석을 모두 priorityQueue에 담고
                // 가장 값어치가 높은것을 찾아 price에 값어치를 더한다
                // 해당 보석을 리스트에서 삭제한다
                for (int j = 0; j < jewels.Count; j++)
                {
                    if (bagWeights[i] >= jewels[j].weight)
                    {
                        priorityQueue.Enqueue(jewels[j], jewels[j].price);
                    }
                }

                // priorityQueue에 가장 값어치가 높은것만 남긴다
                if (priorityQueue.Count > 1)
                {
                    while (priorityQueue.Count > 1)
                    {
                        priorityQueue.Dequeue();
                    }

                    temp = priorityQueue.Dequeue();
                    price += temp.price;
                    int index = jewels.IndexOf(temp);
                    jewels.RemoveAt(index);
                    priorityQueue.Clear();
                }

            }

            Console.WriteLine(price);

        }

        // class vs struct?
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

       
    }
}