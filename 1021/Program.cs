using System;

namespace _1021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 첫째 줄에 큐의 크기 N과 뽑아내려고 하는 수의 개수 M이 주어진다. N은 50보다 작거나 같은 자연수이고 M은 N보다 작거나 같은 자연수이다.
            // 둘째 줄에는 지민이가 뽑아내려고 하는 수의 위치가 순서대로 주어진다. 위치는 1보다 크거나 같고, N보다 작거나 같은 자연수이다.
            // (위치가 1부터 입력되는데 0번 인덱스를 1번째라고 생각하면 된다)

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

            // 양방향 순환 큐 초기화 (1~n)
            LinkedList<int> deque = new LinkedList<int>();
            for (int i = 1; i <= n; i++)
            {
                deque.AddLast(i);
            }

            int totalOperations = 0;

            // 왼쪽 이동 횟수와 오른쪽 이동 횟수를 비교해서 두 값 중 작은 값을 선택
            // 왼쪽 연산 횟수=목표 인덱스. (0번 인덱스가 마지막 인덱스로)
            // 오른쪽 연산 횟수 = 큐 크기−목표 인덱스 (마지막 인덱스가 0번 인덱스로)

            // 찾아야할 deque 원소의 위치값이 targets리스트에 담겨있다
            // 각각의 위치값으로 반복문 실행
            // 1번 위치는 deque의 0번 인덱스라고 생각하면된다 (위치 값에 -1 을 하면 인덱스를 얻는다)
            foreach (int target in targets)
            {
                int index = 0;
                // 목표를 찾으면 deque에서 삭제하기 때문에 삭제 이후 다시 인덱스 값을 계산 
                foreach (int value in deque)
                {   
                    if (value == target) break;
                    index++;
                }

                // 왼쪽과 오른쪽 이동 횟수 비교
                int leftRotation = index;
                int rightRotation = deque.Count - index;

                //Console.WriteLine($"target: {target}, leftRotation : {leftRotation}, rightRotation : {rightRotation}");

                // 비교 해서 더 낮은 계산 횟수를 추가
                totalOperations += Math.Min(leftRotation, rightRotation);

                // 더 낮은 이동 횟수로 큐 회전
                // 왼쪽 이동 횟수가 더 적거나, 오른쪽 이동 횟수와 같은 경우 (같은 경우는 어느쪽으로 계산하든 같아서 그냥 왼쪽 이동 횟수에 포함)
                if (leftRotation <= rightRotation)
                {
                    for (int i = 0; i < leftRotation; i++)
                    {
                        // 0번 인덱스가 마지막 인덱스로
                        int first = deque.First();
                        deque.RemoveFirst();
                        deque.AddLast(first);
                    }
                }
                // 오른쪽 이동 횟수가 더 적은 경우
                else 
                {
                    for (int i = 0; i < rightRotation; i++)
                    {
                        // 마지막 인덱스가 0번 인덱스로
                        int last = deque.Last();
                        deque.RemoveLast();
                        deque.AddFirst(last);
                    }
                }

                // 목표 원소 제거
                deque.RemoveFirst();
            }

            // 결과 출력
            Console.WriteLine(totalOperations);

        }
    }
}
