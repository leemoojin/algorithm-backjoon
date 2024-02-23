using System;
using System.Collections.Generic;
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

        //너비우선 탐색
        static int BFS((int, int) red, (int, int) blue)
        {
            int[] dx = new int[] { 1, 0, -1, 0 };//x축 탐색용
            int[] dy = new int[] { 0, 1, 0, -1 };//y축 탐색용
            //빨간공좌표 x,y 파란공 좌표 x,y . 탐색횟수                                                 
            Queue<(int, int, int, int, int)> q = new Queue<(int, int, int, int, int)>();

            q.Enqueue((red.Item1, red.Item2, blue.Item1, blue.Item2, 0));

            while (q.Count > 0)
            {
                var cur = q.Dequeue();//제거하고 담는다
                int curRedX = cur.Item1;
                int curRedY = cur.Item2;
                int curBlueX = cur.Item3;
                int curBlueY = cur.Item4;
                int curMoveCount = cur.Item5;

                //10번 움직인 경우 탐색을 종료
                if (curMoveCount == 10) 
                    break;




            }

            return 0;
        }

    }
}