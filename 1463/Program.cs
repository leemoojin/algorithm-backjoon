using System;

namespace _1463
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            정수 X에 사용할 수 있는 연산
            1. x가 3으로 나누어 떨어지면 3으로 나눈다
            2. xrk 2로 나누어 떨어지면 2으로 나눈다
            3. 1을 뺀다
            정수 N이 주어졌을 때, 위와 같은 연산 세 개를 적절히사용해서 1을 만든다
            연산을 사용하는 횟수의 최솟값을 출력하시오

            힌트 다이나믹 프로그래밍
             */

            /*
            2로 나뉠때 2로 나눈다 또는 -1을 한다
            3으로 나뉠때 3으로 나눈다 또는 -1을 한다
            2나 3으로 나뉘지않을때 -1을 한다

            입력값 -1 -> 무조건 실행되는 작업 

            0,1 일때 0을 리턴, 2,3일때 1을 리턴
            */

            //입력된 정수 N
            int numberN = int.Parse(Console.ReadLine());

            //예외처리
            switch (numberN)
            {
                case 0:
                    Console.WriteLine("0");
                    return;

                case 1:
                    Console.WriteLine("0");
                    return;

                case 2:
                    Console.WriteLine("1");
                    return;

                case 3:
                    Console.WriteLine("1");
                    return;
            }

            /*
            계산 횟수를 담을 리스트
            배열의 크기를 입렵값의 +1을 한 이유는
            입력값과 계산횟수리스트 배열의 인덱스를 같게해서 
            4을 입력했을 때 4번인덱스의 담긴 값을 찾게해서 
            좀더 직관적으로 이해하기쉽게하기 위해서
            0번 인덱스는 예외처리를 했기때문에 비워두었다
            */
            int[] count_list = new int[numberN + 1];

            count_list[1] = 0;
            count_list[2] = 1;
            count_list[3] = 1;

            for (int i = 4; i < count_list.Length; i++)
            {
                //입력값에 -1, 횟수 1 증가
                //무조건 실행하는 현재 값에 -1을 하는 작업
                count_list[i] = count_list[i - 1] + 1;             

                //2로 나눠떨어질 때
                if (i % 2 == 0)
                {                
                    //이미 저장된 [i/2]의 계산횟수를 불러와서 1만 더해서 반복 계산을 줄인다
                    //그리고 [i-1]의 계산횟수는 이미 count_list[i]에 담겨있기때문에 그냥 불러온다
                    //그중에 더 작은 값을 찾는다
                    count_list[i] = Math.Min(count_list[i / 2] + 1, count_list[i]);           
                }
                //3으로 나눠떨어질 때
                if (i % 3 == 0)
                {                    
                    count_list[i] = Math.Min(count_list[i / 3] + 1, count_list[i]);
                }

            }
            Console.WriteLine(count_list[numberN]);
        }
    }
}