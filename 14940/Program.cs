using System;
using System.Linq; //.Select() 
using System.Xml.Linq;

namespace _14940
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            각 지점에서 목표지점까지의 거리를 출력
            원래 갈 수 없는 땅인 위치는 0을 출력
            래 갈 수 있는 땅인 부분 중에서 도달할 수 없는 위치는 -1을 출력
            
            */


            //세로 크기 입력
            int sizeN = int.Parse(Console.ReadLine());
            //가로 크기 입력
            int sizeM = int.Parse(Console.ReadLine());

            //입력 받은 세로,가로 크기의 맵 생성
            //2차원 배열
            int[,] map = new int[sizeM, sizeN];
            //시작 좌표
            int startX;
            int startY;


            //거리 계산후 출력할 맵 생성
            int[,] resultMap = new int[sizeM, sizeN];
            
            //도달하지 못한 곳은 -1 을 출력 해야하기때문에 미리 -1 을 넣어둔뒤
            //도달한 곳만 값을 변경해준다            
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    resultMap[i, j] = -1;
                }
            }

            /*
            //맵 출력하기
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    if (j == sizeM - 1) Console.WriteLine($"{resultMap[i, j]}");
                    else Console.Write($"{resultMap[i, j]} ");
                }
            }
            */

            //맵에 숫자넣어 완성하기
            for (int i = 0; i < sizeN; i++)
            {
                //맵의 i줄에 숫자 입력                
                var inputNum = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
                Console.WriteLine(inputNum[0]);

                for (int j = 0; j < sizeM; j++)
                {
                    foreach (int element in inputNum)
                    {
                        map[i, j] = element;
                        //Console.WriteLine($"입력값 map[{i},{j}] = {map[i, j]}");

                        //시작점을 찾으면 해당 좌표를 담아둔다
                        if (map[i,j] == 2)
                        {
                            startX = i;
                            startY = j;
                        }

                        j++;                     
                    }
                }

            }

            //맵 출력하기
            for (int i = 0; i < sizeN; i++)
            {               
                for (int j = 0; j < sizeM; j++)
                {   
                    if (j == sizeM-1) Console.WriteLine($"{map[i, j]}");
                    else Console.Write($"{map[i, j]} ");
                }
            }

          

            //최단거리 구하기
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    resultMap[i, j] = -1;
                }
            }







            string[] arr = new string[2];

            if (arr[0] == null) 
            {
                Console.WriteLine($"값이 없다");

            }

            Console.WriteLine($"0번 인덱스 값 :  {arr[0]}");

            arr[0] = "1";

            Console.WriteLine($"변화 0번 인덱스 값 :  {arr[0]}");

            if (arr[0] == null)
            {
                Console.WriteLine($"값이 없다");

            }
            else if (arr[0] != null) 
            {
                Console.WriteLine($"값이 있다");

            }

        }
    }
}