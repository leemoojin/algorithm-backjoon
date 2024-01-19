using System;
using System.Linq;
using System.Text;
using static System.Console;

namespace _1920
{
    internal class Program
    {
        //StringBuilder 사용으로 시간초과를 해결할수 있었다
        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            //자연수 N입력
            int N = int.Parse(ReadLine());

            //N개의 정수 입력
            var numbersN = ReadLine()!.Split().Select(int.Parse).ToArray();
            //오름차순 정렬
            Array.Sort(numbersN);

            //자연수 M입력
            int M = int.Parse(ReadLine());

            //M개의 정수 입력
            var numbersM = ReadLine()!.Split().Select(int.Parse).ToArray();

            //M개의 정수들이 N개의 정수들안에 있는지 확인할 것
            //이분 탐색을 활용할 것


            for (int i = 0; i < numbersM.Length; i++)
            {
                BinarySearch(numbersM[i], numbersN);
            }

            Write(sb.ToString());
        }

        //이분탐색
        static void BinarySearch(int target, int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (arr[mid] == target)
                {
                    //Console.WriteLine("1");
                    sb.AppendLine("1");
                    return;
                }
                else if (arr[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            //Console.WriteLine("0");
            sb.AppendLine("0");
        }
    }
}