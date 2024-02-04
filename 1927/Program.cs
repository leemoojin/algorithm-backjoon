using System;


namespace _1927
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //숫자 N입력
            int N = int.Parse(Console.ReadLine());

            MiniBinaryHeap miniBinaryHeap = new MiniBinaryHeap();
            

            int x;

            //N개의 정수 x입력
            for (int i = 0; i < N; i++)
            {
                //입력된 x값이 0 또는 자연수
                //x가 0이라면 배열에서 가장 작은 값을 출력하고 그 값을 배열에서 제거 
                //x가 자연수라면 배열에 x라는 값을 넣는(추가하는) 연산
                x = int.Parse(Console.ReadLine());

                if (x == 0) 
                {
                    Console.WriteLine(miniBinaryHeap.Pop());
                    
                }
                else miniBinaryHeap.Push(x);                         
            }
        }

        //최소 힙 - 힙트리 구조 사용
        class MiniBinaryHeap
        {
            private int[] heap = new int[0];

            public int Count()
            {
                return heap.Length;
            }

            public void Push(int num)
            {
                //Console.WriteLine($"푸시실행");
                int _num = num;

                //숫자를 배열에 추가하기 위해 배열의 크기를 1증가
                int [] _heap = new int[heap.Length + 1];
                //이전 힙 배열 안의 값들을 옮겨서 할당해 준다
                if (heap.Length > 0)
                {
                    for (int i = 0; i < heap.Length; i++)
                    {
                        _heap[i] = heap[i];
                    }
                }

                //힙의 맨끝에 데이터 추가
                _heap[_heap.Length-1] = _num;                
                int now = _heap.Length-1;
                int tempt;

                //부모노드와 비교, 작은 값이 부모 노드로 올라간다
                while (now > 0)
                {
                    //비교할 부모노드
                    int next = (now - 1) / 2;
                    
                    if (_heap[next] > _heap[now])
                    {
                        //부모노드가 더 크다면 위치를 바꿔 준다
                        tempt = _heap[next];
                        _heap[next] = _heap[now];
                        _heap[now] = tempt;

                        now = next;//인덱스 값도 변경 변경된 위치에서 다시 비교해야하기 때문
                    }
                    else break;      //부모노드가 더 작을 경우 더이상의 작업이 필요없다               
                }

                heap = _heap;
                //Console.WriteLine($"작업 후 배열 크기 : {heap.Length}");
                //Console.WriteLine($"가장 작은 값 : {heap[0]}");

                /*
                //배열 출력
                for (int j = 0; j < heap.Length; j++)
                {
                    Console.Write(heap[j]);
                    Console.WriteLine();
                }
                */


            }

            //배열에서 가장 작은값을 리턴하고 삭제
            public int Pop() 
            {
                //Console.WriteLine($"팝실행");

                //힙 배열에 아무 값도 없을 때 0 리턴
                if (heap.Length == 0)
                {
                    //heap = new int[0];

                    return 0;
                }

                //리턴할 가장 작은 값을 담는다 (배열의 0번 인덱스)
                int returnNum = heap[0];
                //Console.WriteLine($"리턴 넘 : {heap[0]}");

                if (heap.Length == 1)
                {   
                    heap = new int[0];
                    //Console.WriteLine($"배열 크기 크기 1일때 : {heap.Length}");

                    return returnNum;
                }
                                
                //0번 인덱스 값을 삭제한 배열을 생성한다
                //값을 삭제했기 때문에 배열크기 1 감소
                int[] _heap = new int[heap.Length - 1];
                int lastNum = heap[heap.Length-1];

                //삭제할 0번인덱스와 마지막인덱스를 제외한 값을 다시 할당한다
                //마지막 인덱스의 값을 0번인덱스로 보낸뒤 다시 비교하기 위해
                for (int i = 1; i < heap.Length-1; i++)
                {
                    //Console.WriteLine($"_heap[i-1] = heap[i] : {heap[i]}");
                    _heap[i] = heap[i];
                }
                _heap[0] = lastNum;

                //맨위의 0번인덱스, 부모 노드에서 시작해서 왼쪽,오른쪽 자식노드와 비교하면서 내려간다
                int now = 0;
                int last = _heap.Length - 1;
                int child, tempt;
                //Console.WriteLine($"작업 중");

                /*
                //배열 출력
                for (int j = 0; j < _heap.Length; j++)
                {
                    Console.Write(_heap[j]);
                    Console.WriteLine();
                }
                */


                while (now < last)
                {
                    //Console.WriteLine($"와일문");
                    /*
                    left = now * 2 + 1;
                    right = now * 2 + 2;
                    */

                    //왼쪽 차일드 인덱스, 여기에 +1 할경우 오른쪽 차일드가 된다
                    child = now * 2 + 1;

                    //Console.WriteLine($"now : {_heap[now]}, child : {_heap[child]}");




                    //왼쪽차일드와 오른쪽 차일드를 비교해준다
                    //왼쪽 차일드가 더 클경우
                    if (child < last && _heap[child] > _heap[child + 1])
                    {   
                        //오른쪽 차일드노드를 부모노드로 이동시키기위해 사용할 차일드는 오른쪽 차일드가된다
                        child = child + 1;
                    }


                    //if 문 조건에 범위를 넣어줘야 인덱스를 벗어나는 에러가 발생하지 않는다
                    //부모노드가 자식노드보다 작거나 같을때 멈춘다
                    //수가 2개일때는 child와 last인덱스가 같아진다
                    if (child < last || _heap[now] <= _heap[child]) break;
                    
                    

                    tempt = _heap[now];
                    //더 작은 왼쪽 또는 오른쪽 자식 노드가 부모 노드로 올라온다
                    _heap[now] = _heap[child];
                    //부모노드가 아래로 내려간다
                    _heap[child] = tempt;

                    //내려간 인덱스에서 다시 비교를 반복한다
                    now = child;                    
                }



                heap = _heap;
                /*
                Console.WriteLine($"작업 후 배열 크기 : {heap.Length}");
                //배열 출력
                for (int j = 0; j < heap.Length; j++)
                {
                    Console.Write(heap[j]);
                    Console.WriteLine();
                }
                */

                return returnNum;
            }            
        }

    }
}