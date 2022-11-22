namespace CSharpRefSample
{
    /// <summary>
    /// 参照型の値渡しと参照渡し
    /// </summary>
    class ReferenceTypes
    {
        /// <summary>
        /// 参照型の値渡し
        /// </summary>
        /// <param name="param"></param>
        private void ReferenceTypes_PassByValue(int[] param)
        {
            param = new int[] { 1000, 2000, 3000 };
        }

        /// <summary>
        /// 参照型の参照渡し ref
        /// </summary>
        /// <param name="param"></param>
        private void ReferenceTypes_PassByReference_ref(ref int[] param)
        {
            param = new int[] { 1000, 2000, 3000 };
        }

        /// <summary>
        /// 参照型の参照渡し in
        /// </summary>
        /// <param name="param"></param>
        private void ReferenceTypes_PassByReference_in(in int[] param)
        {
            // メソッド内で代入をするとエラーになる　書き換え不可
            // param = new int[] { 1000, 2000, 3000 };
        }

        /// <summary>
        /// 参照型の参照渡し out
        /// </summary>
        /// <param name="param"></param>
        private void ReferenceTypes_PassByReference_out(out int[] param)
        {
            // メソッド内で代入をしなければエラーになる 書き換え必須
            param = new int[] { 1000, 2000, 3000 };
        }

        /// <summary>
        /// 第一引数と第二引数の値を入れ替えます。
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        private void Change(ref string value1, ref string value2)
        {
            var temp = value1;

            value1 = value2;
            value2 = temp;

            Console.WriteLine($"書き換え後 {value1} {value2}");
        }

        /// <summary>
        /// 参照型を値渡しするメソッドと参照型を参照渡しするメソッドを呼び出します。
        /// </summary>
        public void ReferenceTypesCall()
        {
            // 参照型の値渡し
            Console.WriteLine("\r\n---参照型の値渡し---\r\n");
            var paramRef = new int[] { 1, 2, 3 };
            Console.WriteLine($"呼び出し前 {string.Join(", ", paramRef)}");

            ReferenceTypes_PassByValue(paramRef);
            Console.WriteLine($"呼び出し後 {string.Join(", ", paramRef)}");

            // 参照型の参照渡し ref
            Console.WriteLine("\r\n---参照型の参照渡し ref---\r\n");
            var paramRef2 = new int[] { 1, 2, 3 };
            Console.WriteLine($"呼び出し前 {string.Join(", ", paramRef2)}");

            ReferenceTypes_PassByReference_ref(ref paramRef2);
            Console.WriteLine($"呼び出し後 {string.Join(", ", paramRef2)}");

            // 参照型の参照渡し in
            Console.WriteLine("\r\n---参照型の参照渡し in---\r\n");
            var paramRef3 = new int[] { 1, 2, 3 };
            Console.WriteLine($"呼び出し前 {string.Join(", ", paramRef3)}");

            ReferenceTypes_PassByReference_in(paramRef3); // in キーワードは必須ではない
            ReferenceTypes_PassByReference_in(in paramRef3);
            Console.WriteLine($"呼び出し後 {string.Join(", ", paramRef3)}" );

            // 参照型の参照渡し out
            Console.WriteLine("\r\n---参照型の参照渡し out---\r\n");
            var paramRef4 = new int[] { 1, 2, 3 };
            Console.WriteLine($"呼び出し前 {string.Join(", ", paramRef4)}");

            ReferenceTypes_PassByReference_out(out paramRef4);
            Console.WriteLine($"呼び出し後 {string.Join(", ", paramRef4)}");

            Console.WriteLine("\r\n---参照型の参照渡しで値の入れ替え---\r\n");
            var value1 = "Hello";
            var value2 = "World!";
            Console.WriteLine($"呼び出し前 {value1} {value2}");

            Change(ref value1, ref value2);
            Console.WriteLine($"呼び出し後 {value1} {value2}");
        }
    }
}
