using System;
using System.Collections.Generic;

namespace _2606
{
    internal class Program
    {        
        static int[,] connection;
        static void Main(string[] args)
        {   
            //enter the number of computers
            int input1 = int.Parse(Console.ReadLine());
            //직접 연결되어 있는 컴퓨터 쌍의 수
            int input2 = int.Parse(Console.ReadLine());
 
            //1번 컴퓨터는 1번 인덱스에 넣는게 직관적이기 때문에 0번 인덱스를 스킵하기위 배열사이즈를 1 늘려야한다
            connection = new int[input1+1, input1+1];

            //연결되어 있는 컴퓨터의 번호 쌍이 주어진다.
            for (int i = 0; i < input2; i++)
            {
                var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                //연결된 컴퓨터에 해당하는 인덱스에 1을 넣어둔다, 연결 여부를 1로 설정하기위해
                connection[input[0], input[1]] = 1;
                connection[input[1], input[0]] = 1;
            }
                       
            Console.WriteLine(Bfs(input1));
        }

        //너비 우선 탐색
        public static int Bfs(int input1)
        {   
            int computers = input1;//총 컴퓨터 수
            //연결여부 탐색 확인용 -> 감염된 컴퓨터는 true
            //1번 컴퓨터는 1번 인덱스에 넣는게 직관적이기 때문에 0번 인덱스를 스킵하기위 배열사이즈를 1 늘려야한다
            bool[] visited = new bool[input1 + 1];
            visited[1] = true;//1번 컴퓨터 감염으로 시작
            int count = 0;//1을 통해 감염된 컴퓨터 수

            Queue<int> q = new Queue<int>();

            //감염된 컴퓨터를 큐에 넣고 연결된 컴퓨터 넘버를 찾아낸뒤
            //연결된 컴퓨터를 다시 큐에 넣어서 탐색한다
            q.Enqueue(1);//1번 컴퓨터 감염으로 시작

            while (q.Count > 0)
            {
                int virusCom = q.Dequeue();
               
                for (int i = 1; i < visited.Length; i++)
                {
                    if (connection[virusCom, i] == 1 && !visited[i])
                    {
                        visited[i] = true;
                        count += 1;
                        q.Enqueue(i);
                    }                
                }            
            }
            return count;
        }

        //깊이 우선 탐색
        public static void Dfs()
        {
        
        }
    }
}