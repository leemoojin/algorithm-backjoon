using System;
using System.Linq;

namespace _13460
{
    internal class Program
    {

        static int N, M;
        static char[,] board;

        static void Main(string[] args)
        {
            /*
            보드의 세로 크기는 N, 가로 크기는 M
            첫 번째 줄에는 보드의 세로, 가로 크기를 의미하는 두 정수 N, M (3 ≤ N, M ≤ 10)이 주어진다
             
            왼쪽으로, 오른쪽으로, 위쪽으로, 아래쪽으로 기울이기와 같은 네 가지 동작이 가능
             '.', '#', 'O', 'R', 'B'
            */

            //빨강, 파랑, 구멍 위치
            (int, int) red = (0, 0), blue = (0, 0), end = (0, 0);

            //세로 크기, 가로 크기 입력
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);            
            N = inputs[0];//세로 크기
            M = inputs[1];//가로 크기

            Console.WriteLine($"n : {n}, m : {m}");

            //입력 받은 세로,가로 크기의 보드
            board = new char[N, M];

            //N개의 줄에 보드의 모양을 나타내는 길이 M의 문자열이 주어진다
            for (int i=0; i<N; i++)
            {
                String input = Console.ReadLine();
                
                for (int j=0; j<M; j++)
                {   
                    //입력한 문자를 보드에 입력
                    board[i, j] = input[j];

                    if (board[i, j] == 'R') red = (i, j);
                    else if (board[i, j] == 'B') blue = (i, j);
                    else if (board[i, j] == 'O') end = (i, j);
                }
            }


            for (int i=0; i<N; i++)
            {
                for (int j=0; j<M; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}