namespace CSharpAlgorithmSample
{
    /// <summary>
    /// 
    /// </summary>
    public class AlgorithmExamples
    {
        public void Run()
        {
            var array = new int[] { 10, 20, 30, 40, 50 };
            // no1
            FindMinMax(array);
            // no2
            Console.WriteLine(GetFibonacciNumberNumber(5));
            // no3
            Console.WriteLine(ReverseString("こんにちは")); 
        }

        /// <summary>
        /// 配列の最小値と最大値を求める　※配列の最小値と最大値を求めるための単純な線形探索の一種
        /// </summary>
        /// <param name="array">対象の配列</param>
        public void FindMinMax(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("配列が NULL または 要素が0個です。", nameof(array));
            }

            // 初期値を 0 に設定すると、入力配列に 0 より小さい値が含まれている場合、正しく評価できない
            var minValue = array[0];
            var maxValue = array[0];

            // 最小値と最大値の初期値を配列の最初の要素 (添字0) で設定しているため、forループの添字が1から始まる
            for (var i = 1; i < array.Length; i++)
            {
                // 配列の要素が最小値よりも小さい場合、値を更新する
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }

                // 配列の要素が最大値よりも大きい場合、値を更新する
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            Console.WriteLine($"最小値: {minValue}");
            Console.WriteLine($"最大値: {maxValue}");
        }

        /// <summary>
        /// フィボナッチ数列の第 n 項を求める　※再帰的なアルゴリズムの一種
        /// </summary>
        /// <param name="n">正の整数</param>
        /// <returns>フィボナッチ数列の第 n 項</returns>
        public int GetFibonacciNumberNumber(int n)
        {
            /*
            フィボナッチ数列: 0, 1, 1, 2, 3, 5, 8, 13, ...
            
            最初の2つの項は0、1、それ以降の各項は前の2つの項の和
            0, 1, 1(0 + 1), 2(1 + 1), 3(1 + 2), 5(2 + 3), 8(3 + 5), 13(5 + 8), ...

            n = 第n項として、結果を返す

            第0項：0
            第1項：1
            第2項：0 + 1 = 1
            第3項：1 + 1 = 2
            第4項：1 + 2 = 3
            第5項：2 + 3 = 5
            第6項：3 + 5 = 8
            */

            // n が 0 の場合、0
            if (n == 0)
            {
                return 0;
            }

            // n が 1 の場合、1
            if (n == 1)
            {
                return 1;
            }

            // n が 2以上の場合、nの前の項(n - 1) + n のさらに前の項(n - 2) を求める必要がある
            return GetFibonacciNumberNumber(n - 1) + GetFibonacciNumberNumber(n - 2);

            /*
            n = 3 の場合

            1. GetFibonacciNumber(3) GetFibonacciNumber(2) と GetFibonacciNumber(1) を呼び出します。
                ・GetFibonacciNumber(2) は、GetFibonacciNumber(1) と GetFibonacciNumber(0) を呼び出します。
                ・GetFibonacciNumber(1) は 1 を返します。
                ・GetFibonacciNumber(0) は 0 を返します。
                ・よって、GetFibonacciNumber(2) は GetFibonacciNumber(1) + GetFibonacciNumber(0) = 1 + 0 = 「1」 を返します。
            2. GetFibonacciNumber(1) は 「1」 を返します。
            3. GetFibonacciNumber(3) は、GetFibonacciNumber(2) + GetFibonacciNumber(1) = 1 + 1 = 「2」 を返します。
            
            */
        }

        /// <summary>
        /// 文字列を逆順にする
        /// </summary>
        /// <param name="str">対象の文字列</param>
        /// <returns>逆順にした文字列</returns>
        public string ReverseString(string str)
        {
            // 新しいchar型の配列を作成し、str.Length と同じ長さを指定する
            var result = new char[str.Length];

            // str.Length は　文字列の長さを取得する
            for (var i = 0; i < str.Length; i++)
            {
                // 例）こんにちは  1回目：は(5 - 0 - 1) 2回目：ち(5 - 0 - 2)…
                result[i] = str[str.Length - i - 1];
            }

            return new string(result);

            // 別解
            // return new string(str.Reverse().ToArray());  
        }
    }
}

