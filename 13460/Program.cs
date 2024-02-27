using System;
using System.Collections.Generic;

namespace _13460
{
    internal class Program
    {
        
        static int N, M;
        static char[,] board;
        static (int y, int x) red, blue;
        
        static void Main(string[] args)
        {        
            var inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            N = inputs[0];//row, y
            M = inputs[1];//column, x

            board = new char[N, M];

            for (int i = 0; i < N; i++)
            {
                String input = Console.ReadLine();

                for (int j = 0; j < M; j++) 
                {
                    board[i, j] = input[j];

                    if (board[i, j] == 'R') red = (i,j);
                    if (board[i, j] == 'B') blue = (i, j);
                }
            }

            Console.WriteLine(Bfs());                          
        }
           
        //Breadth-first search
        public static int Bfs()
        {   
            //search down, up, right, left
            int[] dY = new int[] { 1, -1, 0, 0 };
            int[] dX = new int[] { 0, 0, 1, -1 };
            //red, blue visited
            var visited = new HashSet<((int y, int x), (int y, int x))>();
            visited.Add((red, blue));

            //Console.WriteLine($"처음 위치 : {red}, {blue}");
            /*
            red y,x, blue y,x , moveCount
            Queue<(int,int,int,int,int)> q = new Queue<(int,int,int,int,int)>();
            */
            Queue<Ball> q = new Queue<Ball>();
           
            //add queue
            //q.Enqueue((red.y, red.x, blue.y, blue.x, 0));
            q.Enqueue(new Ball(red.y, red.x, blue.y, blue.x, 0));

            while (q.Count>0) 
            {   
                //current data
                var cur = q.Dequeue();

                /*
                int curRY = cur.Item1;
                int curRX = cur.Item2;
                int curBY = cur.Item3;
                int curBX = cur.Item4;
                int curMoves = cur.Item5;
                */

                int curRY = cur.rY;
                int curRX = cur.rX;
                int curBY = cur.bY;
                int curBX = cur.bX;
                int curMoves = cur.moves;

                //Console.WriteLine($"와일문 : {(curRY,curRX)}, {(curBY,curBX)}, {curMoves}");


                //more than 10 moves, fail return -1
                //지금 이동 횟수가 10이더라도 탐색을 한번더하면 이동횟수를 10회를 초과한다
                if (curMoves >= 10) break;

                //search up, down, right, left
                for (int i = 0; i < 4; i++)
                {
                    //Console.WriteLine($"포문 : {(curRY, curRX)}, {(curBY, curBX)}, {curMoves}, i = {i}");

                    bool redOut = false;
                    bool blueOut = false;
                    int nextRY = curRY;
                    int nextRX = curRX;
                    int nextBY = curBY;
                    int nextBX = curBX;
                    int nextMoves = curMoves;

                    //move blue
                    while (board[nextBY + dY[i], nextBX + dX[i]] != '#')
                    {
                        nextBY += dY[i];
                        nextBX += dX[i];

                        //blue out is fail
                        if (board[nextBY, nextBX] == 'O')
                        {
                            blueOut = true;
                            break;
                        }
                    }                    

                    //move red                    
                    while (board[nextRY + dY[i], nextRX + dX[i]] != '#')
                    {
                        nextRY += dY[i];
                        nextRX += dX[i];

                        //red out is success
                        if (board[nextRY, nextRX] == 'O')
                        {
                            redOut = true;
                            break;
                        }
                    }

                    /*
                    //if red not move, skip
                    //빨간공이 움직이지 않는 상황은 의미가 없다고 생각해서 스킵하려고했는데 오답처리되었다, why?
                    //예제는 모두 통과됨
                    //-> 처음부터 작업을 줄이려 하지말고 일단 구현 후 줄여나갈 것
                    if (nextRY == curRY && nextRX == curRX) continue;
                    */

                    //blue out is fail                 
                    if (blueOut) continue;
                    //red out is success
                    if (redOut) return nextMoves += 1;

                    //blue, red meet
                    if (nextRY == nextBY && nextBX == nextRX)
                    {
                        //down
                        if (i == 0)
                        {
                            if (curRY > curBY) nextBY -= dY[i];//blue back
                            else nextRY -= dY[i];//red back
                        }
                        //up
                        else if (i == 1)
                        {
                            if (curRY > curBY) nextRY -= dY[i];//red back
                            else nextBY -= dY[i];//blue back
                        }
                        //right
                        else if (i == 2)
                        {
                            if (curRX > curBX) nextBX -= dX[i];//blue back
                            else nextRX -= dX[i];//red back
                        }
                        //left
                        else
                        {
                            if (curRX > curBX) nextRX -= dX[i];//red back
                            else nextBX -= dX[i];//blue back
                        }
                    }                    

                    //if didn't visit, move ball
                    if (!visited.Contains(((nextRY,nextRX), (nextBY, nextBX))))
                    {
                        //Console.WriteLine($"처음방문 : {(nextRY, nextRX)}, {(nextBY, nextBX)}");

                        visited.Add(((nextRY, nextRX), (nextBY, nextBX)));//add visit location
                        //인자 전달할때 nextMoves++ 로 전달하면 +1이 적용 안됨,
                        //nextMoves+1로 전달해야 1이 더해진값이 전달됨
                        q.Enqueue(new Ball(nextRY,nextRX,nextBY,nextBX, nextMoves+1));//add queue
                    }
                    //if already visited, skip                  
                }
            }
            return -1;
        }

        public class Ball
        {   
            //보안수준을 public으로 해야 엑세스 가능
            public int rY;
            public int rX;
            public int bY;
            public int bX;
            public int moves;

            public Ball(int rY, int rX, int bY, int bX, int moves)
            {
                this.rY = rY;
                this.rX = rX;
                this.bY = bY;
                this.bX = bX;
                this.moves = moves;
            }
        }
    }    
}