using System;
using System.Collections.Generic; //Queue<>
using System.Linq; //.Select() 

namespace _14940
{
    internal class Program
    {
        //입력한 맵
        static int[,] map;
        //탐색 여부
        static bool[,] visit;
        //탐색 후 출력할 결과맵
        static int[,] resultMap;
        //출발 좌표
        static int startX;
        static int startY;

        static void Main(string[] args)
        {
            /*
            각 지점에서 목표지점까지의 거리를 출력
            원래 갈 수 없는 땅인 위치는 0을 출력
            갈 수 있는 땅인 부분 중에서 도달할 수 없는 위치는 -1을 출력            
            */

            //세로 크기, 가로 크기 입력
            var inputNM = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            //세로 크기
            int sizeN = inputNM[0];
            //가로 크기
            int sizeM = inputNM[1];

            //입력 받은 세로,가로 크기의 맵
            map = new int[sizeN, sizeM];
            //탐색여부
            visit = new bool[sizeN, sizeM];

            //거리 계산후 출력할 맵 생성
            resultMap = new int[sizeN, sizeM];
            //도달하지 못한 곳은 -1 을 출력 해야하기 때문에 
            //미리 -1 을 넣어둔 뒤 도달한 곳만 값을 변경해준다            
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

                for (int j = 0; j < sizeM; j++)
                {
                    foreach (int element in inputNum)
                    {
                        map[i, j] = element;

                        //시작점을 찾으면 resultMap, visit에 반영한다
                        if (map[i, j] == 2)
                        {
                            resultMap[i, j] = 0;
                            visit[i, j] = true;//방문여부 수정
                            startY = i;
                            startX = j;
                        }
                        //이동 불가 지역을 찾으면 (0) resultMap에 반영한다
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

            //Console.WriteLine($"결과 출력");

            //결과 맵 출력하기
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {


                    if (j == sizeM - 1)
                    {
                        if (i == sizeN - 1 && j == sizeM - 1)
                        {
                            Console.Write($"{resultMap[i, j]}");
                            break;
                        }

                        Console.WriteLine($"{resultMap[i, j]}");
                    }
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
            //탐색할 Y축
            int nowY;

            while (queue.Count > 0)
            {
                //Dequeue(); 가장 오래된 요소를 제거하고 반환한다, nowY에 담긴다
                nowY = queue.Dequeue();//탐색할 Y축

                //Y축(nowY)은 정해졌고 X축의 값들을 탐색한다
                for (int nowX = 0; nowX < sizeM; nowX++)
                {
                    //Console.WriteLine($"x 축 탐색 중, nowY : {nowY}, nowX : {nowX} , 방문 : {visit[nowY,nowX]}, 큐크기 : {queue.Count}");

                    //map이 0이면 스킵한다
                    if (map[nowY, nowX] == 0) continue;

                    //이미 탐색한 경우 
                    if (visit[nowY, nowX])
                    {
                        /*
                        ** 좌우위아래 주변 탐색을 끝낸 후에 이동을 해야한다
                        그렇지 않으면 도착점 기준이 아닌 거리가 구해진다
                        */
                        //위로 갈 수 있을때
                        if (nowY > 0)
                        {
                            if (map[nowY - 1, nowX] != 0 && resultMap[nowY - 1, nowX] == -1 && visit[nowY - 1, nowX] != true)
                            {
                                //거리 1 증가
                                resultMap[nowY - 1, nowX] = resultMap[nowY, nowX] + 1;

                                //Console.WriteLine($"위 갈 수 있을 때, nowY : {nowY}, nowX : {nowX}, 큐크기 : {queue.Count}");
                                //ReturnMap(sizeN, sizeM);                               
                            }
                        }
                        //아래로 갈 수 있을때
                        if (nowY < sizeN - 1)
                        {
                            if (map[nowY + 1, nowX] != 0 && resultMap[nowY + 1, nowX] == -1 && visit[nowY + 1, nowX] != true)
                            {
                                //거리 1 증가
                                resultMap[nowY + 1, nowX] = resultMap[nowY, nowX] + 1;
                                //방문 처리
                                visit[nowY + 1, nowX] = true;
                                //Console.WriteLine($"아래로 갈 수 있을 때, nowY : {nowY}, nowX : {nowX}");
                                //ReturnMap(sizeN, sizeM);
                            }
                        }
                        //오른쪽으로 갈 수 있을때
                        if (nowX < sizeM - 1)
                        {
                            if (map[nowY, nowX + 1] != 0 && resultMap[nowY, nowX + 1] == -1 && visit[nowY, nowX + 1] != true)
                            {
                                //거리 1 증가
                                resultMap[nowY, nowX + 1] = resultMap[nowY, nowX] + 1;
                                //방문 처리
                                visit[nowY, nowX + 1] = true;
                                //Console.WriteLine($"오른쪽 갈 수 있을 때, nowY : {nowY}, nowX : {nowX}");
                                //ReturnMap(sizeN, sizeM);
                            }
                        }
                        //왼쪽으로 갈 수 있을때
                        if (nowX > 0)
                        {
                            if (map[nowY, nowX - 1] != 0 && resultMap[nowY, nowX - 1] == -1 && visit[nowY, nowX - 1] != true)
                            {
                                //거리 1 증가
                                resultMap[nowY, nowX - 1] = resultMap[nowY, nowX] + 1;
                                //방문처리를 한다                            
                                //visit[nowY, nowX - 1] = true;

                                //Console.WriteLine($"왼쪽 갈 수 있을 때, nowY : {nowY}, nowX : {nowX}");
                                //ReturnMap(sizeN, sizeM);

                            }
                        }

                        //탐색 후 이동                        
                        if (nowX > 0 && map[nowY, nowX - 1] != 0 && map[nowY, nowX - 1] == 1 && visit[nowY, nowX - 1] != true)
                        {
                            //Console.WriteLine($"이동 왼");

                            //왼쪽으로 이동
                            if (map[nowY, nowX - 1] != 0 && map[nowY, nowX - 1] == 1 && visit[nowY, nowX - 1] != true)
                            {

                                //방문처리를 한다                            
                                visit[nowY, nowX - 1] = true;

                                //왼쪽 이동 후 맨 끝일때  맨오른쪽으로 간다
                                if (nowX - 1 == 0)
                                {
                                    nowX = sizeM - 2;
                                    //Console.WriteLine($"맨 오른쪽 이동, nowY : {nowY}, nowX : {nowX + 1}, 큐크기 : {queue.Count}");

                                    continue;
                                }

                                nowX = nowX - 2;
                                //Console.WriteLine($"왼쪽 이동, nowY : {nowY}, nowX : {nowX + 1}, 큐크기 : {queue.Count}");

                                continue;
                            }
                        }


                        if (nowY > 0 && map[nowY - 1, nowX] != 0 && map[nowY - 1, nowX] == 1 && visit[nowY - 1, nowX] != true)
                        {
                            //Console.WriteLine($"이동 위");

                            //위로 이동
                            if (map[nowY - 1, nowX] != 0 && map[nowY - 1, nowX] == 1 && visit[nowY - 1, nowX] != true)
                            {

                                //방문 처리
                                visit[nowY - 1, nowX] = true;

                                /*
                                //위 이동 후 맨 끝일때 -> 의미 없음
                                if (nowY - 1 == 0)
                                {
                                    
                                    nowY = 0;
                                    nowX = -1;
                                    //queue.Enqueue(nowY);
                                    Console.WriteLine($"0,0 좌표 이동, nowY : {nowY}, nowX : {nowX + 1}, 큐크기 : {queue.Count}");                                    

                                    continue;
                                }
                                */

                                nowY--;
                                nowX--;
                                //Console.WriteLine($"위로 이동, nowY : {nowY}, nowX : {nowX + 1}, 큐크기 : {queue.Count}");

                                continue;

                            }
                        }
                    }
                }

                //x축 탐색이 끝나면 다음 y축을 탐색한다
                if (nowY < sizeN - 1)
                {
                    queue.Enqueue(nowY + 1);
                    // Console.WriteLine($"다음 Y 축 탐색, nowY : {nowY + 1}");
                }
            }
        }

        //결과 맵 출력하기 확인용
        static void ReturnMap(int sizeN, int sizeM)
        {
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    if (j == sizeM - 1) Console.WriteLine($"{resultMap[i, j]}");
                    else Console.Write($"{resultMap[i, j]} ");
                }
            }
        }
    }
}