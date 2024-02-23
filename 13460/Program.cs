using System;
using System.Collections.Generic;


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

            //Console.WriteLine($"n : {N}, m : {M}");

            //입력 받은 세로,가로 크기의 보드
            board = new char[N, M];

            //N개의 줄에 보드의 모양을 나타내는 길이 M의 문자열이 주어진다
            //N = y축 , M = x축
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

            /*
            for (int i=0; i<N; i++)
            {
                for (int j=0; j<M; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
            */

            Console.WriteLine(BFS(red, blue));

        }

        //너비우선 탐색
        static int BFS((int, int) red, (int, int) blue)
        {
            int[] dx = new int[] { 1, -1, 0, 0 };//x축 탐색용
            int[] dy = new int[] { 0, 0, 1, -1 };//y축 탐색용
            //빨간공좌표 x,y 파란공 좌표 x,y . 탐색횟수, 직전 탐색 인덱스                                                 
            Queue<(int, int, int, int, int, int)> q = new Queue<(int, int, int, int, int, int)>();

            q.Enqueue((red.Item1, red.Item2, blue.Item1, blue.Item2, 0, 0));

            //Console.WriteLine($"redy : {red.Item1}, redx : {red.Item2}, bluey : {blue.Item1}, bluex : {blue.Item2}");


            while (q.Count > 0)
            {
                //Console.WriteLine($"와일문 시작");

                var cur = q.Dequeue();//제거하고 담는다
                //현제 구슬 좌표
                int curRedY = cur.Item1;
                int curRedX = cur.Item2;
                int curBlueY = cur.Item3;
                int curBlueX = cur.Item4;
                int curMoveCount = cur.Item5;
                //int preIndex = cur.Item6;

                //Console.WriteLine($"redy : {curRedY}, redx : {curRedX}, bluey : {curBlueY}, bluex : {curBlueX}, count : {curMoveCount}");

                //10번 움직인 경우 탐색을 종료
                if (curMoveCount == 10) 
                    break;

                //순서대로 좌,우,위,아래로 탐색
                for (int i=0; i<4; i++)
                {
                    bool blueOut = false;//파란공 탈출여부 

                    int nextRedX = curRedX;
                    int nextRedY = curRedY;
                    int nextBlueX = curBlueX;
                    int nextBlueY = curBlueY;

                    //이동 가능한 경우 이동 (벽, 구멍 아닌경우)
                    //파란색 구슬 이동
                    while (board[nextBlueY + dy[i], nextBlueX + dx[i]] != '#')
                    {
                        //Console.WriteLine($"파란구슬 이동가능, {i}");
               
                        //파란 구슬이 구멍에 도달한 경우
                        if (board[nextBlueY + dy[i], nextBlueX + dx[i]] == 'O')
                        {
                            //Console.WriteLine($"파란구슬 탈출");
                            blueOut = true;
                            //continue;//while문이 종료되지 않음
                            break;
                        }

                        nextBlueX += dx[i];
                        nextBlueY += dy[i];
                       
                        //Console.WriteLine($"redy : {nextRedY}, redx : {nextRedX}, bluey : {nextBlueY}, bluex : {nextBlueX}, count : {curMoveCount}");                        
                    }

                    if (blueOut)
                    {
                        //Console.WriteLine($"스킵, {i}");
                        continue;
                    }    
                    //Console.WriteLine($"스킵안함, {i}");

                    //빨간색 구슬 이동
                    while (board[nextRedY + dy[i], nextRedX + dx[i]] != '#')
                    {
                        //Console.WriteLine($"빨간구슬 이동가능 , {i}");
                 
                        nextRedX += dx[i];
                        nextRedY += dy[i];
                        
                        //Console.WriteLine($"redy : {nextRedY}, redx : {nextRedX}, bluey : {nextBlueY}, bluex : {nextBlueX}, count : {curMoveCount}");

                        //빨간 구슬이 구멍에 도달한 경우
                        if (board[nextRedY, nextRedX] == 'O')
                        {
                            //Console.WriteLine($"빨간구슬 탈출");
                            return curMoveCount + 1;
                        }
                    }
                                                           
                    //빨간 구슬과 파란 구슬 둘다 이동 후 위치가 겹친 경우
                    if (nextRedX == nextBlueX && nextRedY == nextBlueY)
                    {
                        //Console.WriteLine($"구슬 겹쳤을때");

                        //빨간 구슬의 총 이동거리
                        int redDist = Math.Abs(nextRedX-curRedX) + Math.Abs(nextRedY-curRedY);
                        //파란 구슬의 총 이동거리
                        int blueDist = Math.Abs(nextBlueX - curBlueX) + Math.Abs(nextBlueY - curBlueY);

                        /*
                        총 이동거리가 더 멀 수록 늦게 도착하게되고
                        //먼저 도착한 구슬이 현재 자리를 차지하고
                        늦게 도착한 구슬은 바로 직전 위치로 이동한다
                        */
                        //파란구슬이 먼저 도착한 경우
                        if (redDist > blueDist)
                        {
                            //Console.WriteLine($"파란구슬이 먼저 도착, 빨간구슬 직전 위치로 이동");
                       
                            nextRedX -= dx[i];
                            nextRedY -= dy[i];
                         
                            //Console.WriteLine($"redy : {nextRedY}, redx : {nextRedX}, bluey : {nextBlueY}, bluex : {nextBlueX}, count : {curMoveCount}");

                        }
                        //빨간 구슬이 먼저 도착한 경우
                        else
                        {
                            //Console.WriteLine($"빨간구슬이 먼저 도착, 파란구슬 직전 위치로 이동");
                           
                            nextBlueX -= dx[i];
                            nextBlueY -= dy[i];
                        
                            //Console.WriteLine($"redy : {nextRedY}, redx : {nextRedX}, bluey : {nextBlueY}, bluex : {nextBlueX}, count : {curMoveCount}");
                        }
                    }

                    //빨간 공이 이동하지 않은 경우 스킵
                    //Console.WriteLine($"이동후 redy : {nextRedY}, redx : {nextRedX}, 시작 redy : {red.Item1}, redx : {red.Item2}, count : {curMoveCount}, index : {i}");
                    if (nextRedX == curRedX && nextRedY == curRedY) continue;


                    //Console.WriteLine($"큐 추가");

                    q.Enqueue((nextRedY, nextRedX, nextBlueY, nextBlueX, curMoveCount + 1, i));
                }
            }

            //10회 이동전에 탈출하지 못한경우
            return -1;
        }
    }
}