namespace _1021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 첫째 줄에 큐의 크기 N과 뽑아내려고 하는 수의 개수 M
            // 입력 처리
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);// 큐의 크기
            int m = int.Parse(input[1]);// 뽑아낼 원소 개수

            // 뽑아내려고 하는 수의 위치가 순서대로 주어진다(뽑아낼 원소의 인덱스)
            // 입력 처리
            string[] targetInput = Console.ReadLine().Split();
            List<int> targets = new List<int>();
            for (int i = 0; i < m; i++) 
            {
                targets.Add(int.Parse(targetInput[i]));
            }

            // 양방향 순환 큐 초기화
            LinkedList<int> deque = new LinkedList<int>();
            for (int i = 1; i <= n; i++)
            {
                deque.AddLast(i);
            }

            
        }
    }
}
