using System;
using System.Collections.Generic;

namespace _2606
{
    internal class Program
    {        
        static int[,] connection;
        static bool[] visited;
        static int dfsCount = 0;//깊이우선탐색용
       

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

            //연결여부 탐색 확인용 -> 감염된 컴퓨터는 true
            //1번 컴퓨터는 1번 인덱스에 넣는게 직관적이기 때문에 0번 인덱스를 스킵하기위 배열사이즈를 1 늘려야한다
            visited = new bool[input1 + 1];
            
            
            //너비 우선 탐색
            Console.WriteLine(Bfs());


            //깊이 우선 탐색
            /*
             * 깊이 우선탐색의 경우 (1,2) , (1,5), (2,3) 과 같이 감염되어 있을경우
             * 1번과 2번이 감염 된것을 확인후 2번과 연결되어 감연된 컴퓨터를 찾기 위해 탐색한다
             * 1,2에서 바이러스 발견 후 -> 2,3 를 찾아가는 함수가 실행 ~ 종료
             * 아직 끝나지 않은 1,2를 탐색했던 함수가 이어서 1,5를 찾아간다
             * 중간에 함수가 종료되기때문에 인자를 전달하는 방식으로는 
             * 바이러스 갯수를 관리하는것이 불가능하므로 전역에서 관리한다
             * */
            //Dfs(1);
            //Console.WriteLine(dfsCount);

        }

        //너비 우선 탐색
        public static int Bfs()
        {
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
        public static void Dfs(int index)
        {               
            //이미 탐색한 컴퓨터면 종료
            if (visited[index]) return;
            
            //탐색 처리
            visited[index] = true;

            for (int i = 0; i < visited.Length; i++)
            {
                if (connection[index, i] == 1 && !visited[i])
                {
                    dfsCount += 1;
                    Dfs(i);
                }
            }

        }
    }
}