using System;
using System.Linq;

namespace _13460
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            보드의 세로 크기는 N, 가로 크기는 M
            첫 번째 줄에는 보드의 세로, 가로 크기를 의미하는 두 정수 N, M (3 ≤ N, M ≤ 10)이 주어진다
             
            왼쪽으로, 오른쪽으로, 위쪽으로, 아래쪽으로 기울이기와 같은 네 가지 동작이 가능
             '.', '#', 'O', 'R', 'B'
            */

            //세로 크기, 가로 크기 입력
            var inputNM = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            //세로 크기
            int sizeN = inputNM[0];
            //가로 크기
            int sizeM = inputNM[1];

            Console.WriteLine($"n : {sizeN}, m : {sizeM}");

            //입력 받은 세로,가로 크기의 보드
            string[,] board = new string[sizeN, sizeM];

            //N개의 줄에 보드의 모양을 나타내는 길이 M의 문자열이 주어진다
            for (int i=0; i<sizeN; i++)
            {
                var input = Console.ReadLine()!.Split().ToArray();
                
                for (int j = 0; j < sizeM; j++)
                {
                    board[i, j] = input[j];
                }
            }


            for (int i=0; i<sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}