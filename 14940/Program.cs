using System;
using System.Collections.Generic; //Queue<>
using System.Linq; //.Select() 

namespace _14940
{
    internal class Program
    {

        static int[,] map;
        static bool[,] visit;
        static int[,] resultMap;


        static void Main(string[] args)
        {
            /*
            각 지점에서 목표지점까지의 거리를 출력
            원래 갈 수 없는 땅인 위치는 0을 출력
            래 갈 수 있는 땅인 부분 중에서 도달할 수 없는 위치는 -1을 출력            
            */

            //세로 크기, 가로 크기 입력
            var inputNM = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            //세로 크기
            int sizeN = inputNM[0];
            //가로 크기
            int sizeM = inputNM[1];

            //입력 받은 세로,가로 크기의 맵
            //2차원 배열
            map = new int[sizeN, sizeM];
            //탐색여부
            visit = new bool[sizeN, sizeM];  

            //거리 계산후 출력할 맵 생성
            resultMap = new int[sizeN, sizeM];            
            //도달하지 못한 곳은 -1 을 출력 해야하기때문에 미리 -1 을 넣어둔뒤
            //도달한 곳만 값을 변경해준다            
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    resultMap[i, j] = -1;
                }
            }

            //맵에 숫자넣어 완성하기
            for (int i = 0; i < sizeN; i++)
            {
                //맵의 i줄에 숫자 입력                
                var inputNum = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
                //Console.WriteLine(inputNum[0]);

                for (int j = 0; j < sizeM; j++)
                {
                    foreach (int element in inputNum)
                    {
                        map[i, j] = element;                       

                        //시작점을 찾으면 resultMap, visit에 반영한다
                        if (map[i,j] == 2)
                        {
                            
                            resultMap[i, j] = 0;
                            visit[i, j] = true;//방문여부                            
                        }
                        //이동 불가 지역을 찾으면 (0) resultMap, visit에 반영한다
                        if (map[i, j] == 0)
                        {
                            resultMap[i, j] = 0;                            
                        }
                        j++;                     
                    }
                }
            }

            //최단거리 구하기
            Bfs(sizeN, sizeM);

            //결과 맵 출력하기
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    if (j == sizeM - 1) Console.WriteLine($"{resultMap[i, j]}");
                    else Console.Write($"{resultMap[i, j]} ");
                }
            }
        }

        //너비탐색
        static void Bfs(int sizeN, int sizeM)
        {       
            //Queue에는 x축에 해당하는 인덱스 값을 담아서
            //반복 탐색하는데 이용할 것이다
            Queue<int> queue = new Queue<int>();
            //0번 인덱스 부터 탐색을 시작하기위해 0번을 넣어둔다
            queue.Enqueue(0);
            //visit[start] = true;

            while (queue.Count > 0)
            {
                //Dequeue(); 가장 오래된 요소를 제거하고 반환한다, nowX에 담긴다
                int nowY = queue.Dequeue();

                //Y축(nowY) 은 정해졌고 X축 값들을 탐색한다
                for (int nowX = 0; nowX < sizeM; nowX++)
                {                  
                    //map이 0이면 스킵한다
                    if (map[nowY, nowX] == 0) continue;                  

                    //이미 탐색한 경우 
                    if (visit[nowY, nowX])
                    {
                        //위로 갈 수 있을때
                        if (nowY > 0 && map[nowY - 1, nowX] != 0 && visit[nowY - 1, nowX] != true)
                        {
                            //거리 1 증가
                            resultMap[nowY - 1, nowX] = resultMap[nowY, nowX] + 1;
                            //방문 처리
                            visit[nowY - 1, nowX] = true;
                         
                            //resultMap[nowY - 1, nowX] 기준 인접 지역을 탐색하지 못했을 수도 있어서
                            //resultMap[nowY - 1, nowX] 로 돌아가서 탐색한다
                            //탐색 순서가 왼쪽에서 오른쪽으로, 위에서 아래로 탐색하기때문에
                            //위나 왼쪽에서 놓치고 지나가는 곳이 있을 수 있기때문에
                            //위와 왼쪽에서 발견했을때만 돌아가서 탐색한다
                            nowY--;
                            continue;
                        }
                        //아래로 갈 수 있을때
                        if (nowY < sizeN - 1 && map[nowY + 1, nowX] != 0 && visit[nowY + 1, nowX] != true)
                        {
                            //거리 1 증가
                            resultMap[nowY + 1, nowX] = resultMap[nowY, nowX] + 1;
                            //방문 처리
                            visit[nowY + 1, nowX] = true;                                                                                    
                        }
                        //오른쪽으로 갈 수 있을때
                        if (nowX < sizeM - 1 && map[nowY, nowX + 1] != 0 && visit[nowY, nowX + 1] != true)
                        {
                            //거리 1 증가
                            resultMap[nowY, nowX + 1] = resultMap[nowY, nowX] + 1;
                            //방문 처리
                            visit[nowY, nowX + 1] = true;                                                       
                        }
                        //왼쪽으로 갈 수 있을때
                        if (nowX > 0 && map[nowY, nowX - 1] != 0 && visit[nowY, nowX - 1] != true)
                        {
                            //거리 1 증가
                            resultMap[nowY, nowX - 1] = resultMap[nowY, nowX] + 1;
                            //방문 처리
                            visit[nowY, nowX - 1] = true;
                                                       
                            //반복문의 조건중 하나가 nowX++ 라서
                            //-1만큼 인덱스를 이동하려면 -2를 해주어야한다
                            nowX = nowX-2;
                            continue;
                        }
                    }                                              
                }
                
                //x축 탐색이 끝나면 다음 y축을 탐색한다
                if (nowY < sizeN - 1)
                {
                    queue.Enqueue(nowY + 1);
                    
                }
            }        
        }
    }
}