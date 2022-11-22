namespace CSharpRefSample
{
    /// <summary>
    /// 値型の値渡しと参照渡し
    /// </summary>
    class ValueTypes
    {
        /// <summary>
        /// 値型の値渡し
        /// </summary>
        /// <param name="param"></param>
        private void ValueTypes_PassByValue(int param)
        {
            param = 1000;
        }

        /// <summary>
        /// 値型の参照渡し ref
        /// </summary>
        /// <param name="param"></param>
        private void ValueTypes_PassByReference_ref(ref int param)
        {
            param = 1000;
        }

        /// <summary>
        /// 値型の参照渡し in
        /// </summary>
        /// <param name="param"></param>
        private void ValueTypes_PassByReference_in(in int param)
        {
            // メソッド内で代入をするとエラーになる　書き換え不可
            // param = 1000;
        }

        /// <summary>
        /// 値型の参照渡し out
        /// </summary>
        /// <param name="param"></param>
        private void ValueTypes_PassByReference_out(out int param)
        {
            // メソッド内で代入をしなければエラーになる 書き換え必須
            param = 1000;
        }

        /// <summary>
        /// 値型を値渡しするメソッドと参照型を参照渡しするメソッドを呼び出します。
        /// </summary>
        public void ValueTypesCall()
        {
            // 値型の値渡し
            Console.WriteLine("\r\n---値型の値渡し---\r\n");
            var paramValue = 1;
            Console.WriteLine($"呼び出し前 {paramValue}");

            ValueTypes_PassByValue(paramValue);
            Console.WriteLine($"呼び出し後 {paramValue}");

            // 値型の参照渡し ref
            Console.WriteLine("\r\n---値型の値渡し ref---\r\n");
            var paramValue2 = 1;
            Console.WriteLine($"呼び出し前 {paramValue2}");

            ValueTypes_PassByReference_ref(ref paramValue2);
            Console.WriteLine($"呼び出し後 {paramValue2}");

            // 値型の参照渡し in
            Console.WriteLine("\r\n---値型の値渡し in---\r\n");
            var paramValue3 = 1;
            Console.WriteLine($"呼び出し前 {paramValue3}");

            ValueTypes_PassByReference_in(paramValue3); // in キーワードは必須ではない
            ValueTypes_PassByReference_in(in paramValue3);
            Console.WriteLine($"呼び出し後 {paramValue3}");

            // 値型の参照渡し out
            Console.WriteLine("\r\n---値型の値渡し out---\r\n");
            var paramValue4 = 1;
            Console.WriteLine($"呼び出し前 {paramValue4}");

            ValueTypes_PassByReference_out(out paramValue4);
            Console.WriteLine($"呼び出し後 {paramValue4}");
        }
    }
}
