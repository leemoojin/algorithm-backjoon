namespace _9252
{
    internal class Program
    {
        static int[,] dp;
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            //lcsTable에 입력한 글자 + 0 을 편의상 넣는다 때문에 길이 + 1
            dp = new int[input1.Length + 1, input2.Length + 1];

            Console.WriteLine(getLcsLength(input1, input2));
            Console.WriteLine(getLcsToString(input1, input2));
        }

        static int getLcsLength(string input1, string input2)
        {   
            string str1 = input1;
            string str2 = input2;
            int y = str1.Length;
            int x = str2.Length;
            int lcsLength;          

            for (int i = 1; i <= y; i++)
            {

                for (int j = 1; j <= x; j++)
                {
                    //Console.WriteLine($"{i}, {j}");                    
                    //인덱스 i, j 가 0일때는 사용하지 않기 때문에 조건을 1부터 시작으로 한다

                    //비교했을 때 같은 글자일때 lcsTable[i-1, j-1] 의 값에 +1
                    if (str1[i - 1] == str2[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    //같은 글자가 아닐때 lcsTable[i-1, j], lcsTable[i, j-1] 중 더 큰값을 입력
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            //lcs 길이
            lcsLength = dp[y, x];
            //Console.WriteLine($"길이 : {lcsLength}");

            return lcsLength;
        }

        static string getLcsToString(string input1, string input2)
        {   
            int y = input1.Length;
            int x = input2.Length;

            Stack<char> st = new Stack<char>();

            while (y>0 && x>0)
            {
               
                //dp[y-1, x], dp[y, x-1] 중 현재 값과 같은 값이 있다면 해당 인덱스로 이동
                if (dp[y, x] == dp[y - 1, x]) y--;
                else if (dp[y, x] == dp[y, x - 1]) x--;
                //같은 값이 없다면 해당 글자를 스택에 넣고 dp[y-1, x-1]로 이동
                else
                {
                    st.Push(input1[y - 1]);
                    y--;
                    x--;
                }
            }

            string lcs = "";

            //LCS의 길이가 0인 경우에는 둘째 줄을 출력하지 않는다.
            while (st.Count > 0)
            {
                lcs += st.Pop();

            }

            return lcs;
        }
    }
}