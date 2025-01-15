namespace _2169
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 각각의 지역은 탐사 가치가 있는데, 로봇을 배열의 왼쪽 위 (1, 1)에서 출발시켜 오른쪽 아래 (N, M)으로 보내려고 한다.
            // 이때, 위의 조건을 만족하면서, 탐사한 지역들의 가치의 합이 최대가 되도록 하는 프로그램을 작성

            // 첫째 줄에 N, M(1≤N, M≤1,000)이 주어진다. 이것은 로봇이 탐사할 지형을 배열로 단순화 한 것
            string[] inputNM = Console.ReadLine().Split();
            int n = int.Parse(inputNM[0]);
            int m = int.Parse(inputNM[1]);

            // 다음 N개의 줄에는 M개의 수로 배열이 주어진다. 배열의 각 수는 절댓값이 100을 넘지 않는 정수이다
            // 이 값은 그 지역의 가치를 나타낸다
            // 프로그래밍상 배열의 왼쪽 위가 (0, 0)이기 때문에 목적지를 (N - 1, M - 1) 라고 생각하면된다
            int[,] valueMap = new int[n, m];

            for (int i = 0; i <= n; i++)
            {
                string[] inputValues = Console.ReadLine().Split();

                for (int j = 0; j <= m; j++)
                {
                    valueMap[i, j] = int.Parse(inputValues[j]);
                }
            }


        }
    }
}
