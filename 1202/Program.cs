using System;

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
            Jewel[] jewels = new Jewel[N];

            for (int i = 0; i < N; i++)
            {
                var MV = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                M = MV[0];
                V = MV[1];

                Jewel jewel = new Jewel(M, V);
                jewels[i] = jewel;
            }

            Jewel tempjewel;

            // 보석 가격 내림차순으로 정렬
            for (int i = 0; i < N; i++)
            {
                if ( i + 1 >= N ) break;

                // 다음 보석 가격 더 크변 위치 변경
                if (jewels[i].price < jewels[i + 1].price)
                {
                    tempjewel = jewels[i];
                    jewels[i] = jewels[i + 1];
                    jewels[i + 1] = tempjewel;              
                }
            }

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
            Array.Reverse(bagWeights);// 반전(내림차순)

            // bagWeights의 요소들이 가방 무게인데 보석 무게와 비교하고 가방 무게보다 작으면 해당 보석 가격을 합친다
            int price = 0;
            int jewelIndex = 0;

            for (int i = 0; i < K; i++)
            {
                 if (jewelIndex >= N) break;

                // 보석을 가방에 넣을 수 있을 때
                if (jewels[jewelIndex].weight <= bagWeights[i])
                {
                    //Console.WriteLine($"보석 무게 : {jewels[jewelIndex].weight}, 가방 무게 : {bagWeights[i]} -> 담기 성공");

                    price += jewels[jewelIndex].price;
                    jewelIndex++;
                }
                // 보석을 못넣을 때
                else
                {
                    //Console.WriteLine($"보석 무게 : {jewels[jewelIndex].weight}, 가방 무게 : {bagWeights[i]} -> 담기 실패");

                    jewelIndex++;
                    i--;
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