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
            FindMinMax(array);
            Console.WriteLine(GetGetFibonacciNumberNumber(5));
        }

        // 配列の最小値と最大値を求めるための単純な線形探索の一種
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

        // 再帰的なアルゴリズムの一種
        public int GetGetFibonacciNumberNumber(int n)
        {
            /*
            フィボナッチ数列: 0, 1, 1, 2, 3, 5, 8, 13, ...
            
            最初の2つの項は0、1、それ以降の各項は前の2つの項の和
            0, 1, 1(0 + 1), 2(1 + 1), 3(1 + 2), 5(2 + 3), 8(3 + 5), 13(5 + 8), ...

            n = 第 n 項として、結果を返す

            第 0 項：0
            第 1 項：1
            第 2 項：0 + 1 = 1
            第 3 項：1 + 1 = 2
            第 4 項：1 + 2 = 3
            第 5 項：2 + 3 = 5
            第 6 項：3 + 5 = 8
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
            return GetGetFibonacciNumberNumber(n - 1) + GetGetFibonacciNumberNumber(n - 2);

            /*
            n = 3 の場合

            1. GetGetFibonacciNumberNumber(3) GetGetFibonacciNumberNumber(2) と GetGetFibonacciNumberNumber(1) を呼び出します。
                ・GetGetFibonacciNumberNumber(2) は、GetFibonacciNumber(1) と GetFibonacciNumber(0) を呼び出します。
                ・GetFibonacciNumber(1) は 1 を返します。
                ・GetFibonacciNumber(0) は 0 を返します。
                ・よって、GetFibonacciNumber(2) は GetFibonacciNumber(1) + GetFibonacciNumber(0) = 1 + 0 = 「1」 を返します。
            2. GetFibonacciNumber(1) は 「1」 を返します。
            3. GetFibonacciNumber(3) は、GetFibonacciNumber(2) + GetFibonacciNumber(1) = 1 + 1 = 「2」 を返します。
            
            */

        }
    }
}