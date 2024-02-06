using System;
using System.Collections.Generic;
using System.Text;

namespace _1927
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //숫자 N입력
            int N = int.Parse(Console.ReadLine());
            int x;

            MiniHeap miniHeap = new MiniHeap();
            StringBuilder sB = new StringBuilder();

            //N개의 정수 x입력
            for (int i = 0; i < N; i++)
            {
                //입력된 x값이 0 또는 자연수
                //x가 0이라면 배열에서 가장 작은 값을 출력하고 그 값을 배열에서 제거 
                //x가 자연수라면 배열에 x라는 값을 넣는(추가하는) 연산
                x = int.Parse(Console.ReadLine());

                if (x == 0)
                {
                    sB.Append(miniHeap.RemoveOne() + "\n");
                }
                else miniHeap.Add(x);
                
            }

            Console.WriteLine(sB);

        }

        public class MiniHeap
        {
            private List<int> list = new List<int>();

            public void Add(int value)
            {   
                //리스트 끝에 값 추가
                list.Add(value);
                int child = list.Count - 1;

                //부모노드와 자식노드 비교 (버블 업) - 밑에서 위로 비교
                while (child > 0)
                {
                    //비교할 부모노드
                    int parent = (child - 1) / 2;

                    //자식노드가 부모노드보다 작으면 서로 위치 변경
                    if (list[parent] > list[child])
                    {
                        //위치 변경
                        Swap(parent, child);
                        child = parent;
                    }
                    else 
                    {   
                        break;
                    }
                }
            }

            public int RemoveOne()
            {               

                if (list.Count == 0)
                    return 0;

                //제거하고 리턴할 부모노드
                int returnValue = list[0];
                //Console.WriteLine(returnValue);


                //마지막 인덱스 값을 0번인덱스로 이동
                list[0] = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);//마지막 인덱스 값 삭제

                //버블 다운 - 위에서 아래로 비교
                int parent = 0;
                int last = list.Count - 1;

                while( parent < last ) 
                {
                    //왼쪽 자식노드, 오른쪽 자식노드는 parent * 2 + 2;
                    int child = parent * 2 + 1;

                    //오른쪽 자식노드가 왼쪽 자식노드보다 작을경우
                    if (child < last &&
                        list[child] > list[child + 1])
                        //오른쪽 자식노드를 부모노드와 비교할 준비를 한다, 아닌경우 왼쪽 자식노드로 비교
                        child = child + 1;

                    //부모노드가 더 작거나 같을 때 멈춘다, 자식노드가 마지막 인덱스를 넘어가면 안된다
                    if (child > last ||
                        list[parent] <= list[child])
                        break;

                    //위의 조건에 걸리지 않는다면 부모,자식노드 위치 변경
                    Swap(parent, child);
                    parent = child;
                }


                return returnValue;
            }
            
            private void Swap(int i, int j)
            {   
                //i = parent, j = child
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}