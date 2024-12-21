using System;
using System.Collections.Generic;

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
            // 보석의 무게 M, 가격 V 입력 (갯수 만큼 반복 N) - 보석 정보 입력
            Jewel[] jewels = new Jewel[N];
            for (int i = 0; i < N; i++)
            {
                var MV = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                jewels[i] = new Jewel(MV[0], MV[1]);
            }

            // 다음 K개 줄에는 가방에 담을 수 있는 최대 무게 Ci가 주어진다. (1 ≤ Ci ≤ 100, 000, 000)
            // 가방에 넣을 수 있는 무게 C 입력 (갯수만큼 반복 K)
            int[] bagWeights = new int[K];
            for (int i = 0; i < K; i++)
            {
                bagWeights[i] = int.Parse(Console.ReadLine());
            }

            // 보석 무게와, 가방 무게로 오름차순 정렬
            Array.Sort(jewels, (a, b) => a.weight.CompareTo(b.weight));// 무게 기준 오름차순
            Array.Sort(bagWeights);// 오름차순

            // bagWeights의 요소들이 가방 무게인데 보석 무게와 비교하고 가방 무게보다 작으면 해당 보석 가격을 합친다
            long totalPrice = 0;
            var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));// 내림차순 정렬
            int jewelIndex = 0;

            for (int i = 0; i < K; i++)
            {
                // 가방 무게보다 같거나 작은 모든 보석을 담고 
                // 그중에 가장 값어치가 높은 보석의 가격을 totalPrice에 더한다
                while (jewelIndex < N && jewels[jewelIndex].weight <= bagWeights[i])
                {
                    maxHeap.Enqueue(jewels[jewelIndex].price, jewels[jewelIndex].price);
                    jewelIndex++;
                }

                // 가장 비싼 보석 선택
                // 가장 비싼 보석을 제거한뒤 나머지 보석을 제거할 필요가없다
                // 다음 주머니는 오름차순으로 정렬했기때문에 보석의 무게보다 무조건 크고
                // 이중에 가장 값어치가 높은 보석을 찾아야하기 때문이다.
                if (maxHeap.Count > 0)
                {
                    totalPrice += maxHeap.Dequeue();
                }
            }

            Console.WriteLine(totalPrice);
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
    }
}