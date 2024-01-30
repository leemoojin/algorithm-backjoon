using System;
using System.Collections.Generic; //Queue<>
using System.Linq; //.Select() 
using System.Text;

namespace _14940
{
    internal class Program
    {
        //입력한 맵
        private static int[,] map;
        //탐색 여부
        private static bool[,] visit;
        //탐색 후 출력할 결과맵 (거리)
        private static int[,] resultMap;
        //맵 사이즈
        private static int sizeN, sizeM;
        //탐색 목표 좌표
        private static int startX, startY;

        //좌표
        class Point
        {
            public int X;
            public int Y;
            public Point(int y, int x)
            {
                Y = y;
                X = x;
            }

        }

        /*
        각 지점에서 목표지점까지의 거리를 출력
        원래 갈 수 없는 땅인 위치는 0을 출력
        갈 수 있는 땅인 부분 중에서 도달할 수 없는 위치는 -1을 출력            
        */

        static void Main(string[] args)
        {
            //세로 크기, 가로 크기 입력
            var inputNM = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            //세로 크기
            sizeN = inputNM[0];
            //가로 크기
            sizeM = inputNM[1];

            //입력 받은 세로,가로 크기의 맵
            map = new int[sizeN, sizeM];
            //출력용 맵
            resultMap = new int[sizeN, sizeM];


            //맵에 숫자넣어 완성하기
            for (int i = 0; i < sizeN; i++)
            {
                //맵의 i줄에 숫자 입력                
                var inputNum = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

                for (int j = 0; j < sizeM; j++)
                {
                    foreach (int element in inputNum)
                    {
                        map[i, j] = element;

                        //목표지점을 찾으면 resultMap에 반영한다
                        if (map[i, j] == 2)
                        {
                            resultMap[i, j] = 0;
                            startY = i;
                            startX = j;
                        }
                        //이동 불가 지역을 찾으면 (0) resultMap에 반영한다
                        if (map[i, j] == 0)
                        {
                            resultMap[i, j] = 0;
                        }
                        if (map[i, j] == 1)
                        {
                            //도달하지 못한 곳은 -1 을 출력 해야하기 때문에 
                            //미리 -1 을 넣어둔 뒤 도달한 곳만 값을 변경해준다  
                            resultMap[i, j] = -1;
                        }

                        j++;
                    }
                }
            }

            //최단거리 찾기
            BFS();

            //StringBuilder 사용으로 시간초과를 해결할수 있었다
            StringBuilder sb = new StringBuilder();

            //결과 맵 출력하기
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {

                    if (j == sizeM - 1)
                    {
                        if (i == sizeN - 1)
                        {
                            sb.Append(resultMap[i, j]);                            
                            break;
                        }

                        sb.Append(resultMap[i, j]).Append("\n");                        
                    }
                    else sb.Append(resultMap[i, j]).Append(" ");

                }
            }

            Console.Write(sb.ToString());
        }

        //너비 탐색
        private static void BFS()
        {
            //탐색여부
            visit = new bool[sizeN, sizeM];
            
            int nowY, nowX;
            int nextY, nextX;
            Point nowPoint;

            //좌표의 좌, 우, 위, 아래 비교
            int[] deltaY = new int[] { -1, 0, 1, 0 };
            int[] deltaX = new int[] { 0, -1, 0, 1 };

            //Queue에는 좌표값을 담아서 탐색에 사용
            Queue<Point> queue = new Queue<Point>();

            //넘겨받은 목표지점 좌표에서부터 인접지역을 탐색해 나간다
            queue.Enqueue(new Point(startY, startX));
            visit[startY, startX] = true;

            while (queue.Count > 0)
            {
                nowPoint = queue.Dequeue();
                nowY = nowPoint.Y;
                nowX = nowPoint.X;

                for (int i = 0; i < 4; i++)
                {
                    nextY = nowY + deltaY[i];
                    nextX = nowX + deltaX[i];
                 
                    //탐색지역이 맵의 유효범위가 아니라면 스킵
                    if (nextY < 0 || nextY >= sizeN || nextX < 0 || nextX >= sizeM)                               
                        continue;
                    //탐색이 불가능한 지역이면 스킵
                    if (resultMap[nextY, nextX] == 0)               
                        continue;
                    //이미 탐색한 지역이면 스킵
                    if (visit[nextY, nextX] == true)        
                        continue;

                    //방문여부
                    visit[nextY, nextX] = true;
                    //거리 추가
                    resultMap[nextY, nextX] = resultMap[nowY, nowX] + 1;
                    //다음 탐색지역
                    queue.Enqueue(new Point(nextY, nextX));                    
                }
            }
        }
    }
}